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
    public partial class frmEmpleado : Form
    {
        //
        List<EEmpleado> listaEmpleado;
        bool modificar;
        public frmEmpleado()
        {
            InitializeComponent();
            Deshabilitar();
            btnGrupo.Enabled = false;
            btnArea.Enabled = false;
        }
        private void Deshabilitar()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtcedula.Enabled = false;
            txtcelular.Enabled = false;
            txtdireccion.Enabled = false;
            txtFechaNac.Enabled = false;
            txtSalario.Enabled = false;
            cmbcargo.Enabled = false;
            cmbEstado.Enabled = false;
            btnguardar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }
        private void Habilitar()
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtcedula.Enabled = true;
            txtcelular.Enabled = true;
            txtdireccion.Enabled = true;
            txtFechaNac.Enabled = true;
            txtSalario.Enabled = true;
            cmbcargo.Enabled = true;
            cmbEstado.Enabled = true;
        }
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtcedula.Text = "";
            txtcelular.Text = "";
            txtdireccion.Text = "";
            txtFechaNac.Text = "";
            txtSalario.Text = "";
            cmbcargo.Text = "";
            cmbEstado.Text = "";
            txtArea.Text = "";
            txtGrupo.Text = "";
        }
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            txtArea.Enabled = false;
            txtGrupo.Enabled = false;
            rbnombre.Checked = true;
            try
            {
                actualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void actualizarGrid()
        {
            NEmpleado gestioEmpleado = new NEmpleado();
            listaEmpleado = gestioEmpleado.listaEmpleado();

            var lista = (from empleado in listaEmpleado
                         select new
                         {
                             empleado.idEmpleado,
                             empleado.GrupoTrabajadores.idGrupo,
                             empleado.Area.idArea,
                             empleado.nombres,
                             empleado.apellidos,
                             empleado.fechaNacimiento,
                             empleado.cedula,
                             empleado.direccion,
                             empleado.celular,
                             empleado.salario,
                             empleado.cargo,
                             empleado.estado,
                             empleado.Area.area,
                             empleado.GrupoTrabajadores.grupoTrabajadores,
                         }).ToList();
            dgvEmpleado.DataSource = lista;
            dgvEmpleado.Columns["idEmpleado"].Visible = false;
            dgvEmpleado.Columns["idGrupo"].Visible = false;
            dgvEmpleado.Columns["idArea"].Visible = false;
        }
        public void filtrar()
        {

            if (rbnombre.Checked)
            {
                var resultado = (
                    from empleado in listaEmpleado
                    where empleado.nombres.ToUpper().StartsWith(textBox1.Text.ToUpper())
                    select new
                    {
                        empleado.idEmpleado,
                        empleado.GrupoTrabajadores.idGrupo,
                        empleado.Area.idArea,
                        empleado.nombres,
                        empleado.apellidos,
                        empleado.fechaNacimiento,
                        empleado.cedula,
                        empleado.direccion,
                        empleado.celular,
                        empleado.salario,
                        empleado.cargo,
                        empleado.estado,
                        empleado.Area.area,
                        empleado.GrupoTrabajadores.grupoTrabajadores,
                    }).ToList();

                dgvEmpleado.Columns["idEmpleado"].Visible = false;
                dgvEmpleado.Columns["idGrupo"].Visible = false;
                dgvEmpleado.Columns["idArea"].Visible = false;
                dgvEmpleado.DataSource = resultado;
            }
            if (rbtCedula.Checked)
            {
                var resultado = (
                    from empleado in listaEmpleado
                    where empleado.cedula.ToUpper().StartsWith(textBox1.Text.ToUpper())
                    select new
                    {
                        empleado.idEmpleado,
                        empleado.GrupoTrabajadores.idGrupo,
                        empleado.Area.idArea,
                        empleado.nombres,
                        empleado.apellidos,
                        empleado.fechaNacimiento,
                        empleado.cedula,
                        empleado.direccion,
                        empleado.celular,
                        empleado.salario,
                        empleado.cargo,
                        empleado.estado,
                        empleado.Area.area,
                        empleado.GrupoTrabajadores.grupoTrabajadores,
                    }).ToList();

                dgvEmpleado.Columns["idEmpleado"].Visible = false;
                dgvEmpleado.Columns["idGrupo"].Visible = false;
                dgvEmpleado.Columns["idArea"].Visible = false;
                dgvEmpleado.DataSource = resultado;
            }
            if (rbtApellido.Checked)
            {
                var resultado = (
                    from empleado in listaEmpleado
                    where empleado.apellidos.ToUpper().StartsWith(textBox1.Text.ToUpper())
                    select new
                    {
                        empleado.idEmpleado,
                        empleado.GrupoTrabajadores.idGrupo,
                        empleado.Area.idArea,
                        empleado.nombres,
                        empleado.apellidos,
                        empleado.fechaNacimiento,
                        empleado.cedula,
                        empleado.direccion,
                        empleado.celular,
                        empleado.salario,
                        empleado.cargo,
                        empleado.estado,
                        empleado.Area.area,
                        empleado.GrupoTrabajadores.grupoTrabajadores,
                    }).ToList();

                dgvEmpleado.Columns["idEmpleado"].Visible = false;
                dgvEmpleado.Columns["idGrupo"].Visible = false;
                dgvEmpleado.Columns["idArea"].Visible = false;
                dgvEmpleado.DataSource = resultado;
            }
            if (rbtCargo.Checked)
            {
                var resultado = (
                    from empleado in listaEmpleado
                    where empleado.cargo.ToUpper().StartsWith(textBox1.Text.ToUpper())
                    select new
                    {
                        empleado.idEmpleado,
                        empleado.GrupoTrabajadores.idGrupo,
                        empleado.Area.idArea,
                        empleado.nombres,
                        empleado.apellidos,
                        empleado.fechaNacimiento,
                        empleado.cedula,
                        empleado.direccion,
                        empleado.celular,
                        empleado.salario,
                        empleado.cargo,
                        empleado.estado,
                        empleado.Area.area,
                        empleado.GrupoTrabajadores.grupoTrabajadores,
                    }).ToList();

                dgvEmpleado.Columns["idEmpleado"].Visible = false;
                dgvEmpleado.Columns["idGrupo"].Visible = false;
                dgvEmpleado.Columns["idArea"].Visible = false;
                dgvEmpleado.DataSource = resultado;
            }
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modificar)
                {
                    EEmpleado UEmpleado = new EEmpleado();
                    UEmpleado.idEmpleado = Convert.ToInt32(txtNombre.Tag);
                    UEmpleado.apellidos = txtApellido.Text;
                    UEmpleado.cedula = txtcedula.Text;
                    UEmpleado.celular = Convert.ToInt32(txtcelular.Text);
                    UEmpleado.direccion = txtdireccion.Text;
                    UEmpleado.estado = cmbEstado.Text;
                    UEmpleado.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    UEmpleado.salario = Convert.ToDecimal(txtSalario.Text);
                    UEmpleado.nombres = txtNombre.Text;
                    UEmpleado.cargo = cmbcargo.Text;
                    UEmpleado.GrupoTrabajadores.idGrupo = Convert.ToInt32(txtGrupo.Tag);
                    UEmpleado.Area.idArea = Convert.ToInt32(txtArea.Tag);
                    NEmpleado Update = new NEmpleado();
                    Update.UpdateRow(UEmpleado);
                    MessageBox.Show("Se modifico sastifactoriamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    EEmpleado IEmpleado = new EEmpleado();
                    IEmpleado.apellidos = txtApellido.Text;
                    IEmpleado.cedula = txtcedula.Text;
                    IEmpleado.celular = Convert.ToInt32(txtcelular.Text);
                    IEmpleado.direccion = txtdireccion.Text;
                    IEmpleado.estado = cmbEstado.Text;
                    IEmpleado.fechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
                    IEmpleado.salario = Convert.ToDecimal(txtSalario.Text);
                    IEmpleado.nombres = txtNombre.Text;
                    IEmpleado.cargo = cmbcargo.Text;
                    IEmpleado.GrupoTrabajadores.idGrupo = Convert.ToInt32(txtGrupo.Tag);
                    IEmpleado.Area.idArea = Convert.ToInt32(txtArea.Tag);
                    NEmpleado Insert = new NEmpleado();
                    Insert.InserRow(IEmpleado);
                    MessageBox.Show("Se guardo sastifactoriamente", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                actualizarGrid();
                Limpiar();
                Deshabilitar();
                btnCancelar.Enabled = false;
                btnguardar.Enabled = false;
                btnModificar.Enabled = false;
                btnNuevo.Enabled = true;
                btnGrupo.Enabled = false;
                txtGrupo.Enabled = false;
                btnArea.Enabled = true;
                btnArea.Enabled = false;
                modificar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
           

        }

        private void dgvEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvEmpleado.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                txtApellido.Text = dgvEmpleado.Rows[e.RowIndex].Cells["apellidos"].Value.ToString();
                txtArea.Tag = dgvEmpleado.Rows[e.RowIndex].Cells["idArea"].Value.ToString();
                txtArea.Text = dgvEmpleado.Rows[e.RowIndex].Cells["area"].Value.ToString();
                txtcedula.Text = dgvEmpleado.Rows[e.RowIndex].Cells["cedula"].Value.ToString();
                txtcelular.Text = dgvEmpleado.Rows[e.RowIndex].Cells["celular"].Value.ToString();
                txtdireccion.Text = dgvEmpleado.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                txtFechaNac.Text = dgvEmpleado.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString();
                txtGrupo.Tag = dgvEmpleado.Rows[e.RowIndex].Cells["idGrupo"].Value.ToString();
                txtGrupo.Text = dgvEmpleado.Rows[e.RowIndex].Cells["grupoTrabajadores"].Value.ToString();
                txtSalario.Text = dgvEmpleado.Rows[e.RowIndex].Cells["salario"].Value.ToString();
                txtNombre.Tag = dgvEmpleado.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString();
                cmbEstado.Text = dgvEmpleado.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                cmbcargo.Text = dgvEmpleado.Rows[e.RowIndex].Cells["cargo"].Value.ToString();
                btnCancelar.Enabled = true;
                btnguardar.Enabled = false;
                btnModificar.Enabled = true;
                btnNuevo.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Habilitar();
            btnCancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            txtArea.Enabled = false;
            txtGrupo.Enabled = false;
            btnGrupo.Enabled = true;
            txtArea.Enabled = false;
            btnArea.Enabled = true;
            modificar = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            Habilitar();
            btnCancelar.Enabled = true;
            btnguardar.Enabled = true;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = false;
            txtArea.Enabled = true;
            txtGrupo.Enabled = true;
            btnGrupo.Enabled = true;
            txtGrupo.Enabled = false;
            btnArea.Enabled = true;
            txtArea.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Deshabilitar();
            btnCancelar.Enabled = false;
            btnguardar.Enabled = false;
            btnModificar.Enabled = false;
            btnNuevo.Enabled = true;
            txtArea.Enabled = false;
            txtGrupo.Enabled = false;
            btnGrupo.Enabled = false;
            txtArea.Enabled = false;
            btnArea.Enabled = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGrupo_Click(object sender, EventArgs e)
        {
            frmBuscarGrupo buscar = new frmBuscarGrupo();
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                txtGrupo.Tag = buscar.idGrupo.ToString();
                txtGrupo.Text = buscar.grupo.ToString();
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            frmBuscarArea area = new frmBuscarArea();
            if (area.ShowDialog() == DialogResult.OK)
            {
                txtArea.Tag = area.idArea.ToString();
                txtArea.Text = area.area.ToString();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            filtrar();
        }
    }
    
}
