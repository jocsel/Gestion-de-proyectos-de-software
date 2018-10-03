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
    public partial class frmBuscarVehiculo : Form
    {
        public int idVehiculo;
        public string vehiculo;
        List<EVehiculoLavado> list;
        public frmBuscarVehiculo()
        {
            InitializeComponent();
        }

        private void frmBuscarVehiculo_Load(object sender, EventArgs e)
        {
            NVehiculoLavado gestio = new NVehiculoLavado();
            list = gestio.SelectRow();
            dgvBuscarVehiculo.DataSource = list;
        }

        private void dgvBuscarVehiculo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idVehiculo = Convert.ToInt32(dgvBuscarVehiculo.Rows[e.RowIndex].Cells["idVehiculoLavado"].Value.ToString());
            vehiculo = dgvBuscarVehiculo.Rows[e.RowIndex].Cells["vehiculoLavado"].Value.ToString();
            DialogResult = DialogResult.OK;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void filtrar()
        {
            var resultado = (from vehiculo in list
                             where vehiculo.vehiculoLavado.ToUpper().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 vehiculo.idVehiculoLavado,
                                 vehiculo.vehiculoLavado,
                                 vehiculo.estado,
                             }
                             ).ToList();
            dgvBuscarVehiculo.DataSource = resultado;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
