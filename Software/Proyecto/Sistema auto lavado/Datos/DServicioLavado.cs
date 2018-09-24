using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DServicioLavado
    {
        public List<EServicioLavado> SelectRow() {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_servicioLavado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "S";
                cmd.Connection = conex;
                conex.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EServicioLavado> listarServicio = new List<EServicioLavado>();
                while (leer.Read())
                {
                    EServicioLavado lista = new EServicioLavado();
                    lista.idServicioLavado = leer.GetInt32(0);
                    if (leer.IsDBNull(1))
                        lista.servicioLavado = null;
                    else
                        lista.servicioLavado = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        lista.estado = false;
                    else
                        lista.estado = leer.GetBoolean(2);
                    listarServicio.Add(lista);
                }
                return listarServicio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertRow(EServicioLavado ISL)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_servicioLavado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "I";
                cmd.Parameters.AddWithValue("@i_servicioLavado", ISL.servicioLavado);
                cmd.Parameters.AddWithValue("@i_estado", ISL.estado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void UpdateRow(EServicioLavado USL)
        {
            try
            {
                SqlConnection conex = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Ingenieria..sp_servicioLavado";
                cmd.Parameters.Add("@i_operacion", SqlDbType.Char, 1).Value = "U";
                cmd.Parameters.AddWithValue("@idServicioLavado", USL.idServicioLavado);
                cmd.Parameters.AddWithValue("@i_servicioLavado", USL.servicioLavado);
                cmd.Parameters.AddWithValue("@i_estado", USL.estado);
                cmd.Connection = conex;
                conex.Open();
                cmd.ExecuteNonQuery();
                conex.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
  }

