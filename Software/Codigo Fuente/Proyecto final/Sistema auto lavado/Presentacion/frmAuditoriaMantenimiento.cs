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
    public partial class frmAuditoriaMantenimiento : Form
    {
        public List<EAuditoriaMantenimiento> lista;
        public frmAuditoriaMantenimiento()
        {
            InitializeComponent();
        }

        private void frmAuditoriaMantenimiento_Load(object sender, EventArgs e)
        {
            actualizargrid();
            rbempleado.Checked = true;
        }
        public void actualizargrid()
        {

            try
            {
                NAuditoriaMantenimiento gestionar = new NAuditoriaMantenimiento();
                lista = gestionar.ObtenerMantenimiento();

                var listaa = (from am in lista
                              select new
                              {
                                  am.idmantenimiento,
                                  am.realizado,
                                  am.placa,
                                  am.vehiculo,
                                  am.servicio,
                                  am.tecnicos,
                                  am.fecha,
                                  am.total,
                                  am.creado,
                                  am.Modificado,
                                  am.Accion,
                                  
                              }).ToList();
                dgvAuditoriaMan.DataSource = listaa;
                dgvAuditoriaMan.Columns["idmantenimiento"].Visible = false;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbusuario_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Placa";
        }

        private void rbempleado_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Empleado";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        public void filtrar()
        {

            if (rbempleado.Checked)
            {

               var resultado = (
               from am in lista
               where am.realizado.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   am.idmantenimiento,
                   am.realizado,
                   am.placa,
                   am.vehiculo,
                   am.servicio,
                   am.tecnicos,
                   am.fecha,
                   am.total,
                   am.creado,
                   am.Modificado,
                   am.Accion,

               }).ToList();
                dgvAuditoriaMan.DataSource = resultado;
                dgvAuditoriaMan.Columns["idmantenimiento"].Visible = false;

            }

            if (rbplaca.Checked)
            {

               var resultado = (
               from am in lista
               where am.placa.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   am.idmantenimiento,
                   am.realizado,
                   am.placa,
                   am.vehiculo,
                   am.servicio,
                   am.tecnicos,
                   am.fecha,
                   am.total,
                   am.creado,
                   am.Modificado,
                   am.Accion,

               }).ToList();
                dgvAuditoriaMan.DataSource = resultado;
                dgvAuditoriaMan.Columns["idmantenimiento"].Visible = false;

            }


        }
        
    }
}
