using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Profesor")]

    public class ProfesorController : Controller
    {
        private readonly IProfesorBLL _profesorBLL;

        public ProfesorController(IProfesorBLL profesorBLL)
        {
            _profesorBLL = profesorBLL;
        }
        /// <summary>
        /// retorna una lista de objetos con todas las credenciales de todos los profesores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CredencialesProfesores")]
        public IActionResult GetProfesoresCredenciales()
        {
            var resultado = _profesorBLL.GetProfesorCredencialesBLL();
            return Ok(resultado);
        }

        /// <summary>
        /// retorna una lista de objetos de solicitudes de activos que aún no han sido aprobadas por el profesor dado
        /// </summary>
        /// <param name="correoProfesor">correo del profesor</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SolicitudesPendientes")]
        public IActionResult GetSolicitudesPendientes(string correoProfesor)
        {
            var resultado = _profesorBLL.GetSolicitudesPendientesBLL(correoProfesor);
            return Ok(resultado);
        }

        /// <summary>
        /// cambia la contraseña de un profesor especifico
        /// </summary>
        /// <param name="profesor">Correo y nueva contraseña</param>
        /// <returns></returns>
        [HttpPut]
        [Route("CambiarContraseñaProfesor")]
        public IActionResult CambiarContraseñaProfesor(ProfesorDTO profesor)
        {
            try
            {
                _profesorBLL.CambiarContraseñaProfesorBLL(profesor);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

    }
}
