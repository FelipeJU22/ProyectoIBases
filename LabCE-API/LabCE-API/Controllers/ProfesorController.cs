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
        [HttpGet]
        [Route("CredencialesProfesores")]
        public IActionResult GetProfesoresCredenciales()
        {
            var resultado = _profesorBLL.GetProfesorCredencialesBLL();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("SolicitudesPendientes")]
        public IActionResult GetSolicitudesPendientes(string correoProfesor)
        {
            var resultado = _profesorBLL.GetSolicitudesPendientesBLL(correoProfesor);
            return Ok(resultado);
        }

    }
}
