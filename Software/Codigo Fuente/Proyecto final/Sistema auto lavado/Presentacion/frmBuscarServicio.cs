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
    public partial class frmBuscarServicio : Form
    {
        public int idServicio;
        public string servicio;
        List<EServicioLavado> listarServicios;
        public frmBuscarServicio()
        {
            InitializeComponent();
        }

        private void frmBuscarServicio_Load(object sender, EventArgs e)
        {
            NServicioLavado listar = new NServicioLavado();
            listarServicios = listar.SelectRow();
            dgvBuscarServicio.DataSource = listarServicios;
        }

        private void dgvBuscarServicio_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idServicio = Convert.ToInt32(dgvBuscarServicio.Rows[e.RowIndex].Cells["idServicioLavado"].Value.ToString());
            servicio = dgvBuscarServicio.Rows[e.RowIndex].Cells["servicioLavado"].Value.ToString();
            DialogResult = DialogResult.OK;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void filtrar()
        {
            var resultado = (
                from servicio in listarServicios
                where servicio.servicioLavado.ToUpper().StartsWith(textBox1.Text.ToUpper())
                select new
                {
                    servicio.idServicioLavado,
                    servicio.servicioLavado,
                    servicio.estado,
                }
                ).ToList();
            dgvBuscarServicio.DataSource = resultado;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }
    }
}
