using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DatosPersonales
{
    public interface ICurpService
    {
        List<string> ValidateCurp(DatosPersonales datosPersonales);
    }
}
