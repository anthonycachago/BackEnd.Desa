using BackEnd.Bussines.BcaUsua.Interface;
using BackEnd.Core.Dto.BcaUsua;
using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BackEnd.Bussines.BcaUsua.Service;

public class BcaUsuaService: IBecaUsuaService
{
    private readonly IBcaUsuaRepository _repository;
    private readonly JwtDto _jwtSettings;

    public BcaUsuaService(IBcaUsuaRepository usuaRepository, IOptions<JwtDto> jwtOptions)
    {
        _repository = usuaRepository;
        _jwtSettings = jwtOptions?.Value ?? new JwtDto();
    }

    public async Task CrearOEditarAsync(BcaUsuaEntity entity)
    {
        var existente = await _repository.GetByUserNameAsync(entity.UsuaNomUsua,entity.UsuaCodEmpl);

        if (existente == null)
        {
            // CREATE
            entity.UsuaPasswd = _repository.Hash(entity.PasswordPlano!);
            entity.PasswordPlano = null;

            await _repository.CreateAsync(entity);
            return;
        }

        // ✏️ UPDATE
        existente.UsuaNomUsua = entity.UsuaNomUsua;
        existente.UsuaCodPerf = entity.UsuaCodPerf;
        existente.UsuaNumAgen = entity.UsuaNumAgen;
        existente.UsuaBanUsua = entity.UsuaBanUsua;

        if (!string.IsNullOrWhiteSpace(entity.PasswordPlano))
        {
            existente.UsuaPasswd = _repository.Hash(entity.PasswordPlano);
        }

        await _repository.UpdateAsync(existente);
    }

    // Genera un JWT con Claim de nombre y usua_cod_empl. Expira en 1 día.
    public AuthResponse GenerarTokenConRefresh(BcaUsuaEntity usuario)
    {
        if (usuario == null) throw new ArgumentNullException(nameof(usuario));

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.Key!)
        );

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var accessClaims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(
            JwtRegisteredClaimNames.Iat,
            DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64
        ),
        new Claim(ClaimTypes.Name, usuario.UsuaNomUsua!.Trim()),
        new Claim("tipoToken", "access")
    };

        var expires = DateTime.UtcNow.AddHours(8);

        var accessToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: accessClaims,
            expires: expires,
            signingCredentials: credentials
        );

        // 🔁 Refresh token
        var refreshClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, usuario.UsuaNomUsua!.Trim()),
        new Claim("tipoToken", "refresh")
    };

        var refreshToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: refreshClaims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credentials
        );

        return new AuthResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshToken),
            Expires = expires
        };
    }



    //buscar por nombre de usuario y contrasena
    public async Task<BcaUsuLoginDto?> ValidarCredencialesAsync(
    string usuaNom,
    string password,
    int usuaCodEmpl)
    {
        var usuario = await _repository.GetByUserNameAsync(usuaNom, usuaCodEmpl);

        if (usuario == null)
            return null;

        if (!_repository.Verify(password, usuario.UsuaPasswd))
            return null;

        return new BcaUsuLoginDto
        {
            UsuaNomUsua = usuario.UsuaNomUsua,
            UsuaCodEmpl = usuario.UsuaCodEmpl,
            
         
        };
    }
    public async Task<BcaUsuaEntity?> GetUser(string usuaNom)
    {
        if (string.IsNullOrWhiteSpace(usuaNom))
            return null;

        // Buscar usuario por nombre de usuario
        var usuario = await _repository.GetByUserTokenAsyn(usuaNom); // Si no necesitas codEmpl, puedes pasar 0 o sobrecargar el método

        if (usuario == null)
            return null;

        return usuario; // retorna la entidad completa
    }

    public ClaimsPrincipal? ValidarRefreshToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var keyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Key ?? string.Empty);

        try
        {
            var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
            }, out SecurityToken validatedToken);

            // Verificar que sea refresh token
            if (principal.Claims.FirstOrDefault(c => c.Type == "tipoToken")?.Value != "refresh")
                return null;

            return principal;
        }
        catch
        {
            return null; // token inválido o expirado
        }
    }




}
