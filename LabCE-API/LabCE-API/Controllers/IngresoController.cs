using LabCE_BLL.Interfaces;
using LabCE_MODEL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Ingreso")]
    public class IngresoController : Controller
    {
        private readonly ISeguridadBLL _seguridadBLL;
        public IngresoController(ISeguridadBLL seguridadBLL)
        {
            _seguridadBLL = seguridadBLL;
        }

        [HttpPost]
        [Route("IngresoOperador")]
        public IActionResult IngresoOperador([FromBody]UsuarioDTO usuario)
        {

            if (_seguridadBLL.IngresoOperadorBLL(usuario))            
                return Ok("Inicio de sesión de operador exitoso.");   
            
            else
                return Unauthorized("No se encontró el operador");
        }

        [HttpPost]
        [Route("IngresoAdministrador")]
        public IActionResult IngresoAdministrador([FromBody] UsuarioDTO usuario)
        {
            if (_seguridadBLL.IngresoAdministradorBLL(usuario))
                return Ok("Inicio de sesión de administrador exitoso.");

            else
                return Unauthorized("No se encontró el administrador");
        }

        [HttpPost]
        [Route("IngresoProfesor")]
        public IActionResult IngresoProfesor([FromBody] UsuarioDTO usuario)
        {
            if (_seguridadBLL.IngresoProfesorBLL(usuario))
                return Ok("Inicio de sesión de profesor exitoso.");

            else
                return Unauthorized("No se encontró el profesor");
        }


    }
}
