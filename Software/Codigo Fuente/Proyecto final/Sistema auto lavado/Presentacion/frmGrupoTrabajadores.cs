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
    public partial class frmGrupoTrabajadores : Form
    {
        List<EGrupoTrabajadores> listaGT;
        bool modificar;
        public frmGrupoTrabajadores()
        {
            InitializeComponent();
        }
        public void ActualizarGrid() {
            NGrupoTrabajadores gestioG = new NGrupoTrabajadores();
            listaGT = gestioG.obtenerLista();
        }
        private void frmGrupoTrabajadores_Load(object sender, EventArgs e)
        {
            txtnombre.Enabled = false;
            txtnombre.Text = "";
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            try {
                ActualizarGrid();
                dgvGrupoTrabajadores.DataSource = listaGT;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar) {
                    EGrupoTrabajadores UGT = new EGrupoTrabajadores();
                    UGT.idGrupo = Convert.ToInt32(txtnombre.Tag);
                    UGT.grupoTrabajadores = txtnombre.Text;

                    NGrupoTrabajadores gestioG = new NGrupoTrabajadores();
                    gestioG.UpdateRow(UGT);
                    MessageBox.Show("Se modifica sastifactoriamente","Grupo Trabajadres",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else {
                    EGrupoTrabajadores IGT = new EGrupoTrabajadores();                    
                    IGT.grupoTrabajadores = txtnombre.Text;

                    NGrupoTrabajadores gestioG = new NGrupoTrabajadores();
                    gestioG.InsertRow(IGT);
                    MessageBox.Show("Se guardo sastifactoriamente", "Grupo Trabajadres", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                ActualizarGrid();
                dgvGrupoTrabajadores.DataSource = listaGT;
                modificar = false;
                txtnombre.Enabled = false;
                txtnombre.Text = "";
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;
                btnModificar.Enabled = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtnombre.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            modificar = true;
        }

        private void dgvGrupoTrabajadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                txtnombre.Text = dgvGrupoTrabajadores.Rows[e.RowIndex].Cells["grupoTrabajadores"].Value.ToString();
                txtnombre.Tag = dgvGrupoTrabajadores.Rows[e.RowIndex].Cells["idGrupo"].Value.ToString();
                txtnombre.Enabled = false;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
                btnNuevo.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
          
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            txtnombre.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtnombre.Enabled = false;
            txtnombre.Text = "";
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
