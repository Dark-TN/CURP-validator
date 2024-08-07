using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public class Apellido
    {
        public string? Valor { get; private set; }

        private Apellido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentNullException("El apellido es obligatorio");

            if (!Regex.IsMatch(valor, @"^\S*$"))
                throw new ArgumentException("El apellido no  puede ser compuesto");

            Valor = valor;
        }

        public static Apellido Create(string? valor) => new Apellido(valor);
    }
}
