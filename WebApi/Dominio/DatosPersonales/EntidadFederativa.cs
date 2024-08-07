using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public class EntidadFederativa
    {
        public string? Valor {  get; private set; }

        private EntidadFederativa(string? valor)
        {
            if(string.IsNullOrEmpty(valor))
                throw new ArgumentNullException("La entidad federativa es obligatoria");

            Valor = valor;
        }

        public static EntidadFederativa Create(string? valor) => new EntidadFederativa(valor);
    }
}
