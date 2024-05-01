using LabCE_MODEL.DTOs;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LabCE_DALSQL.Seguridad
{
    public class SeguridadDALSQL
    {
        private readonly IConfiguration _configuration;

        public SeguridadDALSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IngresoOperador(UsuarioDTO usuario)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[login_operador]";

            bool existe = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                        comando.Parameters.Add("@password", SqlDbType.VarChar).Value = usuario.Contraseña;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            if (respuesta.Read())
                                existe = true;
                            else
                                existe = false;
                        }
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
            return existe;
        }

        public bool IngresoAdministrador(UsuarioDTO usuario)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[login_administrador]";

            bool existe = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                        comando.Parameters.Add("@password", SqlDbType.VarChar).Value = usuario.Contraseña;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            if (respuesta.Read())
                                existe = true;
                            else
                                existe = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        public bool IngresoProfesor(UsuarioDTO usuario)
        {
            string baseDatos = _configuration.GetConnectionString("default");
            string procedAlmacenado = "[login_profesor]";

            bool existe = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(baseDatos))
                {
                    conexion.Open();
                    using (SqlCommand comando = new SqlCommand(procedAlmacenado, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = usuario.Correo;
                        comando.Parameters.Add("@password", SqlDbType.VarChar).Value = usuario.Contraseña;

                        using (IDataReader respuesta = comando.ExecuteReader())
                        {
                            if (respuesta.Read())
                                existe = true;
                            else
                                existe = false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }


    }
}
