using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("PrestamoLab")]
    public class PrestamoLabController : Controller
    {
        private readonly IPrestamoLabBLL _prestamoLabBLL;

        public PrestamoLabController(IPrestamoLabBLL prestamoLabBLL)
        {
            _prestamoLabBLL = prestamoLabBLL;
        }

        /// <summary>
        /// Retorna los horarios en el que un lab ya tiene una reserva
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarHorarioReservado")]
        public IActionResult MostrarHorarioReservado(string nombreLab)
        {
            var resultado = _prestamoLabBLL.GetHorariosReservadosLabBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// Agrega una reserva de prestamo de laboratorio de un estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ReservarLabEstudiante")]
        public IActionResult ReservarLabEstudiante(EstudiantePrestamoLabDTO estudiante)
        {
            try
            {
                _prestamoLabBLL.ReservarLabEstudianteBLL(estudiante);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

    }
}
