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
    public partial class frmBuscarServicioMan : Form
    {
        List<EServicioVehiculo> ListaServicioV;
        public int idservicioVehiculo;
        public decimal precio;
        public string nombre;
        public frmBuscarServicioMan()
        {
            InitializeComponent();
        }

        private void frmBuscarServicioMan_Load(object sender, EventArgs e)
        {
            
            NServicioVehiculo listaSV = new NServicioVehiculo();
            ListaServicioV = listaSV.ObtenerServicioV();

            var lista = (from sv in ListaServicioV
                         select new
                         {
                             sv.idServicioVehiculo,
                            Servicio= sv.idServicioMantenimiento.servicioMantenimiento,
                             Vehiculo=sv.idVehiculoMantenimiento.vehiculoMantenimiento,
                             Precio=sv.precio,
                             sv.estado,
                             sv.idServicioMantenimiento.idServicioMantenimiento,
                             sv.idVehiculoMantenimiento.idVehiculoMantenimiento,
                         }).ToList();
            dgvBuscarServicio.DataSource = lista;
            dgvBuscarServicio.Columns["idServicioVehiculo"].Visible = false;
            dgvBuscarServicio.Columns["idServicioMantenimiento"].Visible = false;
            dgvBuscarServicio.Columns["idVehiculoMantenimiento"].Visible = false;
            dgvBuscarServicio.Columns["estado"].Visible = false;
        }

        private void dgvBuscarServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idservicioVehiculo = Convert.ToInt32(dgvBuscarServicio.Rows[e.RowIndex].Cells["idServicioVehiculo"].Value.ToString());
            precio = Convert.ToDecimal(dgvBuscarServicio.Rows[e.RowIndex].Cells["Precio"].Value.ToString());
            nombre = (dgvBuscarServicio.Rows[e.RowIndex].Cells["Servicio"].Value.ToString())+" & "+(dgvBuscarServicio.Rows[e.RowIndex].Cells["Vehiculo"].Value.ToString());
            DialogResult = DialogResult.OK;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();

        }
        public void filtrar()
        {

             var lista = (from sv in ListaServicioV
                          where sv.idServicioMantenimiento.servicioMantenimiento.ToUpper().StartsWith(textBox1.Text.ToUpper())
                         select new
                         {
                             sv.idServicioVehiculo,
                            Servicio= sv.idServicioMantenimiento.servicioMantenimiento,
                             Vehiculo=sv.idVehiculoMantenimiento.vehiculoMantenimiento,
                             Precio=sv.precio,
                             sv.estado,
                             sv.idServicioMantenimiento.idServicioMantenimiento,
                             sv.idVehiculoMantenimiento.idVehiculoMantenimiento,
                         }).ToList();
            dgvBuscarServicio.DataSource = lista;
            dgvBuscarServicio.Columns["idServicioVehiculo"].Visible = false;
            dgvBuscarServicio.Columns["idServicioMantenimiento"].Visible = false;
            dgvBuscarServicio.Columns["idVehiculoMantenimiento"].Visible = false;
            dgvBuscarServicio.Columns["estado"].Visible = false;
        
        }
    }
}
