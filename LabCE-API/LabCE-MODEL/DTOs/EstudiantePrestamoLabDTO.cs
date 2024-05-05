using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.DTOs
{
    public class EstudiantePrestamoLabDTO
    {
        public int CarneEstudiante {  get; set; } 
        public string CorreoEstudiante { get; set; }
        public string NombreEstudiante { get; set; }   
        public string Apellido1Estudiante { get; set; }
        public string Apellido2Estudiante { get; set; }
        public string Fecha {  get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal {  get; set; }
        public string NombreLab {  get; set; }
    }
}
