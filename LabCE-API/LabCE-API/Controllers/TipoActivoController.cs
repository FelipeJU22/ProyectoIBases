using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("TipoActivo")]

    public class TipoActivoController : Controller
    {
        private readonly ITipoActivoBLL _tipoActivoBLL;
        public TipoActivoController(ITipoActivoBLL tipoActivoBLL)
        {
            _tipoActivoBLL = tipoActivoBLL;
        }

        /// <summary>
        /// Agrega un nuevo tipo a la base de datos
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarTipo")]
        public IActionResult AgregarTipo(string tipo)

        {
            try
            {
                _tipoActivoBLL.AgregarTipoActivoBLL(tipo.ToLower());
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Modifica el nombre de un tipo especificado por otro nombre
        /// </summary>
        /// <param name="nombreActual"></param>
        /// <param name="nombreNuevo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarNombreTipo")]
        public IActionResult ModificarNombreTipo(string nombreActual, string nombreNuevo)

        {
            try
            {
                _tipoActivoBLL.ModificarNombreTipoBLL(nombreActual, nombreNuevo);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
    }
}
