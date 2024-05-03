using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using LabCE_MODEL.DTOs;
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
        /// <summary>
        /// recibe el nombre de un laboratorio y retorna el nombre de las facilidades que tiene
        /// </summary>
        /// <param name="nombreLab">Nombre de laboratorio</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarFacilidades")]
        public IActionResult GetFacilidadesLaboratorio(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetFacilidadesLaboratorioBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// retorna los horarios en el que un laboratorio específico está ocupado
        /// </summary>
        /// <param name="nombreLab">Nombre de laboratorio</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarHorarioOcupado")]
        public IActionResult GetHorarioOcupado(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetHorarioOcupadoBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// retorna la informacion (Capacidad e informacion) de un laboratorio especifico
        /// </summary>
        /// <param name="nombreLab">Nombre de laboratorio</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarInformacionLab")]
        public IActionResult GetLabInfo(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetLabInfoBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// recibe un objeto con atributos fecha, hora de inicio, hora final, correo de un profesor y el nombre de un lab para reservar dicho lab con los datos dados
        /// </summary>
        /// <param name="apartado">objeto con correo de profesor, nombre de lab, fecha, hora de inicio y hora final</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ApartarLaboratorioProfesor")]
        public IActionResult ApartarLaboratorioProfesor(ApartadoLaboratorioDTO apartado)
        {
            try
            {
                _laboratorioBLL.ApartarLaboratorioProfesorBLL(apartado);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// retorna los activos con su tipo de un lab especifico
        /// </summary>
        /// <param name="nombreLab">nombre de laboratorio</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarActivosLab")]
        public IActionResult MostrarActivosLab(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetActivosLabBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        /// retorna la cantidad de activos que tiene un lab en especifico
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("MostrarCantActivosLab")]
        public IActionResult MostrarCantActivosLab(string nombreLab)
        {
            var resultado = _laboratorioBLL.GetCantActivosLabBLL(nombreLab);
            return Ok(resultado);
        }

        /// <summary>
        ///  Cambia el nombre de un laboratorio especifico
        /// </summary>
        /// <param name="nombreActual"></param>
        /// <param name="nombreNuevo"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("CambiarNombreLab")]
        public IActionResult CambiarNombreLab(string nombreActual, string nombreNuevo)
        {
            try
            {
                _laboratorioBLL.CambiarNombreLabBLL(nombreActual, nombreNuevo);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }
        
        /// <summary>
        /// Modifica la capacidad de un laboratorio especifico
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <param name="capacidad"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarCapacidadLab")]
        public IActionResult ModificarCapacidad(string nombreLab, int capacidad)
        {
            try
            {
                _laboratorioBLL.ModificarCapacidadBLL(nombreLab, capacidad);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        /// <summary>
        /// Modifica la cantidad de computadoras de un laboratorio especifico
        /// </summary>
        /// <param name="nombreLab"></param>
        /// <param name="computadores"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("ModificarComputadoresLab")]
        public IActionResult ModificarComputadores(string nombreLab, int computadores)
        {
            try
            {
                _laboratorioBLL.ModificarComputadoresBLL(nombreLab, computadores);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }


    }
}
