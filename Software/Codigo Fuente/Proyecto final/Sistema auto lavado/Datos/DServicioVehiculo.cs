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
 public class DServicioVehiculo
    {
     public List<EServicioVehiculo> obtenerlistaSericioV()
     {
         try
         {
             SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "sp_ServicioVehiculo";
             cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
             cmd.Connection = conexion;
             conexion.Open();

             SqlDataReader leer = cmd.ExecuteReader();
             List<EServicioVehiculo> listaServicioV = new List<EServicioVehiculo>();
             while (leer.Read())
             {
                 EServicioVehiculo datosServicioV = new EServicioVehiculo();

                 datosServicioV.idServicioVehiculo = leer.GetInt32(0);

                 if (leer.IsDBNull(1))
                     datosServicioV.idServicioMantenimiento.servicioMantenimiento = null;
                 else
                     datosServicioV.idServicioMantenimiento.servicioMantenimiento = leer.GetString(1);

                 if (leer.IsDBNull(2))
                     datosServicioV.idVehiculoMantenimiento.vehiculoMantenimiento = null;
                 else
                     datosServicioV.idVehiculoMantenimiento.vehiculoMantenimiento = leer.GetString(2);
                 if (leer.IsDBNull(3))
                     datosServicioV.precio = null;
                 else
                     datosServicioV.precio = leer.GetDecimal(3);
                 if (leer.IsDBNull(4))
                     datosServicioV.estado = false;
                 else
                     datosServicioV.estado = leer.GetBoolean(4);

                 if (leer.IsDBNull(5))
                     datosServicioV.idServicioMantenimiento.idServicioMantenimiento = null;
                 else
                     datosServicioV.idServicioMantenimiento.idServicioMantenimiento = leer.GetInt32(5);
                 if (leer.IsDBNull(6))
                     datosServicioV.idVehiculoMantenimiento.idVehiculoMantenimiento = null;
                 else
                     datosServicioV.idVehiculoMantenimiento.idVehiculoMantenimiento = leer.GetInt32(6);


                 listaServicioV.Add(datosServicioV);

             }
             return listaServicioV;
         }
         catch (Exception ex)
         {
             throw ex;
         }
     }
     public void Agregar(EServicioVehiculo nuevoSV)
     {

         try
         {
             SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "sp_ServicioVehiculo";
             cmd.Parameters.AddWithValue("@idServicioMantenimiento", nuevoSV.idServicioMantenimiento.idServicioMantenimiento);
             cmd.Parameters.AddWithValue("@idVehiculoMantenimiento", nuevoSV.idVehiculoMantenimiento.idVehiculoMantenimiento);
             cmd.Parameters.AddWithValue("@precio", nuevoSV.precio);
             cmd.Parameters.AddWithValue("@estado", nuevoSV.estado);
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
     public void Modificar(EServicioVehiculo ModServicioV)
     {
         try
         {
             SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "sp_ServicioVehiculo";
             cmd.Parameters.AddWithValue("@idServicioVehiculo", ModServicioV.idServicioVehiculo);
             cmd.Parameters.AddWithValue("@idServicioMantenimiento", ModServicioV.idServicioMantenimiento.idServicioMantenimiento);
             cmd.Parameters.AddWithValue("@idVehiculoMantenimiento", ModServicioV.idVehiculoMantenimiento.idVehiculoMantenimiento);
             cmd.Parameters.AddWithValue("@precio", ModServicioV.precio);
             cmd.Parameters.AddWithValue("@estado", ModServicioV.estado);
             
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
