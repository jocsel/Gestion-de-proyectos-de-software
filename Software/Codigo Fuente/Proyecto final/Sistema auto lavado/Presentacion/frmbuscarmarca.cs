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
    public partial class frmbuscarmarca : Form
    {
        List<EMarcas> listamarca;
        public int? CodMarca;
        public frmbuscarmarca()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {


            Nmarca listam = new Nmarca();
            listamarca = listam.obtenerlistmarca();

            var lista = (from marca in listamarca
                         select new
                         {
                             marca.Codmarca,
                             Marca_Del_Producto = marca.Marca
                         }

                    ).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Codmarca"].Visible = false;



        }

        private void frmbuscarmarca_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                CodMarca = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Codmarca"].Value.ToString());
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
