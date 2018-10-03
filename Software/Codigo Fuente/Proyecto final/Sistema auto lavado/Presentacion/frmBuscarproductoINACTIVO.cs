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
    public partial class frmBuscarproductoINACTIVO : Form
    {
        List<Eproductos> listaproducto; 
        public int? Codproducto;
        public string Nombre_Producto;
        public decimal Precio , Costo;
        public frmBuscarproductoINACTIVO()
        {
            InitializeComponent();
        }


        private void ActualizarLista()
        {

            /*Codigo para actualizar lista*/
            Ninactivo_anulada listaX = new Ninactivo_anulada();
            listaproducto = listaX.obtenerlistproductoANULADO();

            var lista = (from productos in listaproducto
                         where productos.Activo == false
                         select new
                         {
                             productos.Codproducto,
                             Producto = productos.Producto,
                             Marca = productos.Marca.Codmarca,
                             CodSAC = productos.CodSac,
                             productos.Existencia,
                             Costo = productos.Costo,
                             Precio = productos.Precio,
                             productos.Activo
                         }).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Codproducto"].Visible = true;
            dataGridView1.Columns["Marca"].Visible = false;
            dataGridView1.Columns["Activo"].Visible = true;

        }
        public void filtrar()
        {

            if (rbcodigo.Checked)
            {
                var lista = (from productos in listaproducto
                             where productos.Activo == false && productos.Codproducto.ToString().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 productos.Codproducto,
                                 Producto = productos.Producto,
                                 Marca = productos.Marca.Codmarca,
                                 CodSAC = productos.CodSac,
                                 productos.Existencia,
                                 Costo = productos.Costo,
                                 Precio = productos.Precio,
                                 productos.Activo
                             }).ToList();
                dataGridView1.DataSource = lista;
                dataGridView1.Columns["Codproducto"].Visible = true;
                dataGridView1.Columns["Marca"].Visible = false;
                dataGridView1.Columns["Activo"].Visible = true;

            }


            if (rbNombre.Checked)
            {
                var lista = (from productos in listaproducto
                             where productos.Activo == false && productos.Producto.ToUpper().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 productos.Codproducto,
                                 Producto = productos.Producto,
                                 Marca = productos.Marca.Codmarca,
                                 CodSAC = productos.CodSac,
                                 productos.Existencia,
                                 Costo = productos.Costo,
                                 Precio = productos.Precio,
                                 productos.Activo
                             }).ToList();
                dataGridView1.DataSource = lista;
                dataGridView1.Columns["Codproducto"].Visible = true;
                dataGridView1.Columns["Marca"].Visible = false;
                dataGridView1.Columns["Activo"].Visible = true;


            }


           
        }



        private void frmBuscarproducto_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void dgvfiltrarproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Codproducto = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Codproducto"].Value.ToString());
                Nombre_Producto = dataGridView1.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                Precio = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value.ToString()); 
                    Costo = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Costo"].Value.ToString());
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

        private void rbcodigo_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Codigo : ";
        }

        private void rbNombre_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Nombre : ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }   
    }
}
