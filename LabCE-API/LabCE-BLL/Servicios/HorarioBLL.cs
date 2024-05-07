using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCE_BLL.Servicios
{
    public class HorarioBLL : IHorarioBLL
    {
        private readonly IConfiguration _configuration;
        private readonly HorarioDALSQL _horarioDALSQL;

        public HorarioBLL(IConfiguration configuration, HorarioDALSQL horarioDALSQL)
        {
            _configuration = configuration;
            _horarioDALSQL = horarioDALSQL;
        }

        public void CambiarHorarioLabBLL(string nombreLab, char dia, string horaApertura, string horaCierre)
        {
            try
            {
                _horarioDALSQL.CambiarHorarioLab(nombreLab, dia, horaApertura, horaCierre);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<HorarioLabDTO> GetHorarioLabBLL(string nombreLab)
        {
            try
            {
                var resultado = _horarioDALSQL.GetHorarioLab(nombreLab);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
