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
    public partial class frmServicioLavado : Form
    {
        public List<EServicioLavado> listarServicios;
        bool modificar;
        public frmServicioLavado()
        {
            InitializeComponent();
            Deshabilitar();
            btncancelar.Enabled = false;
            btnnuevo.Enabled = true;
            btnmodificar.Enabled = false;
            btnguardar.Enabled = false;
            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;
        }
        private void Deshabilitar()
        {
            txtServicio.Enabled = false;

        }
        private void Habilitar()
        {
            txtServicio.Enabled = true;

        }
        private void Limpiar()
        {

            txtServicio.Text = "";
        }
        public void actualizarGrid()
        {
            NServicioLavado listar = new NServicioLavado();
            listarServicios = listar.SelectRow();
        }

        private void frmServicioLavado_Load(object sender, EventArgs e)
        {
            try
            {
                actualizarGrid();
                dgvServicioLavado.DataSource = listarServicios;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
             
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
            rbActivo.Enabled = true;
            rbInactivo.Enabled = true;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EServicioLavado UpdateSL = new EServicioLavado();
                    UpdateSL.servicioLavado = txtServicio.Text;
                    UpdateSL.idServicioLavado = Convert.ToInt32(txtServicio.Tag);
                    if (rbActivo.Checked == true)
                    {
                        UpdateSL.estado = true;
                    }
                    else {
                        UpdateSL.estado = false;
                    }
                    NServicioLavado update = new NServicioLavado();
                    update.UpdaetRow(UpdateSL);
                    MessageBox.Show("Modificado", "Vehiculo Lavado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    EServicioLavado InsertSL = new EServicioLavado();
                    InsertSL.servicioLavado = txtServicio.Text;
                    if (rbActivo.Checked == true)
                    {
                        InsertSL.estado = true;
                    }
                    else
                    {
                        InsertSL.estado = false;
                    }
                    NServicioLavado Insert = new NServicioLavado();
                    Insert.InsertRow(InsertSL);
                    MessageBox.Show("Guardado", "Vehiculo Lavado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                actualizarGrid();
                dgvServicioLavado.DataSource = listarServicios;
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                modificar = false;
                rbActivo.Enabled = false;
                rbInactivo.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvServicioLavado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtServicio.Text = dgvServicioLavado.Rows[e.RowIndex].Cells["servicioLavado"].Value.ToString();
                txtServicio.Tag = dgvServicioLavado.Rows[e.RowIndex].Cells["idServicioLavado"].Value.ToString();
                rbActivo.Checked = bool.Parse(dgvServicioLavado.Rows[e.RowIndex].Cells["estado"].Value.ToString());
                btnmodificar.Enabled = true;
                btncancelar.Enabled = true;
                btnguardar.Enabled = false;
                btnnuevo.Enabled = false;
                rbActivo.Enabled = false;
                rbInactivo.Enabled = false;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            rbActivo.Enabled = true;
            rbInactivo.Enabled = true;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            btncancelar.Enabled = false;
            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;
        }

        private void dgvServicioLavado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

