using LabCE_MODEL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface ILaboratorioBLL
    {
        public List<string> GetFacilidadesLaboratorioBLL(string nombreLab);     
    }
}
