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
    public partial class frmCategoria : Form
    {

        List<Ecategoria> listacategoria;
        bool modificar;
        public frmCategoria()
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
                             Nombre_Producto = categoria.Nombredelproducto,
                             categoria.CodCategoria,
                             Categoria = categoria.Tipo,

                             categoria.Producto.Codproducto


                         }).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["CodCategoria"].Visible = false;




        }

        private void frmCategoria_Load(object sender, EventArgs e)
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
        public void Habilitar()
        {
            cbTipo.Enabled = true;
            txtCodProducto.Enabled = true;
            txtNombredelproducto.Enabled = true;

        }
        public void Deshabilitar()
        {
            cbTipo.Enabled = false;
            txtCodProducto.Enabled = false;
            txtNombredelproducto.Enabled = false;
        }
        public void Limpiar()
        {
            cbTipo.Text = "";
            txtNombredelproducto.Text = "";
            txtCodProducto.Text = "";

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            cbTipo.Focus();
            txtCodProducto.Focus();
            txtNombredelproducto.Focus();

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnbuscar.Enabled = true;

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
            btnbuscar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {

                    Ecategoria editar = new Ecategoria();
                    
                        editar.Tipo = cbTipo.Text;
                        editar.CodCategoria = Convert.ToInt32(txtNombredelproducto.Tag.ToString());
                        editar.Producto.Codproducto = Convert.ToInt32(txtCodProducto.Text.ToString());
                        editar.Nombredelproducto = txtNombredelproducto.Text;
                        Ncategoria gestion = new Ncategoria();
                        gestion.modificarcategoria(editar);
                        MessageBox.Show("Se modifico correctamente", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    Ecategoria nuevo = new Ecategoria();
                    //COMPROBAR SI EL REGISTRO YA EXISTE CON UNA CONSULTA "LINQ" RECORRE TODA LA FILA DEL DATAGRID VIEW Y LA COLUMNA ESPECIFICA  .
                    bool exist = dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Nombre_Producto"].Value) == txtNombredelproducto.Text);
                    //SI EL VALOR NO EXISTE EN LA BASE DE DATOS LO INGRESA     

                    if (!exist == true)
                    {
                        nuevo.Tipo = cbTipo.Text;
                        nuevo.Producto.Codproducto = Convert.ToInt32(txtCodProducto.Text.ToString());
                        nuevo.Nombredelproducto = txtNombredelproducto.Text;

                        Ncategoria gestion = new Ncategoria();
                        gestion.agregarcategoria(nuevo);
                        MessageBox.Show("Se guardo correctamente", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //SI EL VALOR EXISTE EN LA BASE DE DATOS NO LO INGRESA
                    else
                    {

                        listacategoria.Add(nuevo);

                        MessageBox.Show("Esta marca ya fue ingresada", "REVISE");

                    }

                    //  nuevo.CodCategoria = Convert.ToInt32(txtNombredelproducto.Tag.ToString());

                }

                ActualizarLista();
                Limpiar();
                Deshabilitar();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificar.Enabled = false;
                btnbuscar.Enabled = false;
                btnNuevo.Enabled = true;
                modificar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnbuscar.Enabled = false;
            Limpiar();
            Deshabilitar();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmBuscarproducto bp = new frmBuscarproducto();
            if (bp.ShowDialog() == DialogResult.OK)
            {
                txtCodProducto.Text = bp.Codproducto.ToString();
                txtNombredelproducto.Text = bp.Nombre_Producto.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombredelproducto.Tag = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["CodCategoria"].Value.ToString());
                cbTipo.Text = dataGridView1.Rows[e.RowIndex].Cells["Categoria"].Value.ToString();
                txtCodProducto.Text = dataGridView1.Rows[e.RowIndex].Cells["CodProducto"].Value.ToString();
                txtNombredelproducto.Text = dataGridView1.Rows[e.RowIndex].Cells["Nombre_Producto"].Value.ToString();
            }

            btnModificar.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmMenuprincipal inicio = new frmMenuprincipal();
            //inicio.Show();

        }
    }
}
