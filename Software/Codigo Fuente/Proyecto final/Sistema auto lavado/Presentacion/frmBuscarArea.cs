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
    public partial class frmBuscarArea : Form
    {
        public int idArea;
        public string area;
        List<EArea> list;
        public frmBuscarArea()
        {
            InitializeComponent();
        }

        private void frmBuscarArea_Load(object sender, EventArgs e)
        {
            try
            {
                NArea gestioA = new NArea();
                list = gestioA.listaArea();
                dgvBuscarGrupo.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void filtrar()
        {
            var resultado = (
                from area in list
                where area.area.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    area.area,
                    area.idArea,
                }).ToList();
            dgvBuscarGrupo.DataSource = resultado;
        }

        private void dgvBuscarGrupo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idArea = Convert.ToInt32(dgvBuscarGrupo.Rows[e.RowIndex].Cells["idArea"].Value.ToString());
                area = dgvBuscarGrupo.Rows[e.RowIndex].Cells["area"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
