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
    public class DdetalledevolucionCompra
    {

        public List<EdetalledevolucionCOMPRA> obtenerlistadetalle()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "getdetalledevolucioncompra";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<EdetalledevolucionCOMPRA> listadetalle = new List<EdetalledevolucionCOMPRA>();
                while (leer.Read())
                {
                    EdetalledevolucionCOMPRA nuevaFila = new EdetalledevolucionCOMPRA();
                    if (leer.IsDBNull(0))

                        nuevaFila.Cantidad = null;
                    else
                        nuevaFila.Cantidad = leer.GetInt32(0);

                    //venta
                    nuevaFila.Devolucion = new EdevolucionCompra();

                    nuevaFila.Devolucion.idDevolucion = leer.GetInt32(1);


                    //PRODUCTO
                    nuevaFila.producto = new Eproductos();
                    nuevaFila.producto.Codproducto = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        nuevaFila.producto.Producto = null;
                    else
                        nuevaFila.producto.Producto = leer.GetString(3);

                    if (leer.IsDBNull(4))
                        nuevaFila.producto.Precio = null;
                    else
                        nuevaFila.producto.Precio = leer.GetDecimal(4);

                    if (leer.IsDBNull(5))
                        nuevaFila.observacion = null;
                    else
                        nuevaFila.observacion = leer.GetString(5);

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
