using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DServicioMantenimiento
    {
        public List<EServicioMantenimiento> obtenerlistaSericioM()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_serviciomantenimiento";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EServicioMantenimiento> listaServicioM = new List<EServicioMantenimiento>();
                while (leer.Read())
                {
                    EServicioMantenimiento datosServicioM = new EServicioMantenimiento();

                    datosServicioM.idServicioMantenimiento = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        datosServicioM.servicioMantenimiento = null;
                    else
                        datosServicioM.servicioMantenimiento = leer.GetString(1);


                    if (leer.IsDBNull(2))
                        datosServicioM.estado = false;
                    else
                        datosServicioM.estado = leer.GetBoolean(2);


                    listaServicioM.Add(datosServicioM);

                }
                return listaServicioM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(EServicioMantenimiento nuevoServicioM)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_serviciomantenimiento";
                cmd.Parameters.AddWithValue("@servicioMantenimiento", nuevoServicioM.servicioMantenimiento);
                cmd.Parameters.AddWithValue("@estado", nuevoServicioM.estado);
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "I";
                cmd.Connection = conexion;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public void Modificar(EServicioMantenimiento ModServicioM)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_serviciomantenimiento";
                cmd.Parameters.AddWithValue("@idServicioMantenimiento", ModServicioM.idServicioMantenimiento);
                cmd.Parameters.AddWithValue("@servicioMantenimiento", ModServicioM.servicioMantenimiento);
                cmd.Parameters.AddWithValue("@estado", ModServicioM.estado);
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "U";
                cmd.Connection = conexion;
                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    

    }
}
