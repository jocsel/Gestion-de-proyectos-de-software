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
    public partial class frmVenta : Form
    {
        Eventa ventas = new Eventa();
        int x;
        public frmVenta()
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
            var lista = (from d in ventas.listadetalle
                         select new
                         {
                             //d.ventas.idventas,
                             d.producto.Codproducto,
                             d.producto.Producto,
                             d.producto.Precio,
                             d.Cantidad,
                             d.Totaldetalle
                         }).ToList();
            dgvventas.DataSource = lista;
        

        }
        private void frmVenta_Load(object sender, EventArgs e)
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
            txtbuscarusuario.Enabled = true;
            txtbuscarcliente.Enabled = true;
            mkfecha.Enabled = true;
            dtpHora.Enabled = true;
            txtdescuento.Enabled = true;
            txtproducto.Enabled = true;
            txtprecio.Enabled = true;
            txtnombre.Enabled = true;
            txtCantidad.Enabled = true;
          
        }
        public void Deshabilitar()
        {
            txtbuscarusuario.Enabled = false;
            txtbuscarcliente.Enabled = false;
            mkfecha.Enabled = false;
            dtpHora.Enabled = false;
            txtdescuento.Enabled = false;
            txtproducto.Enabled = false;
            txtprecio.Enabled = false;
            txtnombre.Enabled = false;
            txtCantidad.Enabled = false;
          
        }

        public void Limpiar()
        {
            int d ,x;
            d = 0 * 0;
            x = 0 * 0;
            txtCantidad.Text = x.ToString();
            txtdescuento.Text = d.ToString();
            txtTotalDolares.Text = "";
            txtbuscarusuario.Text = "";
            txtbuscarcliente.Text = "";
            mkfecha.Text = "";
            dtpHora.Text = "";
         // txtdescuento.Text = "";
            txtbuscarclientenombre.Text = "";
            txtbuscarusuarionombre.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtnombre.Text = "";
         //   txtCantidad.Text = "";
            


        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            Deshabilitar();

        

            mkfecha.Focus();
            btnagregar.Enabled = true;
            btnagregar.Enabled = true;
            dgvventas.DataSource = null;
            Habilitar();
            txtproducto.Enabled = false;
            txttotalCordobas.Enabled = false;
            btnbuscarproducto.Enabled = true;
            txtbuscarcliente.Enabled = false;
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
            mkfecha.Enabled = false;
            txttotalCordobas.Enabled = false;

            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
              
                ventas.Cliente.idCliente = Convert.ToInt32(txtbuscarcliente.Text);
                ventas.Usuario.idUsuario = Convert.ToInt32(txtbuscarusuario.Text);
                ventas.FechaFactura = mkfecha.Value;
               // ventas.HoraFactura = dtpHora.Value;
                
              
                if (rbtEfectivo.Checked == true)
                {
                    ventas.Tipopago = "Efectivo";
                }
                else
                {
                    ventas.Tipopago = "Tarjeta";
                   
                }
                ventas.Estado = cmbEstado.Text;
                ventas.Subtotal = Convert.ToDecimal(txtsubtotal.Text);
                ventas.Descuento = Convert.ToDecimal(txtdescuento.Text);
                ventas.TotalCordobas = Convert.ToDecimal(txttotalCordobas.Text);
                ventas.TotalDolares = Convert.ToDecimal(txtTotalDolares.Text);
                Nventa gestionventas = new Nventa();
                gestionventas.agregarventa(ventas);
                MessageBox.Show("Se agrego la venta correctamente", "VENTA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ActualizarLista();
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

            FrmReporteVenta x = new FrmReporteVenta();
            x.Show();
            this.Close();
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            Deshabilitar();
            Limpiar();
            txtdescuento.Text = "";
            txtbuscarcliente.Enabled = false;
            txtbuscarusuario.Enabled = false;
            btnbuscarcliente.Enabled = false;
            Btnbuscarusuario.Enabled = false;
            btnbuscarproducto.Enabled = false;
            btnCancelar.Enabled = false;
            btnagregar.Enabled = false;
            btneliminarproductos.Enabled = false;
            txttotalCordobas.Enabled = false;
        }

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            frmbuscarcliente bc = new frmbuscarcliente();
            if (bc.ShowDialog() == DialogResult.OK)
            {
                txtbuscarcliente.Text = bc.idcliente.ToString();
                txtbuscarclientenombre.Text = bc.nombre.ToString();
            }
        }

        private void btnbuscarproducto_Click(object sender, EventArgs e)
        {
            frmBuscarproducto bp = new frmBuscarproducto();
            if (bp.ShowDialog() == DialogResult.OK)
            {

                txtproducto.Text = bp.Codproducto.ToString();
                txtprecio.Text = bp.Costo.ToString();            
                txtnombre.Text = bp.Nombre_Producto.ToString();
                txtExistencias.Text = bp.existencias.ToString();

            }
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
        private void calculartotal()
        {

            double sumatoria = 0;
            double totalcordobas = 0;
            double totaldolares= 0;
            double descuento = 0;
            double descuentox = 0;
            double iva = 0;
            double ivax = 0;
            double y = 0;

            foreach (Edetalleventa row in ventas.listadetalle)
            {
                sumatoria += Convert.ToInt32(row.Totaldetalle);
            }
            //APLICAMOS EL DESCUENTO
            descuentox = Convert.ToDouble(txtdescuento.Text);
            //APLICAMOS EL IVA
            ivax = (sumatoria * 0.15);
            //EL IVA MAS LA SUMATORIA DE TODOS LOS PRODUCTOS QUE ESTAN EN EL DATAGRIDVIEW
            iva = ((sumatoria * 0.15) + sumatoria) ;

            txtiva.Text = ivax.ToString();        
            //SACAR EL DESCUENTO
            descuento = iva * (descuentox / 100);
            totalcordobas = iva - descuento;
        
            txtsubtotal.Text = sumatoria.ToString();
            txttotalCordobas.Text = totalcordobas.ToString();
            totaldolares = (totalcordobas / 30.9);

           this.txtTotalDolares.Text = totaldolares.ToString("0.##");

        }

     

        private void btnagregar_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt32(txtCantidad.Text);
            try
            {
                

                if (string.IsNullOrEmpty(txtproducto.Text))
                {

                    MessageBox.Show("Debe ingresar un producto");
                    return;
                }
                else
                {
                    if (x <= 0)
                    {
                        MessageBox.Show("Debe ingresar la cantidad de productos a vender");
                    }
                    else
                    {
                        if (Convert.ToInt32(txtExistencias.Text) >= Convert.ToInt32(txtCantidad.Text))
                        {
                            Edetalleventa nuevas = new Edetalleventa();
                            nuevas.Cantidad = Convert.ToInt32(txtCantidad.Text);
                            nuevas.producto.Codproducto = Convert.ToInt32(txtproducto.Text);
                            nuevas.producto.Precio = Convert.ToDecimal(txtprecio.Text);
                            nuevas.Totaldetalle = Convert.ToDecimal(nuevas.Cantidad * nuevas.producto.Precio);
                            nuevas.producto.Producto = txtnombre.Text;
                            ventas.listadetalle.Add(nuevas);
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
                        else
                        {
                            MessageBox.Show("EXISTENCIAS INSUFICIENTES");

                        }
                    }
                }

            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminarproductos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow fila in dgvventas.SelectedRows)
                {
                    foreach (Edetalleventa item in ventas.listadetalle)
                    {
                        if (item.producto.Codproducto == Convert.ToInt32(fila.Cells["Codproducto"].Value.ToString()))
                        {
                            ventas.listadetalle.Remove(item);
                            break;
                        }
                    }
                }
                ActualizarLista2();
                calculartotal();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttotalCordobas_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtbuscarcliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void dgvventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
