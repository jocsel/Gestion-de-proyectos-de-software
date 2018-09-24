using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DVehiculoMantenimiento
    {
        public List<EVehiculoMantenimiento> obtenerVehiculoMan()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vehiculoMantenimiento";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<EVehiculoMantenimiento> listaVehiculoMan = new List<EVehiculoMantenimiento>();
                while (leer.Read())
                {
                    EVehiculoMantenimiento datosVehiculooMan = new EVehiculoMantenimiento();

                    datosVehiculooMan.idVehiculoMantenimiento = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        datosVehiculooMan.vehiculoMantenimiento = null;
                    else
                        datosVehiculooMan.vehiculoMantenimiento = leer.GetString(1);


                    if (leer.IsDBNull(2))
                        datosVehiculooMan.estado = false;
                    else
                        datosVehiculooMan.estado = leer.GetBoolean(2);


                    listaVehiculoMan.Add(datosVehiculooMan);

                }
                return listaVehiculoMan;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(EVehiculoMantenimiento nuevoVehiculoMan)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vehiculoMantenimiento";
                cmd.Parameters.AddWithValue("@vehiculoMantenimiento", nuevoVehiculoMan.vehiculoMantenimiento);
                cmd.Parameters.AddWithValue("@estado", nuevoVehiculoMan.estado);
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



        public void Modificar(EVehiculoMantenimiento ModHehiculoMan)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_vehiculoMantenimiento";
                cmd.Parameters.AddWithValue("@idVehiculoMantenimiento", ModHehiculoMan.idVehiculoMantenimiento);
                cmd.Parameters.AddWithValue("@vehiculoMantenimiento", ModHehiculoMan.vehiculoMantenimiento);
                cmd.Parameters.AddWithValue("@estado", ModHehiculoMan.estado);
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
