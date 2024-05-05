using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface ILaboratorioBLL
    {
        public List<string> GetFacilidadesLaboratorioBLL(string nombreLab);     
        public List<Horario> GetHorarioOcupadoBLL(string nombreLab);
        public List<LaboratorioDTO> GetLabInfoBLL(string nombreLab);
        public void ApartarLaboratorioProfesorBLL(ApartadoLaboratorioDTO apartado);
        public List<ActivoLabDTO> GetActivosLabBLL(string nombreLab);
        public int GetCantActivosLabBLL(string nombreLab);
        public void CambiarNombreLabBLL(string nombreActual, string nombreNuevo);
        public void ModificarCapacidadBLL(string nombreLab, int capacidad);
        public void ModificarComputadoresBLL(string nombreLab, int computadores);
        public List<string> GetNombreLabsDisponiblesBLL();
        public void AgregarLaboratorioBLL(string nombreLab, int capacidad, int computadores);

    }
}
