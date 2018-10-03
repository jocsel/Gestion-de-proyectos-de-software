using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class frmLavadoVehiculo : Form
    {
        public List<ELavadoVehiculo> listavehiculoL;
        bool modificar;
        public frmLavadoVehiculo()
        {
            InitializeComponent();
            Deshabilitar();
            btncancelar.Enabled = false;
            lblServicio.Enabled = false;
            lblVehiculo.Enabled = false;
        }
        private void Deshabilitar()
        {
            txtPrecio.Enabled = false;
            txtServicio.Enabled = false;
            txtVehiculo.Enabled = false;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            
        }

        private void Habilitar()
        {
            txtPrecio.Enabled = true;
            txtServicio.Enabled = true;
            txtVehiculo.Enabled = true;
           
        }

        private void Limpiar()
        {

            txtPrecio.Text = "";
            txtServicio.Text = "";
            txtVehiculo.Text = "";
        }

        public void actualizarGrid() {
            try {
                NLavadoVehiculos listarLV = new NLavadoVehiculos();
                listavehiculoL = listarLV.selectRow();
                var lista = (from lavadoVehiculo in listavehiculoL
                             select new
                             {
                                 lavadoVehiculo.idLavadoVehiculo,
                                 lavadoVehiculo.servicioLavado.idServicioLavado,
                                 lavadoVehiculo.vehiculoLavado.idVehiculoLavado,
                                 lavadoVehiculo.vehiculoLavado.vehiculoLavado,
                                 lavadoVehiculo.servicioLavado.servicioLavado,
                                 lavadoVehiculo.precio,
                             }).ToList();
                dgvLavadoVehiculo.DataSource = lista;
                dgvLavadoVehiculo.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavadoVehiculo.Columns["idServicioLavado"].Visible = false;
                dgvLavadoVehiculo.Columns["idVehiculoLavado"].Visible = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmLavadoVehiculo_Load(object sender, EventArgs e)
        {
            try {
                actualizarGrid();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        
            this.Close();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
            lblServicio.Enabled = true;
            lblVehiculo.Enabled = true;
            txtServicio.Enabled = false;
            txtVehiculo.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar) {
                    ELavadoVehiculo UpdateLV = new ELavadoVehiculo();
                    UpdateLV.idLavadoVehiculo = Convert.ToInt32(btncancelar.Tag);
                    UpdateLV.servicioLavado.idServicioLavado = Convert.ToInt32(txtServicio.Tag);
                    UpdateLV.vehiculoLavado.idVehiculoLavado = Convert.ToInt32(txtVehiculo.Tag);
                    UpdateLV.precio = Convert.ToDecimal(txtPrecio.Text);
                    NLavadoVehiculos ULV = new NLavadoVehiculos();
                    ULV.UpdateRow(UpdateLV);
                    MessageBox.Show("Modificado","Lavado Vehiculo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    ELavadoVehiculo InsertLV = new ELavadoVehiculo();
                    InsertLV.servicioLavado.idServicioLavado = Convert.ToInt32(txtServicio.Tag);
                    InsertLV.vehiculoLavado.idVehiculoLavado = Convert.ToInt32(txtVehiculo.Tag);
                    InsertLV.precio = Convert.ToDecimal(txtPrecio.Text);
                    NLavadoVehiculos ILV = new NLavadoVehiculos();
                    ILV.insertRow(InsertLV);
                    MessageBox.Show("Guardado", "Lavado Vehiculo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                actualizarGrid();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                lblServicio.Enabled = false;
                lblVehiculo.Enabled = false;
                txtServicio.Enabled = false;
                txtVehiculo.Enabled = false;
                modificar = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLavadoVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                btncancelar.Tag = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["idLavadoVehiculo"].Value.ToString();
                txtServicio.Tag = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["idServicioLavado"].Value.ToString();
                txtServicio.Text = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["servicioLavado"].Value.ToString();
                txtVehiculo.Tag = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["idVehiculoLavado"].Value.ToString();
                txtVehiculo.Text = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["vehiculoLavado"].Value.ToString();
                txtPrecio.Text = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["precio"].Value.ToString();
                btnmodificar.Enabled = true;
                btncancelar.Enabled = true;
                btnguardar.Enabled = false;
                btnnuevo.Enabled = false;
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
            lblServicio.Enabled = true;
            lblVehiculo.Enabled = true;
            txtServicio.Enabled = false;
            txtVehiculo.Enabled = false;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            btncancelar.Enabled = false;
            lblServicio.Enabled = false;
            lblVehiculo.Enabled = false;
            txtServicio.Enabled = false;
            txtVehiculo.Enabled = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblServicio_Click(object sender, EventArgs e)
        {
            frmBuscarServicio servicio = new frmBuscarServicio();
            if (servicio.ShowDialog() == DialogResult.OK) {
                txtServicio.Tag = servicio.idServicio.ToString();
                txtServicio.Text = servicio.servicio.ToString();
            }
        }

        private void lblVehiculo_Click(object sender, EventArgs e)
        {
            frmBuscarVehiculo vehiculo = new frmBuscarVehiculo();
            if (vehiculo.ShowDialog() == DialogResult.OK) {
                txtVehiculo.Tag = vehiculo.idVehiculo.ToString();
                txtVehiculo.Text = vehiculo.vehiculo.ToString();
            }
        }
    }
}
