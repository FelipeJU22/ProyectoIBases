using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_MODEL.Modelos
{
    public class Activo
    {
        public string Placa { get; set; }
        public bool Disponible { get; set; }
        public string Marca { get; set; }
        public bool Aprobacion { get; set; }
        public DateTime DiaCompra { get; set; }
        public DateTime MesCompra { get; set; }
        public DateTime AñoCompra { get; set; }
        public int IdTipo { get; set; }
        public string NombreLaboratorio { get; set; }
        public TipoActivo TipoActivo { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public ICollection<AdministracionActivos> AdministracionActivos { get; set; }
    }
}
