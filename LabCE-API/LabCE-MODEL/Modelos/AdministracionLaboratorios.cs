using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class AdministracionLaboratorios
    {
        public string CorreoAdministrador { get; set; }
        public string NombreLab { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public Administrador Administrador { get; set; }

    }
}
