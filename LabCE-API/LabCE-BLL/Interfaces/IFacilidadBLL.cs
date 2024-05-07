using LabCE_MODEL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface IFacilidadBLL
    {
        public void EliminarFacilidadBLL(FacilidadDTO facilidad);
        public void AgregarFacilidadBLL(FacilidadDTO facilidad);

    }
}
