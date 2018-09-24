using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Datos;
using System.Threading.Tasks;

namespace Negocio
{
   public class Ndevolucion
    {
        public List<Edevolucion> obtenerlistdevolucion()
        {

            try
            {
                Ddevolucion datos = new Ddevolucion();
                return datos.obtenerlistadevolucion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregardevolucion(Edevolucion nuevadevolucion)
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

                Ddevolucion gestion = new Ddevolucion();
                gestion.agregardevolucon(nuevadevolucion);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
