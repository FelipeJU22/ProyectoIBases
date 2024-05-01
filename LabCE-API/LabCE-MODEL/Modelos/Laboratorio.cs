using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class Laboratorio
    {
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public int Computadores { get; set; }
        public ICollection<Facilidad> Facilidades { get; set; }
        public ICollection<AdministracionLaboratorios> AdministracionLaboratorios { get; set; }

    }
}
