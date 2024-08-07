using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public class Curp
    {
        public string? Valor {  get; private set; }

        private Curp(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException("El CURP es obligatorio");

            if (valor.Length != 18 )
                throw new ArgumentException("La longitud del CURP debe ser de 18 caracteres");

            Valor = valor;
        }

        public static Curp Create(string? valor) => new Curp(valor);
    }
}
