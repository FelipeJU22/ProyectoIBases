using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class PrestamoLabBLL : IPrestamoLabBLL
    {
        private readonly IConfiguration _configuration;
        private readonly PrestamoLabDALSQL _prestamoLabDALSQL;

        public PrestamoLabBLL(IConfiguration configuration, PrestamoLabDALSQL prestamoLabDALSQL)
        {
            _configuration = configuration;
            _prestamoLabDALSQL = prestamoLabDALSQL;
        }

        public List<PrestamoLabDTO> GetHorariosReservadosLabBLL(string nombreLab)
        {
            try
            {
                var resultado = _prestamoLabDALSQL.GetHorariosReservadosLab(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ReservarLabEstudianteBLL(EstudiantePrestamoLabDTO estudiante)
        {
            try
            {
                _prestamoLabDALSQL.ReservarLabEstudiante(estudiante);
            }
            catch
            {
                throw;
            }
        }
    }
}
