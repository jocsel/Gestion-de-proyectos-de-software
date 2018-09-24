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
    public partial class frmbuscarcategoria : Form
    {
        List<Ecategoria> listacategoria;
        public int? Codcategoria;
        public string Nombre_Categoria;
        public frmbuscarcategoria()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {
            /*Codigo para actualizar lista*/
            Ncategoria listaX = new Ncategoria();
            listacategoria = listaX.obtenerlistcategoria();

            var lista = (from categoria in listacategoria
                         select new
                         {
                             categoria.CodCategoria,
                             Categoria = categoria.Tipo,
                             categoria.Producto.Codproducto,
                             Nombre_Producto = categoria.Nombredelproducto

                         }).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["CodCategoria"].Visible = false;
        }
        private void frmbuscarcategoria_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al obtener los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Codcategoria = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CodCategoria"].Value.ToString());
                Nombre_Categoria = dataGridView1.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
