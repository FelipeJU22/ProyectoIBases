using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("RegistroAveria")]
    public class RegistroAveriaController : Controller
    {
        private readonly IRegistroAveriaBLL _registroAveriaBLL;

        public RegistroAveriaController(IRegistroAveriaBLL registroAveriaBLL)
        {
            _registroAveriaBLL = registroAveriaBLL; 
        }

        /// <summary>
        /// Agrega un nuevo registro de averia
        /// </summary>
        /// <param name="idSolicitud"></param>
        /// <param name="detalle"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AgregarAveria")]
        public IActionResult ModificarMarca(int idSolicitud, string detalle)
        {
            try
            {
                _registroAveriaBLL.AgregarAveriaBLL(idSolicitud, detalle);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
