using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Interfaces
{
    public interface IProfesorBLL
    {
        public List<Profesor> GetProfesorCredencialesBLL();
        public List<SolicitudPendienteDTO> GetSolicitudesPendientesBLL(string correo);
        public void CambiarContraseñaProfesorBLL(ProfesorDTO profesor);
        public void AgregarProfesorBLL(Profesor profesor);
        public void ModificarNombreBLL(string correoProfesor, string nuevoNombre);
        public void ModificarPrimerApellidoBLL(string correoProfesor, string apellido);
        public void ModificarSegundoApellidoBLL(string correoProfesor, string apellido);
        public void ModificarCorreoBLL(string correoActual, string correoNuevo);
        public void ModificarCedulaProfesorBLL(string correo, string cedula);
        public void ModificarFechaNacimientoBLL(string correo, string fecha);
        public void AprobarOperadorBLL(string correoOperador);

    }
}
