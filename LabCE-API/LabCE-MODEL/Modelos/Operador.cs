using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class Operador
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string NumeroCedula { get; set; }
        public string Password { get; set; }
        public bool Aprobado { get; set; }
        public Administrador Administrador { get; set; }
        public ICollection<Registro> Registros { get; set; }
        public ICollection<SolicitudActivo> SolicitudesActivos { get; set; }
    }
}
