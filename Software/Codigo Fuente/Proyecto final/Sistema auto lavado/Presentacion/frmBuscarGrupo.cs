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
    public partial class frmBuscarGrupo : Form
    {
        public int idGrupo;
        public string grupo;
        List<EGrupoTrabajadores> list;
        public frmBuscarGrupo()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBuscarGrupo_Load(object sender, EventArgs e)
        {
            try
            {
                NGrupoTrabajadores gestioG = new NGrupoTrabajadores();
                list = gestioG.obtenerLista();
                dgvBuscarGrupo.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvPelicula_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idGrupo = Convert.ToInt32(dgvBuscarGrupo.Rows[e.RowIndex].Cells["idGrupo"].Value.ToString());
                grupo = dgvBuscarGrupo.Rows[e.RowIndex].Cells["grupoTrabajadores"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void filtrar()
        {
            var resultado = (
                from grupo in list
                where grupo.grupoTrabajadores.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    grupo.grupoTrabajadores,
                    grupo.idGrupo
                }
                ).ToList();
            dgvBuscarGrupo.DataSource = resultado;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
