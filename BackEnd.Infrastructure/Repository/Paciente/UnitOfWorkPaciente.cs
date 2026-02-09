

using BackEnd.Core.Repository;
using BackEnd.Infrastructure.DataBase;

namespace BackEnd.Infrastructure.Paciente;

public class UnitOfWorkPaciente
{
    private readonly BackEndContext _dbContext;

    public UnitOfWorkPaciente(BackEndContext backEndContext)
    {
        _dbContext=backEndContext;
        pacienteRepository = new PacienteRepository(backEndContext);
    }
    public async Task<bool> Save()
    {
        bool isSuccess= await _dbContext.SaveChangesAsync()>0;
        return isSuccess;
    }
    public void Dispose() {
        if (_dbContext == null) return;
        _dbContext.Dispose();
        
    }
    public readonly IPacienteRepository pacienteRepository;
}
