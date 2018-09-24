using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class Nalmacen
    {
        public List<Ealmacen> obtenerlistalmacen()

        {
            try
            {
                Dalmacen datosalmacen = new Dalmacen();
                return datosalmacen.obtenerlistaalmacen();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Ealmacen nuevo)
        {
            try
            {
                if (nuevo.Categoria.CodCategoria == 0)
                    throw new ArgumentException("Ingrese el codigo de la categoria");
                if (nuevo.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese el nombre del almacen");
                if (nuevo.Ubicacion.Length == 0)
                    throw new ArgumentException("Ingrese la ubicacion del almacen");
                if (nuevo.Descripcion.Length == 0)
                    throw new ArgumentException("Ingrese una descripcion del almacen");
                if (nuevo.NombreCategoria.Length == 0)
                    throw new ArgumentException("Ingrese el nombre de la categoria");
            
           
                Dalmacen gestion = new Dalmacen();
                gestion.agregaralmacen(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Ealmacen modificar)
        {
            try
            {

                if (modificar.Categoria.CodCategoria == 0)
                    throw new ArgumentException("Ingrese el codigo de la categoria");
                if (modificar.Nombre.Length == 0)
                    throw new ArgumentException("Ingrese el nombre del almacen");
                if (modificar.Ubicacion.Length == 0)
                    throw new ArgumentException("Ingrese la ubicacion del almacen");
                if (modificar.Descripcion.Length == 0)
                    throw new ArgumentException("Ingrese una descripcion del almacen");
                if (modificar.NombreCategoria.Length == 0)
                    throw new ArgumentException("Ingrese el nombre de la categoria");

                Dalmacen gestion = new Dalmacen();
                gestion.modificaralmacen(modificar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
