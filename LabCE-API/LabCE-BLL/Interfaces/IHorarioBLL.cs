using LabCE_MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface IHorarioBLL
    {
        public List<HorarioLabDTO> GetHorarioLabBLL(string nombreLab);
        public void CambiarHorarioLabBLL(string nombreLab, char dia, string horaApertura, string horaCierre);

    }
}
