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

        [HttpGet]
        [Route("AprobarSolicitudActivoId")]
        public IActionResult GetPrestamosActivo(string placa)
        {
            try
            {
                _solicitudActivoBLL.GetPrestamosActivoBLL(placa);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Retorna los prestamos que han sido aprobados de un activo de placa especificada
        /// </summary>
        /// <param name="placa">placa del activo</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarPrestamosActivo")]
        public IActionResult MostrarPrestamosActivo(string placa)
        {
            var resultado = _solicitudActivoBLL.GetPrestamosActivoBLL(placa);
            return Ok(resultado);
        }
    }
}
