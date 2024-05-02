using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.DTOs
{
    public class SolicitudPendienteDTO
    {
        public string NombreEstudiante { get; set; }
        public string Apellido1Estudiante { get; set; }
        public string Apellido2Estudiante { get; set; }
        public string Tipo { get; set; }
        public int IdActivo { get; set; }
    }
}
