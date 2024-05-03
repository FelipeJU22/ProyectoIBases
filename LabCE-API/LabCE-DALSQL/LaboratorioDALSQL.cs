using AutoMapper;
using LabCE_MODEL.DTOs;
using LabCE_MODEL.Modelos;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Data.SqlTypes;

namespace LabCE_DALSQL
{
    public class LaboratorioDALSQL
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LaboratorioDALSQL(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public List<string> GetFacilidadesLaboratorio(string nombreLab) 
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_facilidades]";

            var facilidades = new List<string>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                Facilidad facilidad = new Facilidad()
                                {
                                    NombreFacilidad = respuesta["facilidad"].ToString(),
                                };
                                facilidades.Add(facilidad.NombreFacilidad);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return facilidades;

        }

        public List<Horario> GetHorarioOcupado(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[horario_ocupado]";

            var horarios = new List<Horario>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                Horario horario = new Horario()
                                {
                                    Fecha = Convert.ToDateTime(respuesta["fecha"]).ToString("yyyy-MM-dd"),
                                    HoraApertura = DateTime.Today.Add((TimeSpan)respuesta["hora_inicio"]).ToString("HH:mm:ss"),
                                    HoraCierre = DateTime.Today.Add((TimeSpan)respuesta["hora_final"]).ToString("HH:mm:ss")
                                };
                                horarios.Add(horario);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return horarios;

        }

        public List<LaboratorioDTO> GetLabInfo(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[info_lab]";

            var laboratorios = new List<Laboratorio>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                Laboratorio laboratorio = new Laboratorio()
                                {
                                    Capacidad = Convert.ToInt32(respuesta["capacidad"]),
                                    Computadores = Convert.ToInt32(respuesta["computadores"]),
                                };
                                laboratorios.Add(laboratorio);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            List<LaboratorioDTO> laboratorioDTOs = laboratorios.Select(p => _mapper.Map<LaboratorioDTO>(p)).ToList();

            return laboratorioDTOs;

        }

        public void ApartarLaboratorioProfesor(ApartadoLaboratorioDTO apartado)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[apartado_laboratorio_profesor]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo_profesor", SqlDbType.VarChar).Value = apartado.CorreoProfesor;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = apartado.NombreLab;
                        comando.Parameters.Add(new SqlParameter("@fecha", DateTime.Parse(apartado.Fecha)));
                        comando.Parameters.Add(new SqlParameter("@hora_inicio", TimeSpan.Parse(apartado.HoraInicio)));
                        comando.Parameters.Add(new SqlParameter("@hora_final", TimeSpan.Parse(apartado.HoraFinal)));

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ActivoLabDTO> GetActivosLab(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_activos_lab]";

            var activos = new List<ActivoLabDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                ActivoLabDTO activo= new ActivoLabDTO()
                                {
                                    Placa = respuesta["placa"].ToString(),
                                    Tipo = respuesta["tipo"].ToString()
                                };
                                activos.Add(activo);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return activos;

        }

        public int GetCantActivosLab(string nombreLab)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[mostrar_cantidad_activos_lab]";

            int cantidad = new Int32();
            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            while (respuesta.Read())
                            {
                                cantidad = Convert.ToInt32(respuesta[0]);
                            
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return cantidad;
        }
        public void CambiarNombreLab(string nombreActual, string nombreNuevo)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_nombre_lab]";


            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab_viejo", SqlDbType.VarChar).Value = nombreActual;
                        comando.Parameters.Add("@nombre_lab_nuevo ", SqlDbType.VarChar).Value = nombreNuevo;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarCapacidad(string nombreLab, int capacidad)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_capacidad_lab]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;
                        comando.Parameters.Add("@capacidad", SqlDbType.Int).Value = capacidad;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarComputadores(string nombreLab, int computadores)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[modificar_computadores_lab]";

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();

                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@nombre_lab", SqlDbType.VarChar).Value = nombreLab;
                        comando.Parameters.Add("@computadores", SqlDbType.Int).Value = computadores;

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
