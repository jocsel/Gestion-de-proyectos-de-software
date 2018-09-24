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
    public partial class frmclientes : Form
    {
        List<ECliente> listaclientes;
        bool modificar;
        public frmclientes()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {

            NCliente gestionclientes = new NCliente();
            listaclientes = gestionclientes.obtenerlistClientes();
        }

        private void frmclientes_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();
                dgvfiltrarclientes.DataSource = listaclientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Habilitar()
        {
            txtnombre.Enabled = true;
            txtapellidos.Enabled = true;
            // mkdcedula.Enabled = true;
            txtcelular.Enabled = true;
            txtcorreo.Enabled = true;
            txtcelular.Enabled = true;
            txtestado.Enabled = true;
           
        }

        public void Deshabilitar()
        {
            txtnombre.Enabled = false;
            txtapellidos.Enabled = false;
            //  mkdcedula.Enabled = true;
            txtcelular.Enabled = false;
            txtcorreo.Enabled = false;
            txtcelular.Enabled = false;
            txtestado.Enabled = false;


        }
        public void Limpiar()
        {
            txtnombre.Text = "";
            txtapellidos.Text = "";
            //mkdcedula.Enabled = true;
            txtcelular.Text = "";
            txtcorreo.Text = "";
            txtcelular.Text = "";
            txtestado.Text = "";
    
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtnombre.Focus();
            txtapellidos.Focus();
            // mkdcedula.Focus();
            txtcelular.Focus();
            txtcorreo.Focus();
            txtcelular.Focus();
            txtestado.Focus();

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;

            btnNuevo.Enabled = false;
            Limpiar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;

            modificar = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {

                    ECliente editarclientes = new ECliente();
                    editarclientes.idCliente = Convert.ToInt32(txtnombre.Tag.ToString());                 
                    editarclientes.nombres = txtnombre.Text;
                    editarclientes.apellido = txtapellidos.Text;
                 
                    editarclientes.correo = txtcorreo.Text;
                    editarclientes.celular = Convert.ToInt32(txtcelular.Text.ToString());
                    editarclientes.estado = txtestado.Text;
                    NCliente gestionclientes = new NCliente();
                    gestionclientes.Modificarclientes(editarclientes);
                    MessageBox.Show("Se modifico correctamente", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ECliente newcliente = new ECliente();
                
                    newcliente.nombres = txtnombre.Text;
                    newcliente.apellido = txtapellidos.Text;

                    newcliente.correo = txtcorreo.Text;
                    newcliente.celular = Convert.ToInt32(txtcelular.Text.ToString());
                    newcliente.estado = txtestado.Text;
                    NCliente gestionclientes = new NCliente();
                    gestionclientes.agregar(newcliente);
                    MessageBox.Show("Se guardo correctamente", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                ActualizarLista();
                dgvfiltrarclientes.DataSource = listaclientes;
                Limpiar();
                Deshabilitar();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificar.Enabled = false;
                modificar = false;
                btnNuevo.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Deshabilitar();
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            Limpiar();
        }

        private void dgvfiltrarclientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtnombre.Tag = dgvfiltrarclientes.Rows[e.RowIndex].Cells["idcliente"].Value.ToString();
                txtnombre.Text = dgvfiltrarclientes.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                txtapellidos.Text = dgvfiltrarclientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                txtcelular.Text = dgvfiltrarclientes.Rows[e.RowIndex].Cells["celular"].Value.ToString();
                txtcorreo.Text = dgvfiltrarclientes.Rows[e.RowIndex].Cells["correo"].Value.ToString();
            
                txtestado.Text = dgvfiltrarclientes.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            }

            btnModificar.Enabled = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmMenuprincipal inicio = new frmMenuprincipal();
            //inicio.Show();
        }

        private void dgvfiltrarclientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
