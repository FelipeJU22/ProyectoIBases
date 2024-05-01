using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    internal class Horario
    {
        public Laboratorio Laboratorio { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFinal { get; set; }
        public DateTime Fecha { get; set; }
        public bool Disponible { get; set; }

    }
}
