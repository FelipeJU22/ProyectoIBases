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
    public class SolicitudActivoBLL : ISolicitudActivoBLL
    {
        private readonly IConfiguration _configuration;
        private readonly SolicitudActivoDALSQL _solicitudActivoDALSQL;

        public SolicitudActivoBLL(IConfiguration configuration, SolicitudActivoDALSQL solicitudActivoDALSQL)
        {
            _configuration = configuration;
            _solicitudActivoDALSQL = solicitudActivoDALSQL;
        }

        public void AgregarSolicitudActivoBLL(SolicitudActivoDTO solicitud)
        {
            try
            {
                _solicitudActivoDALSQL.AgregarSolicitudActivo(solicitud);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AprobarSolicitudActivoIdBLL(int id, string placa)
        {
            try
            {
                _solicitudActivoDALSQL.AprobarSolicitudActivoId(id, placa);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void EliminarSolicitudActivoIdBLL(int id)
        {
            try
            {
                _solicitudActivoDALSQL.EliminarSolicitudActivoId(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void FinalizarPrestamoBLL(int id, string placa)
        {
            try
            {
                _solicitudActivoDALSQL.FinalizarPrestamo(id, placa);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PrestamoActivoDTO> GetPrestamosActivoBLL(string placa)
        {
            try
            {
                var resultado = _solicitudActivoDALSQL.GetPrestamosActivo(placa);

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
