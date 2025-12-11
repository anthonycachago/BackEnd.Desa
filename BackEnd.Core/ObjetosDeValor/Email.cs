using BackEnd.Core.Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Core.ObjetosDeValor
{
    public record Email
    {
        public string? Valor {  get;}
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ExepcionReglaDelNegocio($"el {nameof(email)} es obligatorio");
            }
            if (!email.Contains("@"))
            {
                throw new ExepcionReglaDelNegocio($"el {nameof(email)} es obligatorio");
            }
            Valor = email;
        }
        
    }
}
