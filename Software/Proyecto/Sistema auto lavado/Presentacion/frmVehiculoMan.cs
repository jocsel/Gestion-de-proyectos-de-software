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
    public partial class frmVehiculoMan : Form
    {
        List<EVehiculoMantenimiento> ListaVehiculoMan;
        bool modificar;
        public frmVehiculoMan()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtvehiculo.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            dgvVehiculoM.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
            dgvVehiculoM.Enabled = false;
        }
        private void Deshabilitar()
        {

            txtvehiculo.Enabled = false;

            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void Habilitar()
        {
            txtvehiculo.Enabled = true;
            rbActivo.Checked = true;
            rbInactivo.Enabled = true;
            rbActivo.Enabled = true;
        }

        private void Limpiar()
        {

            txtvehiculo.Text = "";
            txtvehiculo.Tag = "";
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            dgvVehiculoM.Enabled = true;
        }
        public void ActualizarServicioMan()
        {
            NVehiculoMan gestionarVM = new NVehiculoMan();
            ListaVehiculoMan = gestionarVM.ObtenerListaVehiculoMan();

        }
        public void actualizargrid()
        {
            try
            {
                NVehiculoMan listaVehiculoMan = new NVehiculoMan();
                ListaVehiculoMan = listaVehiculoMan.ObtenerListaVehiculoMan();

                var lista = (from ve in ListaVehiculoMan
                             select new
                             {
                                 ve.idVehiculoMantenimiento,
                                 Vehiculo = ve.vehiculoMantenimiento,
                                 Estado = ve.estado,

                             }).ToList();
                dgvVehiculoM.DataSource = lista;
                dgvVehiculoM.Columns["idVehiculoMantenimiento"].Visible = false;

                ActualizarServicioMan();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVehiculoMan_Load(object sender, EventArgs e)
        {
            actualizargrid();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EVehiculoMantenimiento modVehiculoM = new EVehiculoMantenimiento();
                    modVehiculoM.idVehiculoMantenimiento = Convert.ToInt32(txtvehiculo.Tag.ToString());
                    modVehiculoM.vehiculoMantenimiento = txtvehiculo.Text;

                    if (rbActivo.Checked == true) { modVehiculoM.estado = true; } else { modVehiculoM.estado = false; }

                    NVehiculoMan gestionarVM = new NVehiculoMan();
                    gestionarVM.Modificar(modVehiculoM);

                    MessageBox.Show("Se modifico correctamente", "Servicio de Mantenimineto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    EVehiculoMantenimiento newVM = new EVehiculoMantenimiento();
                    newVM.vehiculoMantenimiento = txtvehiculo.Text;

                    if (rbActivo.Checked == true) { newVM.estado = true; } else { newVM.estado = false; }

                    NVehiculoMan gestionarVM = new NVehiculoMan();
                    gestionarVM.Agregar(newVM);
                    MessageBox.Show("Se guardo correctamente", "Servicio de Mantenimineto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvVehiculoM.Enabled = true;
                }

                ActualizarServicioMan();
                actualizargrid();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                modificar = false;
                dgvVehiculoM.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVehiculoM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtvehiculo.Tag = Convert.ToInt32(dgvVehiculoM.Rows[e.RowIndex].Cells["idVehiculoMantenimiento"].Value.ToString());

                if (dgvVehiculoM.Rows[e.RowIndex].Cells["Vehiculo"].Value == null)
                    txtvehiculo.Text = "";
                else
                    txtvehiculo.Text = dgvVehiculoM.Rows[e.RowIndex].Cells["Vehiculo"].Value.ToString();

                if (dgvVehiculoM.Rows[e.RowIndex].Cells["estado"].Value == null)
                    rbInactivo.Checked = false;
                else
                    rbActivo.Checked = bool.Parse(dgvVehiculoM.Rows[e.RowIndex].Cells["estado"].Value.ToString());

                btnmodificar.Enabled = true;
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
            }
        }

       

        private void pictureBox8_Click(object sender, EventArgs e)
        {

           
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
