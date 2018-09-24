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
    public partial class frmBuscarLV : Form
    {
        public int idLavadoVehiculo;
        public decimal precio;
        public string vehiculo;
        List<ELavadoVehiculo> LV;
        public frmBuscarLV()
        {
            InitializeComponent();
        }

        private void frmBuscarLV_Load(object sender, EventArgs e)
        {
            try
            {
                NLavadoVehiculos listarLV = new NLavadoVehiculos();
                LV = listarLV.selectRow();
                var lista = (from lavadoVehiculo in LV
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLavadoVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idLavadoVehiculo = Convert.ToInt32(dgvLavadoVehiculo.Rows[e.RowIndex].Cells["idLavadoVehiculo"].Value.ToString());
                precio = Convert.ToDecimal(dgvLavadoVehiculo.Rows[e.RowIndex].Cells["precio"].Value.ToString());
                vehiculo = dgvLavadoVehiculo.Rows[e.RowIndex].Cells["vehiculoLavado"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void filtrar()
        {
            var resultado = (from lavadovehiculo in LV
                             where lavadovehiculo.vehiculoLavado.vehiculoLavado.ToUpper().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 lavadovehiculo.idLavadoVehiculo,
                                 lavadovehiculo.servicioLavado.idServicioLavado,
                                 lavadovehiculo.vehiculoLavado.idVehiculoLavado,
                                 lavadovehiculo.vehiculoLavado.vehiculoLavado,
                                 lavadovehiculo.servicioLavado.servicioLavado,
                                 lavadovehiculo.precio,
                             }).ToList();
            dgvLavadoVehiculo.DataSource = resultado;
            dgvLavadoVehiculo.Columns["idLavadoVehiculo"].Visible = false;
            dgvLavadoVehiculo.Columns["idServicioLavado"].Visible = false;
            dgvLavadoVehiculo.Columns["idVehiculoLavado"].Visible = false;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
