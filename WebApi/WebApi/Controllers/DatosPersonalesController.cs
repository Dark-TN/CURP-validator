using Aplicacion.DatosPersonalesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPersonalesController : ControllerBase
    {
        private readonly IDatosPersonalesService _datosPersonalesService;

        public DatosPersonalesController(IDatosPersonalesService datosPersonalesService)
        {
            _datosPersonalesService = datosPersonalesService;
        }

        [HttpPost]
        public ActionResult<DtoRespuestaValidarCurp> Validate(DtoValidarCurp dtoValidar)
        {
            DtoRespuestaValidarCurp dtoRespuesta = _datosPersonalesService.ValidarCurp(dtoValidar);

            return Ok(dtoRespuesta.Errores);
        }
    }
}
