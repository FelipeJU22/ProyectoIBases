using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("SolicitudActivo")]

    public class SolicitudActivoController : Controller
    {
        private readonly ISolicitudActivoBLL _solicitudActivoBLL;

        public SolicitudActivoController(ISolicitudActivoBLL solicitudActivoBLL)
        {
            _solicitudActivoBLL = solicitudActivoBLL;
        }

        /// <summary>
        /// aprueba la solicitud de un activo por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AprobarSolicitudActivoId")]
        public IActionResult AprobarSolicitudActivoId(int id)
        {
            try
            {
                _solicitudActivoBLL.AprobarSolicitudActivoIdBLL(id);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

    }
}
