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
    public partial class frmProveedor : Form
    {
        List<EProveedor> ListaProveedor;
        bool modificar;
        public frmProveedor()
        {
            InitializeComponent();
            Deshabilitar();
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {

            actualizargrid();
            
        
        }

        private void actualizargrid()
        {
            try
            {
                NProveedor listaPro = new NProveedor();
                ListaProveedor = listaPro.ObtenerListaProveedor();

               var lista = (from pro in ListaProveedor
                             select new
                             {
                                 Nombres = pro.nombres,
                                 Apellidos = pro.apellidos,
                                 RUC = pro.RUC,
                                 Telefono = pro.telefono,
                                 Correo = pro.correo,
                                 Direccion = pro.direccion,
                                 Empresa = pro.nombreempresa,
                                 Estado = pro.estado,
                                 pro.idProveedor,

                             }).ToList();
                dgvProveedor.DataSource = lista;
                dgvProveedor.Columns["idProveedor"].Visible = false;

                ActualizarProveedor();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtnombre.Focus();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            dgvProveedor.Enabled = false;
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnmodificar.Enabled = false;
            btnnuevo.Enabled = false;
            modificar = true;
        }
        private void Deshabilitar()
        {
            
            txtnombre.Enabled = false;
            txtapellido.Enabled = false;
            txtcorreo.Enabled = false;
            txtdireccion.Enabled = false;
            txttelefono.Enabled = false;
            rbActivo.Enabled = false;
            rbInactivo.Enabled = false;
            txtruc.Enabled = false;
            txtempresa.Enabled = false;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
            rbnombre.Checked = true;
        }

        private void Habilitar()
        {
            txtnombre.Enabled = true;
            txtapellido.Enabled = true;
            txtcorreo.Enabled = true;
            txtdireccion.Enabled = true;
            txttelefono.Enabled = true;
            rbActivo.Checked = true;
            //rbInactivo.Checked = false;
            txtruc.Enabled = true;
            txtempresa.Enabled = true;
            rbInactivo.Enabled = true;
            rbActivo.Enabled = true;
        }

        private void Limpiar()
        {

            txtnombre.Text = "";
            txtapellido.Text = "";
            txtcorreo.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtnombre.Tag = "";
            txtruc.Text = "";
            txtempresa.Text = "";
        }

        public void ActualizarProveedor()
        {
            NProveedor gestionarProveedor = new NProveedor();
            ListaProveedor = gestionarProveedor.ObtenerListaProveedor();

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            dgvProveedor.Enabled = true;
            btnguardar.Enabled = false;
            btnmodificar.Enabled = false;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EProveedor modProveedor = new EProveedor();
                    modProveedor.idProveedor = Convert.ToInt32(txtnombre.Tag.ToString());
                    modProveedor.nombres = txtnombre.Text;
                    modProveedor.apellidos = txtapellido.Text;
                    modProveedor.RUC = txtruc.Text;
                    modProveedor.telefono = txttelefono.Text;
                    modProveedor.correo = txtcorreo.Text;
                    modProveedor.direccion = txtdireccion.Text;
                    if (rbActivo.Checked == true) { modProveedor.estado = true; } else { modProveedor.estado = false; }
                    modProveedor.nombreempresa = txtempresa.Text;

                    NProveedor gestionarProveedor = new NProveedor();
                    gestionarProveedor.Modificar(modProveedor);

                    MessageBox.Show("Se modifico correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProveedor.Enabled = true;
                }
                else
                {
                    EProveedor NuevoProveedor = new EProveedor();
                    NuevoProveedor.nombres = txtnombre.Text;
                    NuevoProveedor.apellidos = txtapellido.Text;
                    NuevoProveedor.RUC = txtruc.Text;
                    NuevoProveedor.telefono = txttelefono.Text;
                    NuevoProveedor.correo = txtcorreo.Text;
                    NuevoProveedor.direccion = txtdireccion.Text;
                    if (rbActivo.Checked == true) { NuevoProveedor.estado = true; } else { NuevoProveedor.estado = false; }
                    NuevoProveedor.nombreempresa = txtempresa.Text;


                    NProveedor gestionarProveedor = new NProveedor();
                    gestionarProveedor.Agregar(NuevoProveedor);

                    MessageBox.Show("Se guardo correctamente", "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ActualizarProveedor();
                //dgvProveedor.DataSource = ListaProveedor;
                actualizargrid();
                Limpiar();
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                modificar = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtnombre.Tag = Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells["idProveedor"].Value.ToString());

                if (dgvProveedor.Rows[e.RowIndex].Cells["nombres"].Value == null)
                    txtnombre.Text = "";
                else
                    txtnombre.Text = dgvProveedor.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                if (dgvProveedor.Rows[e.RowIndex].Cells["apellidos"].Value == null)
                    txtapellido.Text = "";
                else
                    txtapellido.Text = dgvProveedor.Rows[e.RowIndex].Cells["apellidos"].Value.ToString();
                if (dgvProveedor.Rows[e.RowIndex].Cells["RUC"].Value == null)
                    txtruc.Text = "";
                else
                    txtruc.Text = dgvProveedor.Rows[e.RowIndex].Cells["RUC"].Value.ToString();

                if (dgvProveedor.Rows[e.RowIndex].Cells["telefono"].Value == null)
                    txttelefono.Text = "";
                else
                    txttelefono.Text = dgvProveedor.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                if (dgvProveedor.Rows[e.RowIndex].Cells["correo"].Value == null)
                    txtcorreo.Text = "";
                else
                    txtcorreo.Text = dgvProveedor.Rows[e.RowIndex].Cells["correo"].Value.ToString();
                if (dgvProveedor.Rows[e.RowIndex].Cells["direccion"].Value == null)
                    txtdireccion.Text = "";
                else
                    txtdireccion.Text = dgvProveedor.Rows[e.RowIndex].Cells["direccion"].Value.ToString();

                if (dgvProveedor.Rows[e.RowIndex].Cells["estado"].Value == null)
                    rbInactivo.Checked = false;
                else
                    rbActivo.Checked = bool.Parse(dgvProveedor.Rows[e.RowIndex].Cells["estado"].Value.ToString());



                if (dgvProveedor.Rows[e.RowIndex].Cells["Empresa"].Value == null)
                    txtempresa.Text = "";
                else
                    txtempresa.Text = dgvProveedor.Rows[e.RowIndex].Cells["Empresa"].Value.ToString();


                btnmodificar.Enabled = true;
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnnuevo.Enabled = true;


            }
        }

        public void filtrar()
        {


            if (rbnombre.Checked)
            {
                var resultado = (
               from Proveedor in ListaProveedor
               where Proveedor.nombres.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   Nombres = Proveedor.nombres,
                   Apellidos = Proveedor.apellidos,
                   RUC = Proveedor.RUC,
                   Telefono = Proveedor.telefono,
                   Correo = Proveedor.correo,
                   Direccion = Proveedor.direccion,
                   Empresa = Proveedor.nombreempresa,
                   Estado = Proveedor.estado,
                   Proveedor.idProveedor,

               }).ToList();
                dgvProveedor.DataSource = resultado;

            }
            if (rbruc.Checked)
            {
                var resultado = (
               from Proveedor in ListaProveedor
               where Proveedor.RUC.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   Nombres = Proveedor.nombres,
                   Apellidos = Proveedor.apellidos,
                   RUC = Proveedor.RUC,
                   Telefono = Proveedor.telefono,
                   Correo = Proveedor.correo,
                   Direccion = Proveedor.direccion,
                   Empresa = Proveedor.nombreempresa,
                   Estado = Proveedor.estado,
                   Proveedor.idProveedor,

               }).ToList();
                dgvProveedor.DataSource = resultado;

            }
            if (rbempresa.Checked)
            {
                var resultado = (
               from Proveedor in ListaProveedor
               where Proveedor.nombreempresa.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   Nombres = Proveedor.nombres,
                   Apellidos = Proveedor.apellidos,
                   RUC = Proveedor.RUC,
                   Telefono = Proveedor.telefono,
                   Correo = Proveedor.correo,
                   Direccion = Proveedor.direccion,
                   Empresa = Proveedor.nombreempresa,
                   Estado = Proveedor.estado,
                   Proveedor.idProveedor,

               }).ToList();
                dgvProveedor.DataSource = resultado;

            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

      

        private void pictureBox8_Click(object sender, EventArgs e)
        {

           
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        }




    }

