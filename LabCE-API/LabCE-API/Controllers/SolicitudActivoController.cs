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

        /// <summary>
        /// Muestra las solicitudes de prestamo de un activo especifico que hayan sido aprobados
        /// </summary>
        /// <param name="placa"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarPrestamosPorActivo")]
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

        /// <summary>
        /// Elimina la solicitud de un activo de la base de datos por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarSolicitudActivoId")]
        public IActionResult EliminarSolicitudActivoId(int id)
        {
            try
            {
                _solicitudActivoBLL.EliminarSolicitudActivoIdBLL(id);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Agrega una solicitud de activo a la base de datos
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarSolicitudActivo")]
        public IActionResult AgregarSolicitudActivo(SolicitudActivoDTO solicitud)
        {
            try
            {
                _solicitudActivoBLL.AgregarSolicitudActivoBLL(solicitud);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Finaliza la solicitud de un prestamo de activo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("FinalizarPrestamo")]
        public IActionResult FinalizarPrestamo(int id)
        {
            try
            {
                _solicitudActivoBLL.FinalizarPrestamoBLL(id);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

    }
}
