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
    public class DProveedor
    {
        public List<EProveedor> obtenerlistaProveedor()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_proveedor";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "S";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();

                List<EProveedor> listaProveedor = new List<EProveedor>();
                while (leer.Read())
                {
                    EProveedor datosproveedor = new EProveedor();

                    datosproveedor.idProveedor = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        datosproveedor.nombres = null;
                    else
                        datosproveedor.nombres = leer.GetString(1);
                    if (leer.IsDBNull(2))
                        datosproveedor.apellidos = null;
                    else
                        datosproveedor.apellidos = leer.GetString(2);
                    if (leer.IsDBNull(3))
                        datosproveedor.RUC = null;
                    else
                        datosproveedor.RUC = leer.GetString(3);
                    if (leer.IsDBNull(4))
                        datosproveedor.telefono = null;
                    else
                        datosproveedor.telefono = leer.GetString(4);

                    if (leer.IsDBNull(5))
                        datosproveedor.correo = null;
                    else
                        datosproveedor.correo = leer.GetString(5);

                    if (leer.IsDBNull(6))
                        datosproveedor.direccion = null;
                    else
                        datosproveedor.direccion = leer.GetString(6);
                    if (leer.IsDBNull(7))
                        datosproveedor.estado = false;
                    else
                        datosproveedor.estado = leer.GetBoolean(7);
                    if (leer.IsDBNull(8))
                        datosproveedor.nombreempresa = null;
                    else
                        datosproveedor.nombreempresa = leer.GetString(8);

                    listaProveedor.Add(datosproveedor);

                }
                return listaProveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public void Agregar(EProveedor nuevoproveedor)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_proveedor";
                cmd.Parameters.AddWithValue("@nombres", nuevoproveedor.nombres);
                cmd.Parameters.AddWithValue("@apellidos", nuevoproveedor.apellidos);
                cmd.Parameters.AddWithValue("@RUC", nuevoproveedor.RUC);
                cmd.Parameters.AddWithValue("@telefono", nuevoproveedor.telefono);
                cmd.Parameters.AddWithValue("@correo", nuevoproveedor.correo);
                cmd.Parameters.AddWithValue("@direccion", nuevoproveedor.direccion);
                cmd.Parameters.AddWithValue("@estado", nuevoproveedor.estado);
                cmd.Parameters.AddWithValue("@nombreempresa", nuevoproveedor.nombreempresa);
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

        public void Modificar(EProveedor ModificarProveedor)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_proveedor";
                cmd.Parameters.AddWithValue("@idProveedor", ModificarProveedor.idProveedor);
                cmd.Parameters.AddWithValue("@nombres", ModificarProveedor.nombres);
                cmd.Parameters.AddWithValue("@apellidos", ModificarProveedor.apellidos);
                cmd.Parameters.AddWithValue("@RUC", ModificarProveedor.RUC);
                cmd.Parameters.AddWithValue("@telefono", ModificarProveedor.telefono);
                cmd.Parameters.AddWithValue("@correo", ModificarProveedor.correo);
                cmd.Parameters.AddWithValue("@direccion", ModificarProveedor.direccion);
                cmd.Parameters.AddWithValue("@estado", ModificarProveedor.estado);
                cmd.Parameters.AddWithValue("@nombreempresa", ModificarProveedor.nombreempresa);
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

