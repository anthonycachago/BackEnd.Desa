

using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Core.Dto.BcaUsua;

public class BcaUsuLoginDto
{
    public string UsuaNomUsua { get; set; } = string.Empty;

    public int UsuaCodEmpl { get; set; }

    [NotMapped]
    public string? Password { get; set; }
}
