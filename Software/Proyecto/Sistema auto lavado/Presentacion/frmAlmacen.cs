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
    public partial class frmAlmacen : Form
    {
        List<Ealmacen> listaalmacen;
        bool modificar;
        public frmAlmacen()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {

            /*Codigo para actualizar lista*/
            Nalmacen listaX = new Nalmacen();
            listaalmacen = listaX.obtenerlistalmacen();

            var lista = (from almacen in listaalmacen
                         select new
                         {
                             almacen.IdAlmcen,
                             almacen.Categoria.CodCategoria,
                             Nombre_Almacen = almacen.Nombre,
                             almacen.Ubicacion,
                             almacen.Descripcion,
                             almacen.NombreCategoria
                         }).ToList();
            dgvfiltrarproductos.DataSource = lista;
            dgvfiltrarproductos.Columns["Idalmcen"].Visible = false;
            dgvfiltrarproductos.Columns["CodCategoria"].Visible = false;
            //dgvfiltrarproductos.Columns["Activo"].Visible = false;

        }

        private void frmAlmacen_Load(object sender, EventArgs e)
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
            txtnombre.Enabled = true;
            txtcategoria.Enabled = false;
            txttipo.Enabled = false;
            txtubicacion.Enabled = true;

            txtdescripcion.Enabled = true;
        }
        public void Deshabilitar()
        {
            txtnombre.Enabled = false;
            txtcategoria.Enabled = false;
            txtubicacion.Enabled = false;
            txttipo.Enabled = false;
            txtdescripcion.Enabled = false;
        }
        public void Limpiar()
        {
            txtnombre.Text = "";
            txtcategoria.Text = "";
            txttipo.Text = "";

            txtubicacion.Text = "";
            txtdescripcion.Text = "";



        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtnombre.Focus();
            txtcategoria.Focus();
            txtdescripcion.Focus();
            txtubicacion.Focus();
            txttipo.Focus();


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

                    Ealmacen editar = new Ealmacen();
                    editar.IdAlmcen = Convert.ToInt32(txtnombre.Tag.ToString());
                        editar.Nombre = txtnombre.Text;
                        editar.Categoria.CodCategoria = Convert.ToInt32(txtcategoria.Text.ToString());
                        editar.Ubicacion = txtubicacion.Text;
                        editar.Descripcion = txtdescripcion.Text;
                        editar.NombreCategoria = txttipo.Text;

                        Nalmacen gestion = new Nalmacen();
                        gestion.modificar(editar);
                        MessageBox.Show("Se modifico correctamente", "Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Ealmacen nuevo = new Ealmacen();


                    //COMPROBAR SI EL REGISTRO YA EXISTE CON UNA CONSULTA "LINQ" RECORRE TODA LA FILA DEL DATAGRID VIEW Y LA COLUMNA ESPECIFICA  .
                    bool exist = dgvfiltrarproductos.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Nombre_Almacen"].Value) == txtnombre.Text);
                    //SI EL VALOR NO EXISTE EN LA BASE DE DATOS LO INGRESA                
                    if (!exist == true)
                    {
                        nuevo.Nombre = txtnombre.Text;
                        nuevo.Categoria.CodCategoria = Convert.ToInt32(txtcategoria.Text.ToString());
                        nuevo.Ubicacion = txtubicacion.Text;
                        nuevo.Descripcion = txtdescripcion.Text;
                        nuevo.NombreCategoria = txttipo.Text;

                        Nalmacen gestion = new Nalmacen();
                        gestion.agregar(nuevo);
                        MessageBox.Show("Se guardo correctamente", "Almacen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //SI EL VALOR EXISTE EN LA BASE DE DATOS NO LO INGRESA
                    else
                    {

                        listaalmacen.Add(nuevo);

                        MessageBox.Show("Este almacen ya fue ingresado", "REVISE");

                    }





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
            modificar = false;
            Deshabilitar();
        }

        private void dgvfiltrarproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtnombre.Tag = Convert.ToInt32(dgvfiltrarproductos.Rows[e.RowIndex].Cells["Idalmcen"].Value.ToString());
                txtnombre.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Nombre_Almacen"].Value.ToString();
                txtubicacion.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Ubicacion"].Value.ToString();
                txtdescripcion.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtcategoria.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["CodCategoria"].Value.ToString();
                txttipo.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["NombreCategoria"].Value.ToString();
            }

            btnModificar.Enabled = true;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            frmbuscarcategoria bp = new frmbuscarcategoria();
            if (bp.ShowDialog() == DialogResult.OK)
            {
                txtcategoria.Text = bp.Codcategoria.ToString();
                txttipo.Text = bp.Nombre_Categoria.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
