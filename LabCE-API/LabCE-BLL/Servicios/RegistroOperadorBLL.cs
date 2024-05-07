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
    public class RegistroOperadorBLL : IRegistroOperadorBLL
    {
        private readonly IConfiguration _configuration;
        private readonly RegistroOperadorDALSQL _registroOperadorDALSQL;

        public RegistroOperadorBLL(IConfiguration configuration, RegistroOperadorDALSQL registroOperadorDALSQL)
        {
            _configuration = configuration;
            _registroOperadorDALSQL = registroOperadorDALSQL;
        }
        public List<RegistroHorasDTO> GetReporteHorasBLL(string correoOperador)
        {
            try
            {
                var resultado = _registroOperadorDALSQL.GetReporteHoras(correoOperador);

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void InsertarJornadaBLL(OperadorDTO operador)
        {
            try
            {
                _registroOperadorDALSQL.InsertarJornada(operador);
            }
            catch
            {
                throw;
            }
        }
    }
}
