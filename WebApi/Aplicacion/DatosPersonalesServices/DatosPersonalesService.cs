using Dominio.DatosPersonales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DatosPersonalesServices
{
    public class DatosPersonalesService : IDatosPersonalesService
    {
        private readonly ICurpService _curpService;

        public DatosPersonalesService(ICurpService curpService)
        {
            _curpService = curpService;
        }

        public DtoRespuestaValidarCurp ValidarCurp(DtoValidarCurp dtoValidar)
        {
            DtoRespuestaValidarCurp dtoRespuesta = new();
            List<string> errores = new();

            try
            {
                Curp curp = Curp.Create(dtoValidar.Curp);
                Nombre nombre = Nombre.Create(dtoValidar.Nombres);
                Apellido apellidoPaterno = Apellido.Create(dtoValidar.ApellidoPaterno);
                Apellido apellidoMaterno = Apellido.Create(dtoValidar.ApellidoMaterno);
                Sexo sexo = (Sexo)dtoValidar.Sexo;
                EntidadFederativa entidadFederativa = EntidadFederativa.Create(dtoValidar.EntidadFederativa);

                DatosPersonales datosPersonales = DatosPersonales.Create(curp, nombre, apellidoPaterno, apellidoMaterno, sexo, dtoValidar.EsMexicano, entidadFederativa, dtoValidar.FechaNacimiento);

                errores = _curpService.ValidateCurp(datosPersonales);
            }
            catch (ArgumentNullException ex) 
            { 
                errores.Add(ex.Message);
            }
            catch(ArgumentException ex)
            {
                errores.Add(ex.Message);
            }
            catch(Exception ex)
            {
                errores.Add(ex.Message);
            }

            dtoRespuesta.Errores = errores;
            return dtoRespuesta;
        }
    }
}
