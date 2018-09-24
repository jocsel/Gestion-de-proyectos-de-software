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
    public class Dventa
    {
        public List<Eventa> obtenerlistaventa()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getventa";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<Eventa> listaventa = new List<Eventa>();
                while (leer.Read())
                {
                    Eventa nuevaFila = new Eventa();
                    nuevaFila.Num_venta = leer.GetInt32(0);

                    nuevaFila.Cliente.idCliente = leer.GetInt32(1);

                    nuevaFila.Usuario.idUsuario = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        nuevaFila.FechaFactura = null;
                    else
                        nuevaFila.FechaFactura = leer.GetDateTime(3);

                    if (leer.IsDBNull(4))
                        nuevaFila.Tipopago = null;
                    else
                        nuevaFila.Tipopago = leer.GetString(4);

                    if (leer.IsDBNull(5))
                        nuevaFila.Estado = null;
                    else
                        nuevaFila.Estado = leer.GetString(5);

                    if (leer.IsDBNull(6))
                        nuevaFila.Subtotal = null;
                    else
                        nuevaFila.Subtotal = leer.GetDecimal(6);

                    if (leer.IsDBNull(7))
                        nuevaFila.Descuento = null;
                    else
                        nuevaFila.Descuento = leer.GetDecimal(7);
                    
                    if (leer.IsDBNull(8))
                        nuevaFila.TotalCordobas = null;
                    else
                        nuevaFila.TotalCordobas = leer.GetDecimal(8);

                    if (leer.IsDBNull(9))
                        nuevaFila.TotalDolares = null;
                    else
                        nuevaFila.TotalDolares = leer.GetDecimal(9);



                    listaventa.Add(nuevaFila);
                }

                return listaventa;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public void agregarventa(Eventa nuevaventa)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "agregarventa";              
                comando.Parameters.AddWithValue("@I_idcliente", nuevaventa.Cliente.idCliente);
                comando.Parameters.AddWithValue("@Idusuario", nuevaventa.Usuario.idUsuario);
                comando.Parameters.AddWithValue("@fechafactura", nuevaventa.FechaFactura);
              //  comando.Parameters.AddWithValue("@Horafactura", nuevaventa.HoraFactura);
                comando.Parameters.AddWithValue("@tipopago", nuevaventa.Tipopago);
                comando.Parameters.AddWithValue("@Estado", nuevaventa.Estado);
                comando.Parameters.AddWithValue("@Subtotal", nuevaventa.Subtotal);
                comando.Parameters.AddWithValue("@Descuento", nuevaventa.Descuento);
                comando.Parameters.AddWithValue("@totalcordobas", nuevaventa.TotalCordobas);
                comando.Parameters.AddWithValue("@totaldolares", nuevaventa.TotalDolares);
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();

                while (leer.Read())
                {

                    nuevaventa.Num_venta = Convert.ToInt32(leer["id"].ToString());

                }
                leer.Close();
                foreach (Edetalleventa item in nuevaventa.listadetalle)
                {
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "insertar_detalle";
                    comando.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    comando.Parameters.AddWithValue("@idventa", nuevaventa.Num_venta);
                    comando.Parameters.AddWithValue("@idproducto", item.producto.Codproducto);
                    comando.Parameters.AddWithValue("@totaldetalle", item.Totaldetalle);
                    comando.Connection = conexion;
                    comando.ExecuteNonQuery();
                }
                conexion.Close();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void modificarestadoventa(Eventa modificar)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "modificarventa";
                comando.Parameters.AddWithValue("@Numventas", modificar.Num_venta);
                comando.Parameters.AddWithValue("@Estado", modificar.Estado);
                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }


            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
