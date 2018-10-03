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
using Presentacion.Reportes;

namespace Presentacion
{
    public partial class frmCompra : Form
    {
        Ecompra compra = new Ecompra();
        List<DataGridViewRow> list = new List<DataGridViewRow>();
        int x;
      
        public frmCompra()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {
            //Nventas gestionproduucto = new Nventas();
            //listaventas = gestionproduucto.obtenerlistventa();
        }
        private void ActualizarLista2()
        {

            //Ndetalleventa gestiondetalle = new Ndetalleventa();
            //listadetalle = gestiondetalle.obtenerlistdetalle();
            var lista = (from d in compra.listadetalle
                         select new
                         {
                             //d.ventas.idventas,
                             d.producto.Codproducto,
                             d.producto.Producto,
                             d.producto.Precio,
                             d.Cantidad,
                             d.Total
                         }).ToList();       
            dgvventas.DataSource = lista;




        }
    

        private void frmCompra_Load(object sender, EventArgs e)
        {
            try
            {

                ActualizarLista2();
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Habilitar()
        {
            btncrearproducto.Enabled = true;
            txtbuscarusuario.Enabled = true;
            txtbuscaridproveedor.Enabled = true;
            dtpfecha.Enabled = true;
            dtpHora.Enabled = true;
            txtdescuento.Enabled = true;
            txtproducto.Enabled = true;
            txtprecio.Enabled = true;
            txtnombre.Enabled = true;
            txtCantidad.Enabled = true;
            rbtEfectivo.Enabled = true;
            radioButton2.Enabled = true;
            cmbEstado.Enabled = true;

        }
        public void Deshabilitar()
        {
            btncrearproducto.Enabled = false;
            txtbuscarusuario.Enabled = false;
            txtbuscaridproveedor.Enabled = false;
            dtpfecha.Enabled = false;
            dtpHora.Enabled = false;
            txtdescuento.Enabled = false;
            txtproducto.Enabled = false;
            txtprecio.Enabled = false;
            txtnombre.Enabled = false;
            rbtEfectivo.Enabled = false;
            radioButton2.Enabled = false;
            txtCantidad.Enabled = false;
            cmbEstado.Enabled =false;


        }
        public void Limpiar()
        {
            int d , x;
            x = 0 * 0;
            d = 0 * 0;
            txtdescuento.Text = d.ToString();
            txtCantidad.Text = x.ToString();
            txtbuscarusuario.Text = "";
            txtbuscaridproveedor.Text = "";
            dtpfecha.Text = "";
            dtpHora.Text = "";
            // txtdescuento.Text = "";
            txtbuscarproveedornombre.Text = "";
            txtbuscarusuarionombre.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtnombre.Text = "";
        
            cmbEstado.Text = "";



        }



        private void button1_Click(object sender, EventArgs e)
        {
            frmProductos p = new frmProductos();
            p.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvventas.DataSource = null;
            Deshabilitar();



            dtpfecha.Focus();
            btnagregar.Enabled = true;
            btnagregar.Enabled = true;
            btncrearproducto.Enabled = true;
          
            Habilitar();
            
            txtproducto.Enabled = false;
            txttotalCordobas.Enabled = false;
            btnbuscarproducto.Enabled = true;
            txtbuscaridproveedor.Enabled = false;
            txtbuscarusuario.Enabled = false;
            txttotalCordobas.Enabled = true;
            btnbuscarcliente.Enabled = true;
            Btnbuscarusuario.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btneliminarproductos.Enabled = true;
            txtprecio.Enabled = false;
            txtnombre.Enabled = false;
            txtCantidad.Enabled = true;
            dtpfecha.Enabled = false;
            txttotalCordobas.Enabled = false;
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            try
            {

                compra.Proveedor.idProveedor = Convert.ToInt32(txtbuscaridproveedor.Text);
                compra.Usuario.idUsuario = Convert.ToInt32(txtbuscarusuario.Text);
                compra.FechaFactura = dtpfecha.Value;
                compra.Estado = cmbEstado.Text;

                if (rbtEfectivo.Checked == true)
                {
                    compra.Tipopago = "Efectivo";
                }
                else
                {
                    compra.Tipopago = "Tarjeta";

                }
                compra.Subtotal = Convert.ToDecimal(txtsubtotal.Text);
                compra.Descuento = Convert.ToDecimal(txtdescuento.Text);
                compra.TotalCordobas = Convert.ToDecimal(txttotalCordobas.Text);
                compra.TotalDolares = Convert.ToDecimal(txtTotalDolares.Text);
                Ncompra gestionventas = new Ncompra();
                gestionventas.agregarcompra(compra);
                MessageBox.Show("Se agrego la compra correctamente", "COMPRA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ActualizarLista2();
                Limpiar();
                Deshabilitar();
                btnagregar.Enabled = false;
                btnbuscarcliente.Enabled = false;
                Btnbuscarusuario.Enabled = false;
                txttotalCordobas.Enabled = false;
                txttotalCordobas.Clear();
                txtsubtotal.Clear();

                dgvventas.DataSource = null;
                btnagregar.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            FrmReporteCompra y = new FrmReporteCompra();
            y.Show();
                this.Close();
            
            
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            dgvventas.DataSource = null;
            Deshabilitar();
            Limpiar();
            txtdescuento.Text = "";
            txtbuscaridproveedor.Enabled = false;
            txtbuscarusuario.Enabled = false;
            btnbuscarcliente.Enabled = false;
            Btnbuscarusuario.Enabled = false;
            btnbuscarproducto.Enabled = false;
            btncrearproducto.Enabled = false;
            btnCancelar.Enabled = false;
            btnagregar.Enabled = false;
            btneliminarproductos.Enabled = false;
            txttotalCordobas.Enabled = false;
        }
    

        private void Btnbuscarusuario_Click(object sender, EventArgs e)
        {

            frmbuscarusuario bc = new frmbuscarusuario();
            if (bc.ShowDialog() == DialogResult.OK)
            {
                txtbuscarusuario.Text = bc.IdUsuario.ToString();
                txtbuscarusuarionombre.Text = bc.Nombre_Usuario.ToString();
            }
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {

            frmbuscarproveedor bp = new frmbuscarproveedor();
            if (bp.ShowDialog() == DialogResult.OK)
            {

                txtbuscaridproveedor.Text = bp.Id_Proveedor.ToString();
                txtbuscarproveedornombre.Text = bp.Nombre_Proveedor.ToString();
              


            }

        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            frmBuscarproductoCompra bp = new frmBuscarproductoCompra();
            if (bp.ShowDialog() == DialogResult.OK)
            {

                txtproducto.Text = bp.Codproducto.ToString();
                txtprecio.Text = bp.Precio.ToString();
                txtnombre.Text = bp.Nombre_Producto.ToString();


            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            int x1;
            x1 = Convert.ToInt32(txtCantidad.Text);
            try
            {
                if (string.IsNullOrEmpty(txtproducto.Text))
                {

                    MessageBox.Show("Debe ingresar un producto");
                    return;
                }
                else
                {

                    if (x1 <= 0)
                    {
                        MessageBox.Show("Debe ingresar la cantidad de productos a vender");
                    }
                    else
                    {
                        EdetalleCompra nuevas = new EdetalleCompra();
                        nuevas.Cantidad = Convert.ToInt32(txtCantidad.Text);
                        nuevas.producto.Codproducto = Convert.ToInt32(txtproducto.Text);
                        nuevas.producto.Precio = Convert.ToDecimal(txtprecio.Text);
                        nuevas.Total = Convert.ToDecimal(nuevas.Cantidad * nuevas.producto.Precio);
                        nuevas.producto.Producto = txtnombre.Text;
                        compra.listadetalle.Add(nuevas);
                        ActualizarLista2();
                        calculartotal();
                        Deshabilitar();
                        txtCantidad.Enabled = true;
                        btnGuardar.Enabled = true;
                        btnCancelar.Enabled = true;
                        btnNuevo.Enabled = true;
                        txtdescuento.Enabled = true;
                        txtproducto.Text = "";
                        txtprecio.Text = "";
                        txtnombre.Text = "";
                        txtCantidad.Text = "";
                        txtprecio.Text = "";
                    }
                }


               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            radioButton2.Enabled = true;
            rbtEfectivo.Enabled = true;
        }

        private void dgvventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calculartotal()
        {

            double sumatoria = 0;
            double totalcordobas = 0;
            double totaldolares = 0;
            double descuento = 0;
            double descuentox = 0;
            double iva = 0;
            double ivax = 0;
            double y = 0;

            foreach (EdetalleCompra row in compra.listadetalle)
            {
                sumatoria += Convert.ToInt32(row.Total);
            }

            descuentox = Convert.ToDouble(txtdescuento.Text);
            ivax = (sumatoria * 0.15);
            iva = ((sumatoria * 0.15) + sumatoria);
            txtiva.Text = ivax.ToString();
            descuento = iva * (descuentox / 100);
            totalcordobas = iva - descuento;
            txtsubtotal.Text = sumatoria.ToString();
            txttotalCordobas.Text = totalcordobas.ToString();

            totaldolares = totalcordobas / 30.9;





          

            this.txtTotalDolares.Text = totaldolares.ToString("0.##");

        }

        private void dgvventas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtiva_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            //frmMenuprincipal inicio = new frmMenuprincipal();
            //inicio.Show();
        }

        private void btneliminarproductos_Click(object sender, EventArgs e)
        {
           
        }

        private void dtpHora_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtbuscarusuarionombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscaridproveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscarusuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
