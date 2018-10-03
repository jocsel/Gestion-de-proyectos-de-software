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
    public class Dauditoriaventa
    {
        public List<EauditoriaVenta> obtenerlistaauditoriaventa()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "Sp_Auditoriaventa";
                comando.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = comando.ExecuteReader();
                List<EauditoriaVenta> listaditoriaventa = new List<EauditoriaVenta>();
                while (leer.Read())
                {
                    EauditoriaVenta nuevaFila = new EauditoriaVenta();
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

                    if (leer.IsDBNull(10))
                        nuevaFila.NombreAuditoria = null;
                    else
                        nuevaFila.NombreAuditoria = leer.GetString(10);

                    if (leer.IsDBNull(11))
                        nuevaFila.fechaCreada = null;
                    else
                        nuevaFila.fechaCreada = leer.GetDateTime(11);
                    if (leer.IsDBNull(12))
                        nuevaFila.fechaModificado = null;
                    else
                        nuevaFila.fechaModificado = leer.GetDateTime(12);

                    if (leer.IsDBNull(13))
                        nuevaFila.accion = null;
                    else
                        nuevaFila.accion = leer.GetString(13);




                    listaditoriaventa.Add(nuevaFila);
                }

                return listaditoriaventa;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



    }
}
