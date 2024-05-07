using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.DTOs
{
    public class PrestamoActivoDTO
    {
        public string NombreEstudiante { get; set; }
        public string Apellido1Estudiante { get; set; }
        public string Apellido2Estudiante { get; set; }
        public string CorreoEstudiante { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
        public bool Finalizado { get; set; }
        public string CorreoProfesor { get; set; }
        public string CorreoOperador { get; set; }
    }
}
