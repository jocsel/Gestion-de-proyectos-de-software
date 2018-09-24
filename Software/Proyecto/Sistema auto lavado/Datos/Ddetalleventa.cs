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
    public class Ddetalleventa
    {

        public List<Edetalleventa> obtenerlistadetalle()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getdetalleventa";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<Edetalleventa> listadetalle = new List<Edetalleventa>();
                while (leer.Read())
                {
                    Edetalleventa nuevaFila = new Edetalleventa();

                    if (leer.IsDBNull(0))
                        nuevaFila.Cantidad = null;
                    else
                        nuevaFila.Cantidad = leer.GetInt32(0);
            
                    //venta
                    nuevaFila.Venta = new Eventa();
                    nuevaFila.Venta.Num_venta = leer.GetInt32(1);
                    if (leer.IsDBNull(2))
                        nuevaFila.Venta.TotalCordobas = null;
                    else
                        nuevaFila.Venta.TotalCordobas = leer.GetDecimal(2);

                    //PRODUCTO
                    nuevaFila.producto = new Eproductos();
                    nuevaFila.producto.Codproducto = leer.GetInt32(3);

                    if (leer.IsDBNull(4))
                        nuevaFila.producto.Producto = null;
                    else
                        nuevaFila.producto.Producto = leer.GetString(4);

                    if (leer.IsDBNull(5))
                        nuevaFila.producto.Precio = null;
                    else
                        nuevaFila.producto.Precio = leer.GetDecimal(5);

                    if (leer.IsDBNull(6))
                        nuevaFila.Totaldetalle = null;
                    else
                        nuevaFila.Totaldetalle = leer.GetDecimal(6);
                   

                    listadetalle.Add(nuevaFila);
                }
                conexion.Close();
                leer.Close();
                return listadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Edetalleventa> obtenerlistadetallex()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getdetalleventax";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<Edetalleventa> listadetalle = new List<Edetalleventa>();
                while (leer.Read())
                {
                    Edetalleventa nuevaFila = new Edetalleventa();

                    if (leer.IsDBNull(0))
                        nuevaFila.Cantidad = null;
                    else
                        nuevaFila.Cantidad = leer.GetInt32(0);

                    //venta
                    nuevaFila.Venta = new Eventa();
                    nuevaFila.Venta.Num_venta = leer.GetInt32(1);
                    if (leer.IsDBNull(2))
                        nuevaFila.Venta.TotalCordobas = null;
                    else
                        nuevaFila.Venta.TotalCordobas = leer.GetDecimal(2);

                    //PRODUCTO
                    nuevaFila.producto = new Eproductos();
                    nuevaFila.producto.Codproducto = leer.GetInt32(3);

                    if (leer.IsDBNull(4))
                        nuevaFila.producto.Producto = null;
                    else
                        nuevaFila.producto.Producto = leer.GetString(4);

                    if (leer.IsDBNull(5))
                        nuevaFila.producto.Precio = null;
                    else
                        nuevaFila.producto.Precio = leer.GetDecimal(5);

                    if (leer.IsDBNull(6))
                        nuevaFila.Totaldetalle = null;
                    else
                        nuevaFila.Totaldetalle = leer.GetDecimal(6);


                    listadetalle.Add(nuevaFila);
                }
                conexion.Close();
                leer.Close();
                return listadetalle;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
