using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Profesor")]

    public class ActivoController : Controller
    {
        private readonly IActivoBLL _activoBLL;

        public ActivoController(IActivoBLL activoBLL)
        {
            _activoBLL = activoBLL;            
        }

        /// <summary>
        /// Retorna la informacion de activos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("InfoActivos")]
        public IActionResult GetActivosInfo()
        {
            var resultado = _activoBLL.GetActivosInfoBLL();
            return Ok(resultado);
        }
    }
}
