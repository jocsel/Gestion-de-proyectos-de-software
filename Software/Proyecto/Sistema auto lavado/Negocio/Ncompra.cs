using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
    public class Ncompra
    {
        public List<Ecompra> obtenerlistventa()
        {

            try
            {
                Dcompra datos = new Dcompra();
                return datos.obtenerlistacompra();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregarcompra(Ecompra nuevacompra)
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

                Dcompra gestion = new Dcompra();
                gestion.agregarcompra(nuevacompra);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarestado(Ecompra modificar)
        {
            try
            {


                if (modificar.Estado.Length == 0)
                    throw new ArgumentException("Ingrese el estado del producto");

                Dcompra gestion = new Dcompra();
                gestion.modificarestadocompra(modificar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
