using LabCE_BLL.Interfaces;
using LabCE_DALSQL;
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
    }
}
