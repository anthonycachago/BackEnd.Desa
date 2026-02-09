

namespace BackEnd.Core.Dto.BcaUsua;

public class BcaUsuaDto
{
    public int UsuaCodEmpl { get; set; }
    public string UsuaCodPerf { get; set; } = string.Empty;
    public string UsuaNomUsua { get; set; } = string.Empty;
    public string? UsuaPasswd { get; set; }
    public DateTime? UsuaFecUac { get; set; } = DateTime.Now;
    public int? UsuaNumAgen { get; set; }
    public int? UsuaBanUsua { get; set; }
    public string UsuaImpPred { get; set; } = string.Empty;
    public byte?[]? UsuaPasswdHash { get; set; }
}
