using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;


namespace Negocio
{
   public class Nproductos
    {
        public List<Eproductos> obtenerlistproducto()

        {
            try
            {
                Dproductos datosproducto = new Dproductos();
                return datosproducto.obtenerlistaproducto();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Eproductos nuevo)
        {
            try
            {

                if (nuevo.Producto.Length == 0)
                    throw new ArgumentException("Ingrese el nombre");
                if (nuevo.Marca.Codmarca  == 0)
                    throw new ArgumentException("Ingrese la marca");
                if (nuevo.CodSac.Length == 0)
                    throw new ArgumentException("Ingrese el CodSAC");
                if (nuevo.Existencia.Value == 0)
                    throw new ArgumentException("Ingrese la cantidad de productos");
                if (nuevo.Costo.Value == 0)
                    throw new ArgumentException("Ingrese el precio de venta");
                if (nuevo.Precio.Value == 0)
                    throw new ArgumentException("Ingrese el precio de compra");
                if (nuevo.Activo == null)
                    throw new ArgumentException("Ingrese el Estado");

                Dproductos gestion = new Dproductos();
                gestion.agregarProducto(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Eproductos modificar)
        {
            try
            {

                if (modificar.Producto.Length == 0)
                    throw new ArgumentException("Ingrese el nombre");
                if (modificar.Marca.Codmarca == 0)
                    throw new ArgumentException("Ingrese la marca");
                if (modificar.Existencia == 0)
                    throw new ArgumentException("Ingrese la cantidad");
                if (modificar.Costo == 0)
                    throw new ArgumentException("Ingrese el precio de venta");
                if (modificar.Precio == 0)
                    throw new ArgumentException("Ingrese el precio de compra");
                if (modificar.Activo == null)
                    throw new ArgumentException("Ingrese el Estado");

                Dproductos gestion = new Dproductos();
                gestion.modificarproducto(modificar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
