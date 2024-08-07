using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public class DatosPersonales
    {
        public Curp Curp {  get; private set; }
        public Nombre Nombre { get; private set; }
        public Apellido ApellidoPaterno { get; private set; }
        public Apellido ApellidoMaterno { get; private set; }
        public DateTime FechaNacimiento { get; private set; }
        public Sexo Sexo { get; private set; }
        public bool EsMexicano { get; private set; }
        public EntidadFederativa EntidadFederativa { get; private set; }

        private DatosPersonales(Curp curp, Nombre nombre, Apellido apellidoPaterno, Apellido apellidoMaterno, Sexo sexo, bool esMexicano, EntidadFederativa entidadFederativa, DateTime fechaNacimiento)
        {
            Curp = curp;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Sexo = sexo;
            EsMexicano = esMexicano;
            EntidadFederativa = entidadFederativa;
            FechaNacimiento = fechaNacimiento;
        }

        public static DatosPersonales Create(Curp curp, Nombre nombre, Apellido apellidoPaterno, Apellido apellidoMaterno, Sexo sexo, bool esMexicano, EntidadFederativa entidadFederativa, DateTime fechaNacimiento) => new(curp, nombre, apellidoPaterno, apellidoMaterno, sexo, esMexicano, entidadFederativa, fechaNacimiento);
    }
}
