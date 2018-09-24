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
    public partial class frmServicioMantenimiento : Form
    {
        List<EServicioMantenimiento> ListaServicioMan;
        bool modificar;
        public frmServicioMantenimiento()
        {
            InitializeComponent(); 
            Deshabilitar();
        }

        private void frmServicioMantenimiento_Load(object sender, EventArgs e)
        {
            actualizargrid();

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtservicio.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            dgvServicioM.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
            dgvServicioM.Enabled = false;
        }

        private void Deshabilitar()
        {

            txtservicio.Enabled = false;
           
            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;          
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;         
        }

        private void Habilitar()
        {
            txtservicio.Enabled = true;         
            rbActivo.Checked = true;        
            rbInactivo.Enabled = true;
            rbActivo.Enabled = true;
        }

        private void Limpiar()
        {

            txtservicio.Text = "";
            txtservicio.Tag = "";
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            dgvServicioM.Enabled = true;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EServicioMantenimiento modServicioM = new EServicioMantenimiento();
                    modServicioM.idServicioMantenimiento = Convert.ToInt32(txtservicio.Tag.ToString());
                    modServicioM.servicioMantenimiento = txtservicio.Text;

                    if (rbActivo.Checked == true) { modServicioM.estado = true; } else { modServicioM.estado = false; }

                    NServicioMantenimiento gestionarServicioM = new NServicioMantenimiento();
                    gestionarServicioM.Modificar(modServicioM);

                    MessageBox.Show("Se modifico correctamente", "Servicio de Mantenimineto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    EServicioMantenimiento newServicioM = new EServicioMantenimiento();
                    newServicioM.servicioMantenimiento = txtservicio.Text;

                    if (rbActivo.Checked == true) { newServicioM.estado = true; } else { newServicioM.estado = false; }

                    NServicioMantenimiento gestionarServicioM = new NServicioMantenimiento();
                    gestionarServicioM.Agregar(newServicioM);

                    MessageBox.Show("Se guardo correctamente", "Servicio de Mantenimineto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvServicioM.Enabled = true;
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
                dgvServicioM.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ActualizarServicioMan()
        {
            NServicioMantenimiento gestionarSM = new NServicioMantenimiento();
            ListaServicioMan = gestionarSM.ObtenerListaServicioM();

        }

        private void dgvServicioM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtservicio.Tag = Convert.ToInt32(dgvServicioM.Rows[e.RowIndex].Cells["idServicioMantenimiento"].Value.ToString());

                if (dgvServicioM.Rows[e.RowIndex].Cells["Servicio"].Value == null)
                    txtservicio.Text = "";
                else
                    txtservicio.Text = dgvServicioM.Rows[e.RowIndex].Cells["Servicio"].Value.ToString();

                if (dgvServicioM.Rows[e.RowIndex].Cells["estado"].Value == null)
                    rbInactivo.Checked = false;
                else
                    rbActivo.Checked = bool.Parse(dgvServicioM.Rows[e.RowIndex].Cells["estado"].Value.ToString());

                btnmodificar.Enabled = true;                
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;

            }

        }

        public void actualizargrid()
        {
            try
            {
                NServicioMantenimiento listaServicioMan = new NServicioMantenimiento();
                ListaServicioMan = listaServicioMan.ObtenerListaServicioM();

                var lista = (from ser in ListaServicioMan
                             select new
                             {
                                 ser.idServicioMantenimiento,
                                 Servicio=ser.servicioMantenimiento,
                                 Estado=ser.estado,

                                

                             }).ToList();
                dgvServicioM.DataSource = lista;
                dgvServicioM.Columns["idServicioMantenimiento"].Visible = false;

                ActualizarServicioMan();

            }
            catch (Exception ex)
            {                             
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
