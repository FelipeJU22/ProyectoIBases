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
    public class LaboratorioBLL : ILaboratorioBLL
    {
        private readonly IConfiguration _configuration;
        private readonly LaboratorioDALSQL _laboratorioDALSQL;

        public LaboratorioBLL(IConfiguration configuration, LaboratorioDALSQL laboratorioDALSQL)
        {
            _configuration = configuration;
            _laboratorioDALSQL = laboratorioDALSQL;
        }

        public void ApartarLaboratorioProfesorBLL(ApartadoLaboratorioDTO apartado)
        {
            try
            {
                _laboratorioDALSQL.ApartarLaboratorioProfesor(apartado);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CambiarNombreLabBLL(string nombreActual, string nombreNuevo)
        {
            try
            {
                _laboratorioDALSQL.CambiarNombreLab(nombreActual, nombreNuevo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ActivoLabDTO> GetActivosLabBLL(string nombreLab)
        {
            try
            {
                var resultado = _laboratorioDALSQL.GetActivosLab(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetCantActivosLabBLL(string nombreLab)
        {
            try
            {
                var resultado = _laboratorioDALSQL.GetCantActivosLab(nombreLab);

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<string> GetFacilidadesLaboratorioBLL(string nombreLab)
        {
            try
            {
                var resultado = _laboratorioDALSQL.GetFacilidadesLaboratorio(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Horario> GetHorarioOcupadoBLL(string nombreLab)
        {
            try
            {
                var resultado = _laboratorioDALSQL.GetHorarioOcupado(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<LaboratorioDTO> GetLabInfoBLL(string nombreLab)
        {
            try
            {
                var resultado = _laboratorioDALSQL.GetLabInfo(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void ModificarCapacidadBLL(string nombreLab, int capacidad)
        {
            try
            {
                _laboratorioDALSQL.ModificarCapacidad(nombreLab, capacidad);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarComputadoresBLL(string nombreLab, int computadores)
        {
            try
            {
                _laboratorioDALSQL.ModificarComputadores(nombreLab, computadores);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
