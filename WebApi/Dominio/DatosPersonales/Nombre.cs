using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public class Nombre
    {
        public string? Valor { get; private set; }

        private Nombre(string? valor) {
            if(string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException("El nombre es obligatorio");

            Valor = valor;
        }

        public static Nombre Create(string? valor) => new Nombre(valor);
    }
}
