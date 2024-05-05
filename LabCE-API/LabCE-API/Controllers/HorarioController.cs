using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("Horario")]
    public class HorarioController : Controller
    {
        private readonly IHorarioBLL _horarioBLL;

        public HorarioController(IHorarioBLL horarioBLL)
        {
            _horarioBLL = horarioBLL;   
        }

        /// <summary>
        /// Muestra los horarios en la que un lab especifico está disponible
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarHorariosLab")]
        public IActionResult MostrarHorariosLab(string nombreLab)
        {
            var resultado = _horarioBLL.GetHorarioLabBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// Cambia el horario en la que un lab especifico trabaja en un dia especifico
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <param name="dia">tipo char (Debe ser L, K, M, J, V, S, D)</param>
        /// <param name="horaApertura"></param>
        /// <param name="horaCierre"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarHorarioLab")]
        public IActionResult ModificarHorarioLab(string nombreLab, char dia, string horaApertura, string horaCierre)
        {
            try
            {
                _horarioBLL.CambiarHorarioLabBLL(nombreLab, dia, horaApertura, horaCierre);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

    }
}
