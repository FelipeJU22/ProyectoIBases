using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabCE_MODEL.DTOs;

namespace LabCE_BLL.Interfaces
{
    public interface ISeguridadBLL
    {
        public bool IngresoOperadorBLL(UsuarioDTO usuario);
        public bool IngresoAdministradorBLL(UsuarioDTO usuario);
        public bool IngresoProfesorBLL(UsuarioDTO usuario);
    }
}
