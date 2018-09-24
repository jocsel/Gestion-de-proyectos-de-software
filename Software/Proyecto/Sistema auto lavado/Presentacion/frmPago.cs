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
    public partial class frmPago : Form
    {
        public List<EPago> listaPago;
        bool modificar;
        public frmPago()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void Deshabilitar()
        {
            txtCordobas.Enabled = false;
            txtDolares.Enabled = false;
            txtMontoFac.Enabled = false;
            txtNumeroDocumento.Enabled = false;
            txtVuelto.Enabled = false;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
        }
        private void Habilitar()
        {
            txtCordobas.Enabled = true;
            txtDolares.Enabled = true;
            txtMontoFac.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            txtVuelto.Enabled = true;
        }

        private void Limpiar()
        {

            txtCordobas.Text = "";
            txtDolares.Text = "";
            txtMontoFac.Text = "";
            txtNumeroDocumento.Text = "";
            txtVuelto.Text = "";
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
        public void actualizarGrid()
        {

            try
            {
                NPago listar = new NPago();
                listaPago = listar.SelectRow();
                var lista = (from pago in listaPago
                             select new
                             {
                                 pago.numeroDocumento,
                                 pago.cordobas,
                                 pago.dolares,
                                 pago.vuelto,
                                 pago.fecha,
                                 pago.montoFactura,
                                 pago.EUsuario.idUsuario,
                                 pago.EUsuario.usuario,
                                 pago.EEmpleado.nombres,
                             }).ToList();
                dgvLavado.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmPago_Load(object sender, EventArgs e)
        {
            btncancelar.Enabled = false;
            lblusuario.Text = Convert.ToString(Global.usuarioSesion.Permiso.PidUsuario);
            try
            {

                actualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {

                }
                else
                {
                    EPago Ipago = new EPago();
                    Ipago.numeroDocumento = Convert.ToInt32(txtNumeroDocumento.Text);
                    Ipago.fecha = Convert.ToDateTime(dateTimePicker1.Text);
                    Ipago.cordobas = Convert.ToDecimal(txtCordobas.Text);
                    Ipago.dolares = Convert.ToDecimal(txtDolares.Text);
                    Ipago.vuelto = Convert.ToDecimal(txtVuelto.Text);
                    Ipago.montoFactura = Convert.ToDecimal(txtMontoFac.Text);
                    Ipago.EUsuario.idUsuario = Convert.ToInt32(lblusuario.Text);
                    NPago iP = new NPago();
                    iP.InsertRow(Ipago);
                    MessageBox.Show("Guardado");
                }
                actualizarGrid();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            btncancelar.Enabled = false;
        }

        private void lblusuario_Click(object sender, EventArgs e)
        {

        }
    }
}
