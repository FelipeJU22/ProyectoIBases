using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface IProfesorBLL
    {
        public List<ProfesorDTO> GetProfesorCredencialesBLL();
        public List<SolicitudPendienteDTO> GetSolicitudesPendientesBLL(string correo);


    }
}
