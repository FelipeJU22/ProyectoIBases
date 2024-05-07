using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.DTOs
{
    public class SolicitudActivoDTO
    {
        public string CorreoEstudiante { get; set; }    
        public string NombreEstudiante { get; set; }
        public string Apellido1Estudiante { get; set; }
        public string Apellido2Estudiante { get; set; }
        public string PlacaActivo { get; set; }
        public string CorreoProfesor { get; set; }
        public string CorreoOperador { get; set; }
    }
}
