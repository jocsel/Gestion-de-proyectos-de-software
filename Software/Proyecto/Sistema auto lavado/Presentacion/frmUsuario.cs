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
    public partial class frmUsuario : Form
    {
        public List<EUsuario> listarUsua;
        bool modificar;
        public void actualizarGrid() {
            NUsuario gestioUsuario = new NUsuario();
            listarUsua = gestioUsuario.SelectRow();
            var lista = (from usuario in listarUsua
                         select new
                         {

                             usuario.Empleado.nombres,
                             usuario.Empleado.cargo,
                             usuario.usuario,
                             usuario.password,
                             usuario.estado,
                             usuario.Permiso.facturar,
                             usuario.Permiso.personas,
                             usuario.Permiso.producto,
                             usuario.Permiso.reporte,
                             usuario.Permiso.mantenimiento,
                             usuario.Permiso.lavado,
                             usuario.Permiso.btnFacturar,
                             usuario.Permiso.btnUsuarios,
                             usuario.Permiso.btnProducto,
                             usuario.Permiso.btnMantenimiento,
                             usuario.Permiso.btnLavado,
                             usuario.Permiso.btnPersonas,
                             usuario.Permiso.btnFacturarCompra,
                             usuario.Permiso.logs,
                             usuario.idUsuario,
                             usuario.Permiso.PidUsuario,
                             usuario.Empleado.idEmpleado,
                         }).ToList();
            dgvUsuarios.DataSource = lista;
            dgvUsuarios.Columns["idUsuario"].Visible = false;
            dgvUsuarios.Columns["PidUsuario"].Visible = false;
            dgvUsuarios.Columns["idEmpleado"].Visible = false;
        }
        public frmUsuario()
        {
            InitializeComponent();
            Deshabilitar();
            btnCancelar.Enabled = false;
        }
        private void Deshabilitar()
        {
            txtContraseña.Enabled = false;
            txtEmpleado.Enabled = false;
            txtNombreUsuario.Enabled = false;
            cmbEstado.Enabled = false;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            
        }
        private void Habilitar()
        {
            txtContraseña.Enabled = true;
            txtEmpleado.Enabled = true;
            txtNombreUsuario.Enabled = true;
            cmbEstado.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = false;
            btnNuevo.Enabled = false;
            chkBtnFacturar.Enabled = true;
            chkBtnLavado.Enabled = true;
            chkBtnMantenimiento.Enabled = true;
            chkBtnPersonas.Enabled = true;
            chkBtnProducto.Enabled = true;
            chkBtnUsuarios.Enabled = true;
            chkFacturar.Enabled = true;
            chkLavado.Enabled = true;
            chkMantenimiento.Enabled = true;
            chkPersonas.Enabled = true;
            chkProductos.Enabled = true;
            chkReporte.Enabled = true;
            chkbtnFacComp.Enabled = true;
            chkLog.Enabled = true;
        }

        private void Limpiar()
        {

            txtContraseña.Text = "";
            txtEmpleado.Text = "";
            txtNombreUsuario.Text = "";
            cmbEstado.Text = "";
            chkBtnFacturar.Checked = false;
            chkBtnLavado.Checked = false;
            chkBtnMantenimiento.Checked = false;
            chkBtnPersonas.Checked = false;
            chkBtnProducto.Checked = false;
            chkBtnUsuarios.Checked = false;
            chkFacturar.Checked = false;
            chkLavado.Checked = false;
            chkMantenimiento.Checked = false;
            chkPersonas.Checked = false;
            chkProductos.Checked = false;
            chkReporte.Checked = false;
            chkbtnFacComp.Checked = false;
            chkLog.Checked = false;

        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            txtEmpleado.Enabled = false;
            btnEmpleado.Enabled = false;
            chkBtnFacturar.Enabled = false;
            chkBtnLavado.Enabled = false;
            chkBtnMantenimiento.Enabled = false;
            chkBtnPersonas.Enabled = false;
            chkBtnProducto.Enabled = false;
            chkBtnUsuarios.Enabled = false;
            chkFacturar.Enabled = false;
            chkLavado.Enabled = false;
            chkMantenimiento.Enabled = false;
            chkPersonas.Enabled = false;
            chkProductos.Enabled = false;
            chkReporte.Enabled = false;
            chkbtnFacComp.Enabled = false;
            chkLog.Enabled = false;
            try {
                actualizarGrid();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                if (modificar)
                {
                    EUsuario Uusuario = new EUsuario();
                    Uusuario.Permiso.PidUsuario = Convert.ToInt32(dgvUsuarios.Tag);
                    Uusuario.idUsuario = Convert.ToInt32(txtContraseña.Tag);
                    Uusuario.usuario = txtNombreUsuario.Text;
                    Uusuario.password = txtContraseña.Text;
                    Uusuario.Empleado.idEmpleado = Convert.ToInt32(txtEmpleado.Tag);
                    Uusuario.estado = cmbEstado.Text;
                    Uusuario.Permiso.facturar = chkFacturar.Checked;
                    Uusuario.Permiso.personas = chkPersonas.Checked;
                    Uusuario.Permiso.producto = chkProductos.Checked;
                    Uusuario.Permiso.reporte = chkReporte.Checked;
                    Uusuario.Permiso.mantenimiento = chkMantenimiento.Checked;
                    Uusuario.Permiso.lavado = chkLavado.Checked;
                    Uusuario.Permiso.btnFacturar = chkBtnFacturar.Checked;
                    Uusuario.Permiso.btnPersonas = chkBtnPersonas.Checked;
                    Uusuario.Permiso.btnProducto = chkBtnProducto.Checked;
                    Uusuario.Permiso.btnMantenimiento = chkBtnMantenimiento.Checked;
                    Uusuario.Permiso.btnLavado = chkBtnLavado.Checked;
                    Uusuario.Permiso.btnUsuarios = chkBtnUsuarios.Checked;
                    Uusuario.Permiso.btnFacturarCompra = chkbtnFacComp.Checked;
                    Uusuario.Permiso.logs = chkLog.Checked;

                    NUsuario UpRow = new NUsuario();
                    UpRow.UpdateRow(Uusuario);
                    MessageBox.Show("Se modifico sastifactoriamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else {
                    EUsuario Iusuario = new EUsuario();
                    Iusuario.usuario = txtNombreUsuario.Text;
                    Iusuario.password = txtContraseña.Text;
                    Iusuario.Empleado.idEmpleado = Convert.ToInt32(txtEmpleado.Tag);
                    Iusuario.estado = cmbEstado.Text;
                    Iusuario.Permiso.facturar = chkFacturar.Checked;
                    Iusuario.Permiso.personas = chkPersonas.Checked;
                    Iusuario.Permiso.producto = chkProductos.Checked;
                    Iusuario.Permiso.reporte = chkReporte.Checked;
                    Iusuario.Permiso.mantenimiento = chkMantenimiento.Checked;
                    Iusuario.Permiso.lavado = chkLavado.Checked;
                    Iusuario.Permiso.btnFacturar = chkBtnFacturar.Checked;
                    Iusuario.Permiso.btnPersonas = chkBtnPersonas.Checked;
                    Iusuario.Permiso.btnProducto = chkBtnProducto.Checked;
                    Iusuario.Permiso.btnMantenimiento = chkBtnMantenimiento.Checked;
                    Iusuario.Permiso.btnLavado = chkBtnLavado.Checked;
                    Iusuario.Permiso.btnUsuarios = chkBtnUsuarios.Checked;
                    Iusuario.Permiso.btnFacturarCompra = chkbtnFacComp.Checked;
                    Iusuario.Permiso.logs = chkLog.Checked;

                    NUsuario InsertRow = new NUsuario();
                    InsertRow.InsertRow(Iusuario);
                    MessageBox.Show("Se guardo sastifactoriamente", "Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                actualizarGrid();
                Deshabilitar();
                btnCancelar.Enabled = false;
                btnNuevo.Enabled = true;
                Limpiar();
                modificar = false;

            }
            catch ( Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            txtEmpleado.Enabled = false;
            btnEmpleado.Enabled = true;
            modificar = true;
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEmpleado.Text = dgvUsuarios.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                txtEmpleado.Tag = dgvUsuarios.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString();
                txtNombreUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["usuario"].Value.ToString();
                txtContraseña.Text = dgvUsuarios.Rows[e.RowIndex].Cells["password"].Value.ToString();
                cmbEstado.Text = dgvUsuarios.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                chkFacturar.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["facturar"].Value.ToString());
                chkPersonas.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["personas"].Value.ToString());
                chkProductos.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["producto"].Value.ToString());
                chkReporte.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["reporte"].Value.ToString());
                chkMantenimiento.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["mantenimiento"].Value.ToString());
                chkLavado.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["lavado"].Value.ToString());
                chkBtnFacturar.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnFacturar"].Value.ToString());
                chkBtnPersonas.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnPersonas"].Value.ToString());
                chkBtnProducto.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnProducto"].Value.ToString());
                chkBtnMantenimiento.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnMantenimiento"].Value.ToString());
                chkBtnLavado.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnLavado"].Value.ToString());
                chkBtnUsuarios.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnUsuarios"].Value.ToString());
                chkbtnFacComp.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["btnFacturarCompra"].Value.ToString());
                chkLog.Checked = Convert.ToBoolean(dgvUsuarios.Rows[e.RowIndex].Cells["logs"].Value.ToString());

                txtContraseña.Tag = dgvUsuarios.Rows[e.RowIndex].Cells["idUsuario"].Value.ToString();
                dgvUsuarios.Tag = dgvUsuarios.Rows[e.RowIndex].Cells["PidUsuario"].Value.ToString();

                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
                btnGuardar.Enabled = false;
                btnNuevo.Enabled = false;
                chkBtnFacturar.Enabled = false;
                chkBtnLavado.Enabled = false;
                chkBtnMantenimiento.Enabled = false;
                chkBtnPersonas.Enabled = false;
                chkBtnProducto.Enabled = false;
                chkBtnUsuarios.Enabled = false;
                chkFacturar.Enabled = false;
                chkLavado.Enabled = false;
                chkMantenimiento.Enabled = false;
                chkPersonas.Enabled = false;
                chkProductos.Enabled = false;
                chkReporte.Enabled = false;
                chkLog.Enabled = false;
                chkbtnFacComp.Enabled = false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            txtNombreUsuario.Focus();
            btnCancelar.Enabled = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            txtEmpleado.Enabled = false;
            btnEmpleado.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
            txtEmpleado.Enabled = false;
            btnEmpleado.Enabled = false;
            chkBtnFacturar.Enabled = false;
            chkBtnLavado.Enabled = false;
            chkBtnMantenimiento.Enabled = false;
            chkBtnPersonas.Enabled = false;
            chkBtnProducto.Enabled = false;
            chkBtnUsuarios.Enabled = false;
            chkFacturar.Enabled = false;
            chkLavado.Enabled = false;
            chkMantenimiento.Enabled = false;
            chkPersonas.Enabled = false;
            chkProductos.Enabled = false;
            chkReporte.Enabled = false;
            chkLog.Enabled = false;
            chkbtnFacComp.Enabled = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado buscarEmpleado = new frmBuscarEmpleado();
            if (buscarEmpleado.ShowDialog() == DialogResult.OK)
                txtEmpleado.Tag = buscarEmpleado.idEmpleado.ToString();
                txtEmpleado.Text = buscarEmpleado.empleado.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

