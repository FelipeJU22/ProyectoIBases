using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface ITipoActivoBLL
    {
        public void AgregarTipoActivoBLL(string tipo);
        public void ModificarNombreTipoBLL(string tipoActual, string tipoNuevo);

    }
}
