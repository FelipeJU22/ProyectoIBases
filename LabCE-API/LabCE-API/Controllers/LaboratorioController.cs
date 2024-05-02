using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Laboratorio")]


    public class LaboratorioController : Controller
    {
        private readonly ILaboratorioBLL _laboratorioBLL;

        public LaboratorioController(ILaboratorioBLL laboratorioBLL)
        {
            _laboratorioBLL = laboratorioBLL;
        }
        [HttpPost]
        [Route("MostrarFacilidades")]
        public IActionResult GetFacilidadesLaboratorio(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetFacilidadesLaboratorioBLL(nombreLab);
            return Ok(resultado);
        }
    }
}
