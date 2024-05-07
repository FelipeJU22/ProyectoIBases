using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
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

        /// <summary>
        /// Agrega un profesor en la base de datos
        /// </summary>
        /// <param name="profesor"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarProfesor")]
        public IActionResult ApartarLaboratorioProfesor(Profesor profesor)
        {
            try
            {
                _profesorBLL.AgregarProfesorBLL(profesor);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Busca un profesor por su correo y modifica su nombre
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="nuevoNombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarNombre")]
        public IActionResult ModificarNombre(string correo, string nuevoNombre)
        {
            try
            {
                _profesorBLL.ModificarNombreBLL(correo, nuevoNombre);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Busca un profesor por su correo y modifica su primer apellido
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="primerApellido"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarPrimerApellido")]
        public IActionResult ModificarPrimerApellido(string correo, string primerApellido)
        {
            try
            {
                _profesorBLL.ModificarPrimerApellidoBLL(correo, primerApellido);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Busca un profesor por su correo y modfica su segundo apellido
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="segundoApellido"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarSegundoApellido")]
        public IActionResult ModificarSegundoApellido(string correo, string segundoApellido)
        {
            try
            {
                _profesorBLL.ModificarSegundoApellidoBLL(correo, segundoApellido);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Cambia el correo de un profesor por uno nuevo
        /// </summary>
        /// <param name="correoActual"></param>
        /// <param name="correoNuevo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarCorreo")]
        public IActionResult ModificarCorreo(string correoActual, string correoNuevo)
        {
            try
            {
                _profesorBLL.ModificarCorreoBLL(correoActual, correoNuevo);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Modifica la cedula de un profesor
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="cedula"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarCedula")]
        public IActionResult ModificarCedula(string correo, string cedula)
        {
            try
            {
                _profesorBLL.ModificarCedulaProfesorBLL(correo, cedula);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
        
        /// <summary>
        /// Busca un profesor por su correo y modifica su fecha de nacimiento
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarFechaNacimiento")]
        public IActionResult ModificarFechaNacimiento(string correo, string fecha)
        {
            try
            {
                _profesorBLL.ModificarFechaNacimientoBLL(correo, fecha);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Aprueba un operador
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="nuevoNombre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("AprobarOperador")]
        public IActionResult aprobarOperador(string correoOperador)
        {
            try
            {
                _profesorBLL.AprobarOperadorBLL(correoOperador);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        [HttpGet]
        [Route("VerificarAprobacion")]
        public IActionResult VerificarAprobacion(string correoOperador)
        {
            if (_profesorBLL.VerificarAprobacionBLL(correoOperador))
                return Ok("El operador está aprobado");

            else
                return Unauthorized("El operador no está aprobado");
        }

    }
}
