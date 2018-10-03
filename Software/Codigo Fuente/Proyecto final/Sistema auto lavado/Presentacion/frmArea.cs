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
    public partial class frmArea : Form
    {
        List<EArea> listaArea;
        bool modificar;
        public frmArea()
        {
            InitializeComponent();
        }
        
        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }
        public void ActualizarGrid() {
            NArea gestionArea = new NArea();
            listaArea = gestionArea.listaArea();
        }
        private void frmArea_Load(object sender, EventArgs e)
        {
            txtArea.Enabled = false;
            txtArea.Text = "";
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            try {
                ActualizarGrid();
                dgvArea.DataSource = listaArea;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar)
                {
                    EArea UArea = new EArea();
                    UArea.area = txtArea.Text;
                    UArea.idArea = Convert.ToInt32(txtArea.Tag);
                    NArea gestionArea = new NArea();
                    gestionArea.UpdateRow(UArea);
                    MessageBox.Show("Se modifico sastifactoriamente", "Area", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    EArea IArea = new EArea();
                    IArea.area = txtArea.Text;
                    NArea gestionArea = new NArea();
                    gestionArea.InsertRow(IArea);
                    MessageBox.Show("Se guardo sastifactoriamente","Area",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                ActualizarGrid();
                modificar = false;
                dgvArea.DataSource = listaArea;
                txtArea.Enabled = false;
                txtArea.Text = "";
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtArea.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void dgvArea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                txtArea.Text = dgvArea.Rows[e.RowIndex].Cells["area"].Value.ToString();
                txtArea.Tag = dgvArea.Rows[e.RowIndex].Cells["idArea"].Value.ToString();
                txtArea.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtArea.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            modificar = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtArea.Enabled = false;
            txtArea.Text = "";
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
