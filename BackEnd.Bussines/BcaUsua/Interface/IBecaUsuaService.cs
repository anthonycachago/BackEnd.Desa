
using BackEnd.Core.Models;

namespace BackEnd.Bussines.BcaUsua.Interface;

public interface IBecaUsuaService
{
    Task CrearOEditarAsync(BcaUsuaEntity entity);
}
