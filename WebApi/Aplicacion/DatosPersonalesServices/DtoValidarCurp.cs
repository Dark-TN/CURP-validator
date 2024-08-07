using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DatosPersonalesServices
{
    public class DtoValidarCurp
    {
        public string? Curp {  get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Sexo {  get; set; }
        public bool EsMexicano { get; set; }
        public string? EntidadFederativa { get; set; }
    }
}
