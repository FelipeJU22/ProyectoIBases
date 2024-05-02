using LabCE_BLL.Interfaces;
using LabCE_BLL.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabCE_API.Controllers
{
    [ApiController]
    [Route("SolicitudActivo")]

    public class SolicitudActivoController : Controller
    {
        private readonly ISolicitudActivoBLL _solicitudActivoBLL;

        public SolicitudActivoController(ISolicitudActivoBLL solicitudActivoBLL)
        {
            _solicitudActivoBLL = solicitudActivoBLL;
        }

    }
}
