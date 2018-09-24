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
    public class Dinactivo_cancelada
    {

        public List<Eventa> obtenerlistaventaANULADAS()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "sp_Inactivo";
                comando.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "v";
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

        public List<ECliente> obtenerlistaclienteINACTIVA()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Inactivo";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "c";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<ECliente> listacliente = new List<ECliente>();
                while (leer.Read())
                {
                    ECliente nuevafila = new ECliente();

                    nuevafila.idCliente = leer.GetInt32(0);


                    if (leer.IsDBNull(1))
                        nuevafila.nombres = null;
                    else
                        nuevafila.nombres = leer.GetString(1);

                    if (leer.IsDBNull(2))
                        nuevafila.apellido = null;
                    else
                        nuevafila.apellido = leer.GetString(2);

                    if (leer.IsDBNull(3))
                        nuevafila.correo = null;
                    else
                        nuevafila.correo = leer.GetString(3);

                    if (leer.IsDBNull(4))
                        nuevafila.celular = null;
                    else
                        nuevafila.celular = leer.GetInt32(4);

                    if (leer.IsDBNull(5))
                        nuevafila.estado = null;
                    else
                        nuevafila.estado = leer.GetString(5);

                    listacliente.Add(nuevafila);
                }
                return listacliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Eproductos> obtenerlistaproductoINACTIVO()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Properties.Settings.Default.cadenaConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Inactivo";
                cmd.Parameters.Add("@i_operacion", SqlDbType.VarChar, 1).Value = "p";
                cmd.Connection = conexion;
                conexion.Open();
                SqlDataReader leer = cmd.ExecuteReader();
                List<Eproductos> listap = new List<Eproductos>();
                while (leer.Read())
                {
                    Eproductos nuevafila = new Eproductos();

                    nuevafila.Codproducto = leer.GetInt32(0);

                    if (leer.IsDBNull(1))
                        nuevafila.Producto = null;
                    else
                        nuevafila.Producto = leer.GetString(1);

                    nuevafila.Marca.Codmarca = leer.GetInt32(2);

                    if (leer.IsDBNull(3))
                        nuevafila.CodSac = null;
                    else
                        nuevafila.CodSac = leer.GetString(3);

                    if (leer.IsDBNull(4))
                        nuevafila.Existencia = null;
                    else
                        nuevafila.Existencia = leer.GetInt32(4);

                    if (leer.IsDBNull(5))
                        nuevafila.Costo = null;
                    else
                        nuevafila.Costo = leer.GetDecimal(5);
                    if (leer.IsDBNull(6))
                        nuevafila.Precio = null;
                    else
                        nuevafila.Precio = leer.GetDecimal(6);

                    if (leer.IsDBNull(7))
                        nuevafila.Activo = null;
                    else
                        nuevafila.Activo = leer.GetBoolean(7);


                    listap.Add(nuevafila);
                }
                return listap;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
