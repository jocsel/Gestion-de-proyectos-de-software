using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace Presentacion
{

  
    public partial class FrmAuditoriaCompra : Form
    {
        List<Eauditoriacompra> listacompras;
        public FrmAuditoriaCompra()
        {
            InitializeComponent();
        }

        private void ActualizarLista()
        {
            NauditoriaCompra listam = new NauditoriaCompra();
            listacompras = listam.obtenerlistcompra();

            var lista = (from auditoriacompra in listacompras
                         select new
                         {
                             
                             NumCompra = auditoriacompra.Idcompra,
                             auditoriacompra.Proveedor.idProveedor,
                             auditoriacompra.Usuario.idUsuario,
                             auditoriacompra.FechaFactura,
                             auditoriacompra.Tipopago,
                             auditoriacompra.Estado,
                             auditoriacompra.Descuento,
                             auditoriacompra.Subtotal,
                             auditoriacompra.TotalCordobas,
                             auditoriacompra.TotalDolares,
                             Realizado_Por = auditoriacompra.NombreAuditoria,
                             auditoriacompra.fechaCreada,
                             auditoriacompra.fechaModificado,
                             auditoriacompra.accion,
                         }

                    ).ToList();
            dgvAuditoriaventa.DataSource = lista;

        }
        private void AuditoriaVenta_Load(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void rbestado_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Estado :";
        }

        public void filtrar()
        {

            if (rbestado.Checked)
            {
                var lista = (from auditoriacompra in listacompras
                             where auditoriacompra.Estado.ToUpper().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {

                                 NumCompra = auditoriacompra.Idcompra,
                                 auditoriacompra.Proveedor.idProveedor,
                                 auditoriacompra.Usuario.idUsuario,
                                 auditoriacompra.FechaFactura,
                                 auditoriacompra.Tipopago,
                                 auditoriacompra.Estado,
                                 auditoriacompra.Descuento,
                                 auditoriacompra.Subtotal,
                                 auditoriacompra.TotalCordobas,
                                 auditoriacompra.TotalDolares,
                                 Realizado_Por = auditoriacompra.NombreAuditoria,
                                 auditoriacompra.fechaCreada,
                                 auditoriacompra.fechaModificado,
                                 auditoriacompra.accion,
                             }

                    ).ToList();
                dgvAuditoriaventa.DataSource = lista;


               

            }


            if (rbventas.Checked)
            {
                var lista = (from auditoriacompra in listacompras
                             where auditoriacompra.Idcompra.ToString().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {

                                 NumCompra = auditoriacompra.Idcompra,
                                 auditoriacompra.Proveedor.idProveedor,
                                 auditoriacompra.Usuario.idUsuario,
                                 auditoriacompra.FechaFactura,
                                 auditoriacompra.Tipopago,
                                 auditoriacompra.Estado,
                                 auditoriacompra.Descuento,
                                 auditoriacompra.Subtotal,
                                 auditoriacompra.TotalCordobas,
                                 auditoriacompra.TotalDolares,
                                 Realizado_Por = auditoriacompra.NombreAuditoria,
                                 auditoriacompra.fechaCreada,
                                 auditoriacompra.fechaModificado,
                                 auditoriacompra.accion,
                             }

                 ).ToList();
                dgvAuditoriaventa.DataSource = lista;



             

            }


           




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void rbventas_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Numventa :";
        }

        private void rbempleado_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Empleado :";
        }
    }
}
