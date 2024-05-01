using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class Administrador
    {
        public string Correo { get; set; }
        public string Password { get; set; }
        public ICollection<AdministracionActivos> AdministracionActivos { get; set; }
        public ICollection<AdministracionLaboratorios> AdministracionLaboratorios { get; set; }
        public ICollection<Operador> Operadores { get; set; }
        public ICollection<Profesor> Profesores { get; set; }

    }
}
