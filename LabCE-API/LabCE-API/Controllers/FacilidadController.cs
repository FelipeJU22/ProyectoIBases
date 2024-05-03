using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Facilidad")]


    public class FacilidadController : Controller
    {
        private readonly IFacilidadBLL _facilidadBLL;

        public FacilidadController(IFacilidadBLL facilidadBLL)
        {
            _facilidadBLL = facilidadBLL;   
        }

        /// <summary>
        /// Elimina la facilidad de un laboratorio especifico
        /// </summary>
        /// <param name="facilidad">nombre de lab y nombre de facilidad</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("EliminarFacilidadLab")]
        public IActionResult EliminarFacilidadLab(FacilidadDTO facilidad)
        {
            try
            {
                _facilidadBLL.EliminarFacilidadBLL(facilidad);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Agrega una facilidad a un laboratorio especifico
        /// </summary>
        /// <param name="facilidad"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarFacilidadLab")]
        public IActionResult AgregarFacilidadLab(FacilidadDTO facilidad)
        {
            try
            {
                _facilidadBLL.AgregarFacilidadBLL(facilidad);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

    }
}
