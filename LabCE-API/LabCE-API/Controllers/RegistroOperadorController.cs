using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    public class RegistroOperadorController : Controller
    {
        private readonly IRegistroOperadorBLL _registroOperadorBLL;

        public RegistroOperadorController(IRegistroOperadorBLL registroOperadorBLL)
        {
            _registroOperadorBLL = registroOperadorBLL;
        }

        /// <summary>
        /// Retorna los registros de horas trabajadas de un operador especifico
        /// </summary>
        /// <param name="correoOperador"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RegistroHorasOperador")]
        public IActionResult RegistroHorasOperador(string correoOperador)
        {
            var resultado = _registroOperadorBLL.GetReporteHorasBLL(correoOperador);
            return Ok(resultado);
        }
    }
}
