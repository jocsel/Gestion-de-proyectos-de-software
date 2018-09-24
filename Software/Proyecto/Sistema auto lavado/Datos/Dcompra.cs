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
    public class Dcompra
    {
        public List<Ecompra> obtenerlistacompra()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getcompra";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<Ecompra> listaventa = new List<Ecompra>();
                while (leer.Read())
                {
                    Ecompra nuevaFila = new Ecompra();
                    nuevaFila.Idcompra = leer.GetInt32(0);

                    nuevaFila.Proveedor.idProveedor = leer.GetInt32(1);

                    if (leer.IsDBNull(2))
                        nuevaFila.FechaFactura = null;
                    else
                        nuevaFila.FechaFactura = leer.GetDateTime(2);

                    if (leer.IsDBNull(3))
                        nuevaFila.TotalCordobas = null;
                    else
                        nuevaFila.TotalCordobas = leer.GetDecimal(3);

                    nuevaFila.Usuario.idUsuario = leer.GetInt32(4);

                    if (leer.IsDBNull(5))
                        nuevaFila.Tipopago = null;
                    else
                        nuevaFila.Tipopago = leer.GetString(5);

                    if (leer.IsDBNull(6))
                        nuevaFila.Descuento = null;
                    else
                        nuevaFila.Descuento = leer.GetDecimal(6);

                    if (leer.IsDBNull(7))
                        nuevaFila.Subtotal = null;
                    else
                        nuevaFila.Subtotal = leer.GetDecimal(7);

                    if (leer.IsDBNull(8))
                        nuevaFila.TotalDolares = null;
                    else
                        nuevaFila.TotalDolares = leer.GetDecimal(8);

                    if (leer.IsDBNull(9))
                        nuevaFila.Estado = null;
                    else
                        nuevaFila.Estado = leer.GetString(9);


                    listaventa.Add(nuevaFila);
                }

                return listaventa;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




        public void agregarcompra(Ecompra nuevaventa)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "insertarcompra";
                comando.Parameters.AddWithValue("@IdProveedor", nuevaventa.Proveedor.idProveedor);
                comando.Parameters.AddWithValue("@Idusuario", nuevaventa.Usuario.idUsuario);
                comando.Parameters.AddWithValue("@FechaCompra", nuevaventa.FechaFactura);
                comando.Parameters.AddWithValue("@Estado", nuevaventa.Estado);
                comando.Parameters.AddWithValue("@TotalCordobas", nuevaventa.TotalCordobas);
                comando.Parameters.AddWithValue("@TotalDolares", nuevaventa.TotalDolares);
                comando.Parameters.AddWithValue("@Tipopago", nuevaventa.Tipopago);
                comando.Parameters.AddWithValue("@Descuento", nuevaventa.Descuento);
                comando.Parameters.AddWithValue("@Subtotal", nuevaventa.Subtotal);


                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();

                while (leer.Read())
                {

                    nuevaventa.Idcompra = Convert.ToInt32(leer["id"].ToString());

                }
                leer.Close();
                foreach (EdetalleCompra item in nuevaventa.listadetalle)
                {
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandText = "insertardetallecompra";
                    comando.Parameters.AddWithValue("@idcompra", nuevaventa.Idcompra);
                    comando.Parameters.AddWithValue("@idproducto", item.producto.Codproducto);
                    comando.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    comando.Parameters.AddWithValue("@total", item.Total);
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

        public void modificarestadocompra(Ecompra modificar)
        {
            try
            {

                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "modificarcompra";
                comando.Parameters.AddWithValue("@Numcompra", modificar.Idcompra);
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
