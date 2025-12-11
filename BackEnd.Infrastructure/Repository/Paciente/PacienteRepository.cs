

using BackEnd.Core.Models;
using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;

namespace BackEnd.Infrastructure.Paciente;

public class PacienteRepository:BaseRepository<PacienteEntity>,IPacienteRepository
{
    public PacienteRepository(BackEndContext backEnd):base(backEnd)
    {
        
    }
}
