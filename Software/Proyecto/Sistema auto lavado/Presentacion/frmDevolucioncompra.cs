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
    public partial class frmDevolucioncompra : Form
    {
        public readonly Ndetallecompra _Ndetallecompra = new Ndetallecompra();
        EdevolucionCompra devolucion = new EdevolucionCompra();
        List<EdetalleCompra> listadetallev = new List<EdetalleCompra>();
        Ecompra ventas = new Ecompra();
        public int Numventa;
        public frmDevolucioncompra()
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
                             d.Total
                         }).ToList();
            dgvdevolucion.DataSource = lista;

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
            dtpfecha.Enabled = true;
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
            dtpfecha.Enabled = false;
            dtpHora.Enabled = false;
            txtdescuento.Enabled = false;
            txtproducto.Enabled = false;
            txtprecio.Enabled = false;
            txtnombre.Enabled = false;
            txtCantidad.Enabled = false;

        }
        public void Limpiar()
        {
            int d;
            d = 0 * 0;
            txtdescuento.Text = d.ToString();

            txtbuscarusuario.Text = "";
            txtbuscarcliente.Text = "";
            dtpfecha.Text = "";
            dtpHora.Text = "";
            // txtdescuento.Text = "";
            txtbuscarclientenombre.Text = "";
            txtbuscarusuarionombre.Text = "";
            txtproducto.Text = "";
            txtprecio.Text = "";
            txtnombre.Text = "";
            txtCantidad.Text = "";



        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Deshabilitar();



            dtpfecha.Focus();
            btnagregar.Enabled = true;
            btnagregar.Enabled = true;
            dgvdevolucion.DataSource = null;
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
            //btnNuevo.Enabled = false;
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
                devolucion.Compra.Idcompra = Convert.ToInt32(txtNumventas.Text);
                devolucion.Usuario.idUsuario = Convert.ToInt32(txtbuscarusuario.Text);
                devolucion.Fecha = Convert.ToDateTime(dtpfecha.Value);
                devolucion.Observacion = txtobservacion.Text;

                Ecompra editar = new Ecompra();
                editar.Idcompra = Convert.ToInt32(txtNumventas.Text);
                editar.Estado = cmbEstado.Text;
                Ncompra gestion = new Ncompra();
                gestion.modificarestado(editar);

                MessageBox.Show("Se realizo la devolucion correctamente", "DEVOLUCION", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (DataGridViewRow item in dgvdevolucion.Rows)
                {

                    EdetalledevolucionCOMPRA nuevas = new EdetalledevolucionCOMPRA();
                    nuevas.Cantidad = Convert.ToInt32(item.Cells["Cantidad"].Value.ToString());
                    nuevas.producto = new Eproductos() { Codproducto = Convert.ToInt32(item.Cells["Codproducto"].Value.ToString()) };
                    devolucion.listadetalle.Add(nuevas);
                }
                NdevolucionCompra gestiondevolucion = new NdevolucionCompra();

                gestiondevolucion.agregardevolucioncompra(devolucion);
                ActualizarLista();
                Limpiar();
                Deshabilitar();
                btnagregar.Enabled = false;
                btnbuscarcliente.Enabled = false;
                Btnbuscarusuario.Enabled = false;
                txttotalCordobas.Enabled = false;
                txttotalCordobas.Clear();
                txtsubtotal.Clear();
                dgvdevolucion.DataSource = null;
                btnagregar.Enabled = false;
                btnGuardar.Enabled = false;
                btnCancelar.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Limpiar();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
            //   btnNuevo.Enabled = true;
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
            double totaldolares = 0;
            double descuento = 0;
            double descuentox = 0;
            double iva = 0;
            double ivax = 0;
            double y = 0;

            foreach (EdetalleCompra row in ventas.listadetalle)
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
            txtTotalDolares.Text = totaldolares.ToString();

        }



        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                //Edetalleventa nuevas = new Edetalleventa();
                //nuevas.Cantidad = Convert.ToInt32(txtCantidad.Text);
                //nuevas.producto.Codproducto = Convert.ToInt32(txtproducto.Text);
                //nuevas.producto.Precio = Convert.ToDecimal(txtprecio.Text);
                //nuevas.Totaldetalle = Convert.ToDecimal(nuevas.Cantidad * nuevas.producto.Precio);
                //nuevas.producto.Producto = txtnombre.Text;
                //ventas.listadetalle.Add(nuevas);
                //ActualizarLista2();
                //calculartotal();
                //Deshabilitar();
                //txtCantidad.Enabled = true;
                //btnGuardar.Enabled = true;
                //btnCancelar.Enabled = true;
                ////  btnNuevo.Enabled = true;
                //txtdescuento.Enabled = true;
                //txtproducto.Text = "";
                //txtprecio.Text = "";
                //txtnombre.Text = "";
                //txtCantidad.Text = "";
                //txtprecio.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminarproductos_Click(object sender, EventArgs e)
        {

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

        private void txtbuscarusuarionombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnagregarfactura_Click(object sender, EventArgs e)
        {
            frmbuscarfacturaCompra bc = new frmbuscarfacturaCompra();
            if (bc.ShowDialog() == DialogResult.OK)
            {
                txtNumventas.Text = bc.idcompra.ToString();
                txtbuscarcliente.Text = bc.idproveedor.ToString();
                txtbuscarusuario.Text = bc.idusuario.ToString();
                dtpfecha.Text = bc.fechafactura.ToString();

                rbtEfectivo.Text = bc.tipopago.ToString();

                if (rbtEfectivo.Text == "Efectivo")
                {
                    rbtEfectivo.Checked = true;

                }
                else
                {
                    rbtarjeta.Checked = true;
                }


                cmbEstado.Text = bc.estado.ToString();
                txtdescuento.Text = bc.descuento.ToString();
                txtsubtotal.Text = bc.subtotal.ToString();
                txttotalCordobas.Text = bc.totalcordobas.ToString();
                txtTotalDolares.Text = bc.totaldolares.ToString();


                listadetallev = _Ndetallecompra.obtenerlistdetallecomprax();
                var lista = (from d in listadetallev
                             where d.Compra.Idcompra == bc.idcompra
                             select new
                             {
                                 //d.ventas.idventas,

                                 d.Cantidad,
                                 d.producto.Codproducto,
                                 d.Compra.Idcompra,                            
                                 d.Total
                                 

                             }
                    ).ToList();
                dgvdevolucion.DataSource = lista;



                cmbEstado.Enabled = true;



      


            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
    }

}
