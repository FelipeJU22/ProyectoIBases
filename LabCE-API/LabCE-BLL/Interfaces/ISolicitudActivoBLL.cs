using LabCE_MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface ISolicitudActivoBLL
    {
        public void AprobarSolicitudActivoIdBLL(int id, string placa);
        public List<PrestamoActivoDTO> GetPrestamosActivoBLL(string placa);
        public void EliminarSolicitudActivoIdBLL(int id);
        public void AgregarSolicitudActivoBLL(SolicitudActivoDTO solicitud);
        public void FinalizarPrestamoBLL(int id, string placa);

    }
}
