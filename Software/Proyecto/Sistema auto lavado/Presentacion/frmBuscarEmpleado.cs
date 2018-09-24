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
    public partial class frmBuscarEmpleado : Form
    {
        public string empleado;
        public int idEmpleado;
        List<EEmpleado> listaEmpleado;
        public frmBuscarEmpleado()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            empleado = "";
            this.Close();
        }

        private void frmBuscarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                NEmpleado buscar = new NEmpleado();
                listaEmpleado = buscar.listaEmpleado();
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
                dgvBuscarEmpleado.DataSource = lista;
                dgvBuscarEmpleado.Columns["idEmpleado"].Visible = false;
                dgvBuscarEmpleado.Columns["idGrupo"].Visible = false;
                dgvBuscarEmpleado.Columns["idArea"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvBuscarEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                empleado = dgvBuscarEmpleado.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                idEmpleado = Convert.ToInt32(dgvBuscarEmpleado.Rows[e.RowIndex].Cells["idEmpleado"].Value.ToString());
                DialogResult = DialogResult.OK;
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void filtrar()
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
            dgvBuscarEmpleado.DataSource = resultado;
            dgvBuscarEmpleado.Columns["idEmpleado"].Visible = false;
            dgvBuscarEmpleado.Columns["idGrupo"].Visible = false;
            dgvBuscarEmpleado.Columns["idArea"].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
