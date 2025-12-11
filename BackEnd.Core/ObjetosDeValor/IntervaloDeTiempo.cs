

using BackEnd.Core.Exepciones;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BackEnd.Core.ObjetosDeValor;

public record IntervaloDeTiempo
{
    public DateTime Inicio {  get;}
    public DateTime Fin {  get;}
    public IntervaloDeTiempo(DateTime inicio, DateTime fin)
    {
        if (inicio>=fin)
        {
            throw new ExepcionReglaDelNegocio($"la hora de inicio debe ser anterior a la hora fin");
        }
        Inicio = inicio;
        Fin = fin;
    }
}
