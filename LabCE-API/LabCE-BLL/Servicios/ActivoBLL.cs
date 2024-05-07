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
    public class ActivoBLL : IActivoBLL
    {
        private readonly IConfiguration _configuration;
        private readonly ActivoDALSQL _activoDALSQL;
        public ActivoBLL(IConfiguration configuration, ActivoDALSQL activoDALSQL)
        {
            _configuration = configuration;
            _activoDALSQL = activoDALSQL;
        }

        public List<ActivoDTO> GetActivosDisponiblesBLL()
        {
            try
            {
                var resultado = _activoDALSQL.GetActivosDisponibles();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ActivoEnPrestamoDTO> GetActivosEnPrestamoBLL()
        {
            try
            {
                var resultado = _activoDALSQL.GetActivosEnPrestamo();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ActivoInfoDTO> GetActivosInfoBLL()
        {
            try
            {
                var resultado = _activoDALSQL.GetActivosInfo();

                if (resultado == null)
                    return null;

                return resultado;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarFechaCompraBLL(string placa, string fecha)
        {
            try
            {
                _activoDALSQL.ModificarFechaCompra(placa, fecha);
            }
            catch
            {
                throw;
            }
        }

        public void ModificarMarcaBLL(string placa, string nuevaMarca)
        {
            try
            {
                _activoDALSQL.ModificarTipo(placa, nuevaMarca);
            }
            catch
            {
                throw;
            }
        }

        public void ModificarPlacaBLL(string placaActual, string placaNueva)
        {
            try
            {
                _activoDALSQL.ModificarPlaca(placaActual, placaNueva);
            }
            catch
            {
                throw;
            }
        }

        public void ModificarTipoBLL(string placa, string nuevoTipo)
        {
            try
            {
                _activoDALSQL.ModificarTipo(placa, nuevoTipo);
            }
            catch
            {
                throw;
            }
        }
    }
}
