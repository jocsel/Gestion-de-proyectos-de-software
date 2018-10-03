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

  
    public partial class AuditoriaVenta : Form
    {
        List<EauditoriaVenta> listaventas;
        public AuditoriaVenta()
        {
            InitializeComponent();
        }

        private void ActualizarLista()
        {
            Nauditoriaventa listam = new Nauditoriaventa();
            listaventas = listam.Obtenerauditoriaventa();

            var lista = (from auditoriaventa in listaventas
                         select new
                         {
                             
                             Numventa = auditoriaventa.Num_venta,
                             auditoriaventa.Cliente.idCliente,
                             auditoriaventa.Usuario.idUsuario,
                             auditoriaventa.FechaFactura,
                             auditoriaventa.Tipopago,
                             auditoriaventa.Estado,
                             auditoriaventa.Descuento,
                             auditoriaventa.Subtotal,
                             auditoriaventa.TotalCordobas,
                             auditoriaventa.TotalDolares,
                             Realizado_Por = auditoriaventa.NombreAuditoria,
                             auditoriaventa.fechaCreada,                      
                             auditoriaventa.fechaModificado,
                             auditoriaventa.accion,
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
                var resultado = (
                from auditoriaventa in listaventas
                where auditoriaventa.Estado.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    Numventa = auditoriaventa.Num_venta,
                    auditoriaventa.Cliente.idCliente,
                    auditoriaventa.Usuario.idUsuario,
                    auditoriaventa.FechaFactura,
                    auditoriaventa.Tipopago,
                    auditoriaventa.Estado,
                    auditoriaventa.Descuento,
                    auditoriaventa.Subtotal,
                    auditoriaventa.TotalCordobas,
                    auditoriaventa.TotalDolares,
                    Realizado_Por = auditoriaventa.NombreAuditoria,
                    auditoriaventa.fechaCreada,
                    auditoriaventa.fechaModificado,
                    auditoriaventa.accion,

                }).ToList();
                dgvAuditoriaventa.DataSource = resultado;
          

            }


            if (rbventas.Checked)
            {
                var resultado = (
                from auditoriaventa in listaventas
                where auditoriaventa.Num_venta.ToString().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    Numventa = auditoriaventa.Num_venta,
                    auditoriaventa.Cliente.idCliente,
                    auditoriaventa.Usuario.idUsuario,
                    auditoriaventa.FechaFactura,
                    auditoriaventa.Tipopago,
                    auditoriaventa.Estado,
                    auditoriaventa.Descuento,
                    auditoriaventa.Subtotal,
                    auditoriaventa.TotalCordobas,
                    auditoriaventa.TotalDolares,
                    Realizado_Por = auditoriaventa.NombreAuditoria,
                    auditoriaventa.fechaCreada,
                    auditoriaventa.fechaModificado,
                    auditoriaventa.accion,

                }).ToList();
                dgvAuditoriaventa.DataSource = resultado;


            }


            if (rbempleado.Checked)
            {
                var resultado = (
                from auditoriaventa in listaventas
                where auditoriaventa.NombreAuditoria.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    Numventa = auditoriaventa.Num_venta,
                    auditoriaventa.Cliente.idCliente,
                    auditoriaventa.Usuario.idUsuario,
                    auditoriaventa.FechaFactura,
                    auditoriaventa.Tipopago,
                    auditoriaventa.Estado,
                    auditoriaventa.Descuento,
                    auditoriaventa.Subtotal,
                    auditoriaventa.TotalCordobas,
                    auditoriaventa.TotalDolares,
                    Realizado_Por = auditoriaventa.NombreAuditoria,
                    auditoriaventa.fechaCreada,
                    auditoriaventa.fechaModificado,
                    auditoriaventa.accion,

                }).ToList();
                dgvAuditoriaventa.DataSource = resultado;


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
