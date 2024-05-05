using LabCE_MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface IActivoBLL
    {
        public List<ActivoInfoDTO> GetActivosInfoBLL();
        public void ModificarPlacaBLL(string placaActual, string placaNueva);
        public void ModificarTipoBLL(string placa, string nuevoTipo);
        public void ModificarMarcaBLL(string placa, string nuevaMarca);
        public void ModificarFechaCompraBLL(string placa, string fecha);

    }
}
