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
    public partial class frmLavado : Form
    {
        public List<ELavado> listaLavado;
        bool modificar;
        private void Deshabilitar()
        {
            dtpFecha.Enabled = false;
            txtplaca.Enabled = false;
            txtlavado.Enabled = false;
            txtgrupo.Enabled = false;
            txttotal.Enabled = false;
            btnguardar.Enabled = false;
            //btnmodificar.Enabled = false;
        }
        private void Habilitar()
        {
            dtpFecha.Enabled = true;
            txtplaca.Enabled = true;
            txtlavado.Enabled = true;
            txtgrupo.Enabled = true;
            txttotal.Enabled = true;
        }
        private void Limpiar()
        {

            dtpFecha.Text = "" ;
            txtplaca.Text = "";
            txtlavado.Text = "";
            txtgrupo.Text = "";
            txttotal.Text = "";
        }
        public frmLavado()
        {
            InitializeComponent();
            Deshabilitar();
        }
        public void actualizarGrid() {
            try {
                NLavado listar = new NLavado();
                listaLavado = listar.selectRow();
                var lista = (from lavado in listaLavado
                             select new
                             {
                                 lavado.idLavado,
                                 lavado.fecha,
                                 lavado.usuario.usuario,
                                Atendido_por = lavado.empleado.nombres,
                                 lavado.grupoTrabajadores.idGrupo,
                                 Grupo_Asignado=lavado.grupoTrabajadores.grupoTrabajadores,
                                 lavado.vehiculoLavado.idVehiculoLavado,
                                 lavado.vehiculoLavado.vehiculoLavado,
                                 lavado.servicioLavado.idServicioLavado,
                                 lavado.servicioLavado.servicioLavado,
                                 Grupo = lavado.grupoTrabajadores.idGrupo,
                                 lavado.LavadoVehiculo.idLavadoVehiculo,
                                 lavado.LavadoVehiculo.precio,
                                 lavado.placa,
                                 lavado.total,
                             }).ToList();
                dgvLavado.DataSource = lista;
                dgvLavado.Columns["idLavado"].Visible = false;
                dgvLavado.Columns["usuario"].Visible = false;
                dgvLavado.Columns["idGrupo"].Visible = false;
                dgvLavado.Columns["idVehiculoLavado"].Visible = false;
                dgvLavado.Columns["idServicioLavado"].Visible = false;
                dgvLavado.Columns["idLavadoVehiculo"].Visible = false;
                dgvLavado.Columns["precio"].Visible = false;
                dgvLavado.Columns["Grupo"].Visible = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
        
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmLavado_Load(object sender, EventArgs e)
        {
            btncancelar.Enabled = false;
            btnbuscaridLavadoV.Enabled = false;
            btnidgrupo.Enabled = false;
           // btnmodificar.Visible = false;
            //btnmodificar.Enabled = false;
            dtpFecha.Text = DateTime.Now.ToString();
            lblusuario.Text = Global.usuarioSesion.usuario;
            lblusuario.Visible = false;
            try {
                actualizarGrid();
            }
            catch (Exception es) {
                MessageBox.Show(es.Message);
            }
        }

        private void lblusuario_Click(object sender, EventArgs e)
        {
            
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar)
                {
                    ELavado UpdateLavado = new ELavado();
                    UpdateLavado.idLavado = Convert.ToInt32(dtpFecha.Tag);
                    UpdateLavado.total = Convert.ToDecimal(txttotal.Text);
                    UpdateLavado.fecha = Convert.ToDateTime(dtpFecha.Text);
                    UpdateLavado.placa = txtplaca.Text;
                    UpdateLavado.LavadoVehiculo.idLavadoVehiculo = Convert.ToInt32(txtlavado.Tag);
                    UpdateLavado.grupoTrabajadores.idGrupo = Convert.ToInt32(txtgrupo.Tag);
                    UpdateLavado.usuario.usuario = lblusuario.Text;
                    NLavado UL = new NLavado();
                    UL.UpdateRow(UpdateLavado);
                    MessageBox.Show("Modificado", "Lavado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    ELavado InserLavado = new ELavado();
                    InserLavado.total = Convert.ToDecimal(txttotal.Text);
                    InserLavado.fecha = Convert.ToDateTime(dtpFecha.Text);
                    InserLavado.placa = txtplaca.Text;
                    InserLavado.LavadoVehiculo.idLavadoVehiculo = Convert.ToInt32(txtlavado.Tag);
                    InserLavado.grupoTrabajadores.idGrupo = Convert.ToInt32(txtgrupo.Tag);
                    InserLavado.usuario.usuario = lblusuario.Text;
                    NLavado IL = new NLavado();
                    IL.InsertRow(InserLavado);
                    MessageBox.Show("Generado factura, por favor espera", "Lavado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmFacturaLavado factura = new frmFacturaLavado();
                    factura.idLavado = InserLavado.idLavado;
                    factura.ShowDialog();
                }
                actualizarGrid();
                Limpiar();
                dtpFecha.Enabled = false;
                Deshabilitar();
                btncancelar.Enabled = false;
                btnguardar.Enabled = false;
               // btnmodificar.Enabled = false;
                btnnuevo.Enabled = true;
                btnidgrupo.Enabled = false;
                btnbuscaridLavadoV.Enabled = false;
                txtgrupo.Enabled = false;
                txtlavado.Enabled = false;
                modificar = false;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } 
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {

            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnbuscaridLavadoV.Enabled = true;
            //btnmodificar.Enabled = false;
            btnidgrupo.Enabled = true;
            txtgrupo.Enabled = false;
            txttotal.Enabled = false;
            txtlavado.Enabled = false;
            dtpFecha.Enabled = false;
            modificar = true;
        }

        private void dgvLavado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtpFecha.Tag = dgvLavado.Rows[e.RowIndex].Cells["idLavado"].Value.ToString();
                txttotal.Text = dgvLavado.Rows[e.RowIndex].Cells["total"].Value.ToString();
                dtpFecha.Text = dgvLavado.Rows[e.RowIndex].Cells["fecha"].Value.ToString();
                txtplaca.Text = dgvLavado.Rows[e.RowIndex].Cells["placa"].Value.ToString();
                txtlavado.Tag = dgvLavado.Rows[e.RowIndex].Cells["idLavadoVehiculo"].Value.ToString();
                txtlavado.Text = dgvLavado.Rows[e.RowIndex].Cells["vehiculoLavado"].Value.ToString();
                txtgrupo.Tag = dgvLavado.Rows[e.RowIndex].Cells["idGrupo"].Value.ToString();
                txtgrupo.Text = dgvLavado.Rows[e.RowIndex].Cells["Grupo_Asignado"].Value.ToString();
                lblusuario.Text = dgvLavado.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
                //btnmodificar.Enabled = true;
                btncancelar.Enabled = true;
                btnguardar.Enabled = false;
                btnnuevo.Enabled = false;
                dtpFecha.Enabled = false;
                txtplaca.Enabled = false;
                txtlavado.Enabled = false;
                txtgrupo.Enabled = false;
                txttotal.Enabled = false;
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btncancelar.Enabled = true;
            btnguardar.Enabled = true;
            //btnmodificar.Enabled = false;
            btnidgrupo.Enabled = true;
            btnbuscaridLavadoV.Enabled = true;
            btnnuevo.Enabled = false;
            txtgrupo.Enabled = false;
            txtlavado.Enabled = false;
            dtpFecha.Enabled = false;
            txttotal.Enabled = false;
            dtpFecha.Text = DateTime.Now.ToString();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnnuevo.Enabled = true;
            btnguardar.Enabled = false;
            //btnmodificar.Enabled = false;
            btnidgrupo.Enabled = false;
            btnbuscaridLavadoV.Enabled = false;
            txtgrupo.Enabled = false;
            txtlavado.Enabled = false;
            txttotal.Enabled = false;
            btncancelar.Enabled = false;
            dtpFecha.Enabled = false;
        }

        private void btnbuscaridLavadoV_Click(object sender, EventArgs e)
        {
            frmBuscarLV LV = new frmBuscarLV();
            if (LV.ShowDialog() == DialogResult.OK) {
                txtlavado.Tag = LV.idLavadoVehiculo.ToString();
                txtlavado.Text = LV.vehiculo.ToString();
                txttotal.Text = LV.precio.ToString();
            }
        }

        private void btnidgrupo_Click(object sender, EventArgs e)
        {
            frmBuscarGrupo grupo = new frmBuscarGrupo();
            if (grupo.ShowDialog() == DialogResult.OK) {
                txtgrupo.Tag = grupo.idGrupo.ToString();
                txtgrupo.Text = grupo.grupo.ToString();
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
