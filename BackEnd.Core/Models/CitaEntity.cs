

using BackEnd.Core.Enums;


namespace BackEnd.Core.Models;

public class CitaEntity
{
    public Guid Id { get; set; }
    public Guid PacienteId { get; set; }
    public Guid DentistaId { get;set; }
    public Guid ConsultorioId { get;set; }
    public EstadoCita Estado {  get;set; }
  public DateTime FechaInicio { get;set; }
    public DateTime FechaFin { get;set; }
    public PacienteEntity? Paciente { get; set; }
    public DentistaEntity? dentista { get; set; }
    public ConsultorioEntity? Consultorio { get; set; }
   
}
