using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class ProfesorBLL : IProfesorBLL
    {
        private readonly IConfiguration _configuration;
        private readonly ProfesorDALSQL _profesorDALSQL;

        public ProfesorBLL(IConfiguration configuration, ProfesorDALSQL profesorDALSQL)
        {
            _configuration = configuration;
            _profesorDALSQL = profesorDALSQL;
        }

        public void AgregarProfesorBLL(Profesor profesor)
        {
            try
            {
                _profesorDALSQL.AgregarProfesor(profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AprobarOperadorBLL(string correoOperador)
        {
            try
            {
                _profesorDALSQL.AprobarOperador(correoOperador);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CambiarContraseñaProfesorBLL(ProfesorDTO profesor)
        {
            try
            {
                _profesorDALSQL.CambiarContraseñaProfesor(profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Profesor> GetProfesorCredencialesBLL()
        {
            try
            {
                var resultado = _profesorDALSQL.GetProfesorCredenciales();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<SolicitudPendienteDTO> GetSolicitudesPendientesBLL(string correo)
        {
            try
            {
                var resultado = _profesorDALSQL.GetSolicitudesPendientes(correo);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarCedulaProfesorBLL(string correo, string cedula)
        {
            try
            {
                _profesorDALSQL.ModificarCedulaProfesor(correo, cedula);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarCorreoBLL(string correoActual, string correoNuevo)
        {
            try
            {
                _profesorDALSQL.ModificarCorreo(correoActual, correoNuevo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarFechaNacimientoBLL(string correo, string fecha)
        {
            try
            {
                _profesorDALSQL.ModificarFechaNacimiento(correo, fecha);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarNombreBLL(string correoProfesor, string nuevoNombre)
        {
            try
            {
                _profesorDALSQL.ModificarNombre(correoProfesor, nuevoNombre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarPrimerApellidoBLL(string correoProfesor, string apellido)
        {
            try
            {
                _profesorDALSQL.ModificarPrimerApellido(correoProfesor, apellido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarSegundoApellidoBLL(string correoProfesor, string apellido)
        {
            try
            {
                _profesorDALSQL.ModificarSegundoApellido(correoProfesor, apellido);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool VerificarAprobacionBLL(string correoOperador)
        {
            try
            {
                var resultado = _profesorDALSQL.VerificarAprobacion(correoOperador);

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
