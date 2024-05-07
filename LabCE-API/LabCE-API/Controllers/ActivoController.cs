using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.Modelos;
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

        /// <summary>
        /// Modifica la placa de un activo
        /// </summary>
        /// <param name="placaActual"></param>
        /// <param name="placaNueva"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarPlaca")]
        public IActionResult ModificarPlaca(string placaActual, string placaNueva)
        {
            try
            {
                _activoBLL.ModificarPlacaBLL(placaActual, placaNueva);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();    
        }

        /// <summary>
        /// Modifica el tipo de un activo
        /// </summary>
        /// <param name="placa">placa a buscar</param>
        /// <param name="tipo">nuevo tipo</param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarTipo")]
        public IActionResult ModificarTipo(string placa, string tipo)
        {
            try
            {
                _activoBLL.ModificarTipoBLL(placa, tipo);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        /// <summary>
        /// Modifica la marca de un activo
        /// </summary>
        /// <param name="placa">placa a buscar</param>
        /// <param name="marca">nueva marca</param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarMarca")]
        public IActionResult ModificarMarca(string placa, string marca)
        {
            try
            {
                _activoBLL.ModificarMarcaBLL(placa, marca);
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok();
        }

        /// <summary>
        /// Retorna la informacion de activos disponibles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarActivosDisponibles")]
        public IActionResult MostrarActivosDisponibles()
        {
            var resultado = _activoBLL.GetActivosDisponiblesBLL();
            return Ok(resultado);
        }

        /// <summary>
        /// Retorna el Id de la solicitud junto con la placa del activo en prestamos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarActivosEnPrestamos")]
        public IActionResult MostrarActivosEnPrestamos()
        {
            var resultado = _activoBLL.GetActivosEnPrestamoBLL();
            return Ok(resultado);
        }
    }
}
