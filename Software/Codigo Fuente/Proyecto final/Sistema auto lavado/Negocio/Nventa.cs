using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Nventa
    {

        public List<Eventa> obtenerlistventa()
        {

            try
            {
                Dventa datosventa = new Dventa();
                return datosventa.obtenerlistaventa();
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
                //if
                //    (nuevaventa.cliente.id_cliente == 0)
                //    throw new ArgumentException("Ingrese datos de cliente");
                //if (nuevaventa.cliente.nombre.Length == 0)
                //    throw new ArgumentException("Ingrese datos del cliente");
                //if (nuevaventa.usuario.idusuario ==0)
                //    throw new ArgumentException("Ingrese datos del usuario");
                //if (nuevaventa.usuario.nombre.Length == 0)
                //    throw new ArgumentException("Ingrese el nombre");
                ////if (nuevaventa.cantidad.Length == 0)
                ////    throw new ArgumentException("Ingrese la cantidad");
                ////if (nuevaventa.descripcion.Length == 0)
                ////    throw new ArgumentException("Ingrese la descripcion");

                Dventa gestionventa = new Dventa();
                gestionventa.agregarventa(nuevaventa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarestado(Eventa modificar)
        {
            try
            {


                if (modificar.Estado.Length == 0)
                    throw new ArgumentException("Ingrese el estado del producto");

                Dventa gestion = new Dventa();
                gestion.modificarestadoventa(modificar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    }
