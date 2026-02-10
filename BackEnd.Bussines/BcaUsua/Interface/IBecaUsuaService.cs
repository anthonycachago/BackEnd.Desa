
using BackEnd.Core.Dto.BcaUsua;
using BackEnd.Core.Models;
using System.Security.Claims;

namespace BackEnd.Bussines.BcaUsua.Interface;

public interface IBecaUsuaService
{
    Task CrearOEditarAsync(BcaUsuaEntity entity);
    AuthResponse GenerarTokenConRefresh(BcaUsuaEntity usuario);
    Task<BcaUsuaEntity?> GetUser(string usuaNom);
    Task<BcaUsuLoginDto?> ValidarCredencialesAsync(string usuaNom, string password, int usuaCodEmpl);
    ClaimsPrincipal? ValidarRefreshToken(string refreshToken);
}
