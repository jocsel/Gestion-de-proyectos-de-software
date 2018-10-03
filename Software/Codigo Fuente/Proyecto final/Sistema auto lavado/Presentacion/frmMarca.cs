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
    public partial class frmMarca : Form
    {
        List<EMarcas> listamarca;
        List<EMarcas> listamarcavalidar = new List<EMarcas>();
        bool modificar;
        public frmMarca()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {

            //Nmarca gestion = new Nmarca();
            //listamarca = gestion.obtenerlistmarca();
            Nmarca listam = new Nmarca();
            listamarca = listam.obtenerlistmarca();

            var lista = (from marca in listamarca
                         select new
                         {
                             marca.Codmarca,
                             marca.Marca
                         }

                    ).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["Codmarca"].Visible = false;



        }


        private void frmMarca_Load(object sender, EventArgs e)
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

        public void Habilitar()
        {
            txtmarca.Enabled = true;


        }
        public void Deshabilitar()
        {

            txtmarca.Enabled = false;

        }
        public void Limpiar()
        {

            txtmarca.Text = "";

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtmarca.Focus();
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
                        EMarcas editar = new EMarcas();
                   
                        editar.Codmarca = Convert.ToInt32(txtmarca.Tag.ToString());
                        editar.Marca = txtmarca.Text;
                        //  editar.Marca = txtmarca.Text;
                        Nmarca gestion = new Nmarca();
                        gestion.modificar(editar);
                        MessageBox.Show("Se modifico correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);
     
                }


                else
                {
                    EMarcas nuevo = new EMarcas();
                    //COMPROBAR SI EL REGISTRO YA EXISTE CON UNA CONSULTA "LINQ" RECORRE TODA LA FILA DEL DATAGRID VIEW Y LA COLUMNA ESPECIFICA  .
                    bool exist = dataGridView1.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Marca"].Value) == txtmarca.Text);
                    //SI EL VALOR NO EXISTE EN LA BASE DE DATOS LO INGRESA                
                    if (!exist == true)
                    {
                        nuevo.Marca = txtmarca.Text;
                        Nmarca gestion = new Nmarca();
                        gestion.agregar(nuevo);
                        MessageBox.Show("Se guardo correctamente", "Marca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //SI EL VALOR EXISTE EN LA BASE DE DATOS NO LO INGRESA
                    else
                    {

                        listamarca.Add(nuevo);

                        MessageBox.Show("Esta marca ya fue ingresada", "REVISE");

                    }
                }
                ActualizarLista();
                dataGridView1.DataSource = listamarca;
                Limpiar();
                Deshabilitar();
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnModificar.Enabled = false;
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
            Limpiar();
            btnNuevo.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;
            txtmarca.Enabled = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtmarca.Tag = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Codmarca"].Value.ToString());
                txtmarca.Text = dataGridView1.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            }

            btnModificar.Enabled = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
