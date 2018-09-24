using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Ncategoria
    {
        public List<Ecategoria> obtenerlistcategoria()
        {
            try
            {

                Dcategoria datosproducto = new Dcategoria();
                return datosproducto.obtenerlistacategoria();

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


        public void agregarcategoria(Ecategoria nuevo)
        {
            try
            {
                if (nuevo.Tipo.Length == 0)
                    throw new ArgumentException("Ingrese el tipo de producto");
                if (nuevo.Producto.Codproducto == 0)
                    throw new ArgumentException("Ingrese el codigo del producto");
                if (nuevo.Nombredelproducto.Length == 0)
                    throw new ArgumentException("Ingrese el nombre del producto");

                Dcategoria gestion = new Dcategoria();
                gestion.agregarcategoria(nuevo);

            }
            catch (Exception)
            {

                throw;
            }




        }

        public void modificarcategoria(Ecategoria modificar)
        {
            try
            {

                if (modificar.Tipo.Length == 0)
                    throw new ArgumentException("Ingrese el tipo de producto");
                if (modificar.Producto.Codproducto == 0)
                    throw new ArgumentException("Ingrese el codigo del producto");
                if (modificar.Nombredelproducto.Length == 0)
                    throw new ArgumentException("Ingrese el nombre del producto");

                Dcategoria gestion = new Dcategoria();
                gestion.modificarcategoria(modificar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
