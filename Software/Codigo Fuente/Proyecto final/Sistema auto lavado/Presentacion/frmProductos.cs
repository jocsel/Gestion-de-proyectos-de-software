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
    public partial class frmProductos : Form
    {
        List<Eproductos> listaproducto;
        bool modificar;
        public frmProductos()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {

            /*Codigo para actualizar lista*/
            Nproductos listaX = new Nproductos();
            listaproducto = listaX.obtenerlistproducto();

            var lista = (from productos in listaproducto
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
            dgvfiltrarproductos.DataSource = lista;
            dgvfiltrarproductos.Columns["Codproducto"].Visible = false;
            dgvfiltrarproductos.Columns["Marca"].Visible = false;
            dgvfiltrarproductos.Columns["Activo"].Visible = false;

        }
        public void Habilitar()
        {
            txtnombre.Enabled = true;
            txtmarca.Enabled = true;
            txtpreciocompra.Enabled = true;
            txtCodSAC.Enabled = true;
            txtprecioventa.Enabled = true;
            rbtnActvivo.Enabled = true;
            rbtnInactivo.Enabled = true;
            txtexistencia.Enabled = true;
        }
        public void Deshabilitar()
        {
            txtnombre.Enabled = false;
            txtmarca.Enabled = false;
            txtCodSAC.Enabled = false;
            txtprecioventa.Enabled = false;
            txtpreciocompra.Enabled = false;
            rbtnActvivo.Enabled = false;
            rbtnInactivo.Enabled = false;
            txtexistencia.Enabled = false;
        }
        public void Limpiar()
        {
            int d;
            double c, v;
            c = 0 * 0;
            v = 0 * 0;
            d = 0 * 0;
            txtexistencia.Text = d.ToString();
            txtpreciocompra.Text = c.ToString();
            txtprecioventa.Text = v.ToString();

            txtnombre.Text = "";
            txtmarca.Text = "";
            //txtpreciocompra.Text = "";
            //txtprecioventa.Text = "";
              txtCodSAC.Text = "";
          //  txtexistencia.Text = "";
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar();
            txtnombre.Focus();
            txtmarca.Focus();
            txtpreciocompra.Focus();
            txtCodSAC.Focus();
            txtexistencia.Focus();

            txtprecioventa.Focus();
            rbtnActvivo.Focus();
            rbtnInactivo.Focus();
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnModificar.Enabled = false;
            btnBuscarmarca.Enabled = true;

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
            btnBuscarmarca.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {

                    if (Convert.ToDecimal(txtpreciocompra.Text.ToString()) >= Convert.ToDecimal(txtprecioventa.Text.ToString()))
                    {

                        MessageBox.Show("El precio de compra no puede ser mayor al precio  de compra", "REVISE", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {

                        Eproductos editar = new Eproductos();

                        editar.Codproducto = Convert.ToInt32(txtnombre.Tag.ToString());
                        editar.Producto = txtnombre.Text;
                        editar.CodSac = txtCodSAC.Text;
                        editar.Marca.Codmarca = Convert.ToInt32(txtmarca.Text.ToString());
                        editar.Existencia = Convert.ToInt16(txtexistencia.Text.ToString());
                        editar.Precio = Convert.ToDecimal(txtprecioventa.Text.ToString());
                        editar.Costo = Convert.ToDecimal(txtpreciocompra.Text.ToString());
                        if (rbtnActvivo.Checked == true)
                        {
                            editar.Activo = true;
                        }
                        else
                        {
                            editar.Activo = false;
                        }

                        Nproductos gestion = new Nproductos();
                        gestion.modificar(editar);
                        MessageBox.Show("Se modifico correctamente", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }
                else
                {
                    Eproductos nuevo = new Eproductos();
                    //COMPROBAR SI EL REGISTRO YA EXISTE CON UNA CONSULTA "LINQ" RECORRE TODA LA FILA DEL DATAGRID VIEW Y LA COLUMNA ESPECIFICA  .
                    bool exist = dgvfiltrarproductos.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["Producto"].Value) == txtnombre.Text);
                    bool exist2 = dgvfiltrarproductos.Rows.Cast<DataGridViewRow>().Any(row => Convert.ToString(row.Cells["CodSAC"].Value) == txtCodSAC.Text);
                    //SI EL VALOR NO EXISTE EN LA BASE DE DATOS LO INGRESA                
                    if (!exist == true)
                    {
                        if (!exist2 == true)

                        {
                        
                            if (Convert.ToDecimal(txtpreciocompra.Text.ToString()) >= Convert.ToDecimal(txtprecioventa.Text.ToString()))
                            {

                                MessageBox.Show("El precio de compra no puede ser mayor al precio  de compra", "REVISE", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            }
                            else
                            {
                                nuevo.Producto = txtnombre.Text;
                                nuevo.Marca.Codmarca = Convert.ToInt32(txtmarca.Text.ToString());
                                nuevo.CodSac = txtCodSAC.Text;
                                nuevo.Existencia = Convert.ToInt32(txtexistencia.Text.ToString());
                                nuevo.Precio = Convert.ToDecimal(txtprecioventa.Text.ToString());
                                nuevo.Costo = Convert.ToDecimal(txtpreciocompra.Text.ToString());
                                if (rbtnActvivo.Checked == true)
                                {
                                    nuevo.Activo = true;
                                }
                                else
                                {
                                    nuevo.Activo = false;
                                }
                                Nproductos gestion = new Nproductos();
                                gestion.agregar(nuevo);
                                MessageBox.Show("Se guardo correctamente", "PRODUCTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpiar();
                                Deshabilitar();
                                btnGuardar.Enabled = false;
                                btnCancelar.Enabled = false;
                                btnModificar.Enabled = false;
                                btnBuscarmarca.Enabled = false;
                                btnNuevo.Enabled = true;
                                modificar = false;
                            }


                        }
                        else
                        {
                            listaproducto.Add(nuevo);
                            MessageBox.Show("Este CodSAC ya fue ingresado", "REVISE");
                        }


                    }
                    //SI EL VALOR EXISTE EN LA BASE DE DATOS NO LO INGRESA
                    else
                    {
                        listaproducto.Add(nuevo);
                        MessageBox.Show("Este producto ya fue ingresado", "REVISE");
                    }
                }

                ActualizarLista();
          
               
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
            btnBuscarmarca.Enabled = false;
            Deshabilitar();
            Limpiar();
        }

        private void dgvfiltrarproductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtnombre.Tag = Convert.ToInt32(dgvfiltrarproductos.Rows[e.RowIndex].Cells["Codproducto"].Value.ToString());

                txtnombre.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                txtCodSAC.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["CodSAC"].Value.ToString();
                txtpreciocompra.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["costo"].Value.ToString();
                txtprecioventa.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["precio"].Value.ToString();
                txtexistencia.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Existencia"].Value.ToString();
                txtmarca.Text = dgvfiltrarproductos.Rows[e.RowIndex].Cells["Marca"].Value.ToString();
            }

            btnModificar.Enabled = true;


        }

        private void frmProductos_Load(object sender, EventArgs e)
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

        private void btnBuscarmarca_Click(object sender, EventArgs e)
        {
            frmbuscarmarca bp = new frmbuscarmarca();
            if (bp.ShowDialog() == DialogResult.OK)
            {
                txtmarca.Text = bp.CodMarca.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
           // frmMenuprincipal inicio = new frmMenuprincipal();
            //inicio.Show();
        }
    }
}
