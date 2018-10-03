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
    public partial class frmControlEntrada : Form
    {
        List<EControl_Entrada> lista;
        public frmControlEntrada()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmControlEntrada_Load(object sender, EventArgs e)
        {
            actualizargrid();
            rbempleado.Checked = true;

        }

        public void actualizargrid()
        {

            try
            {
                NControl_Entrada gestionar = new NControl_Entrada();
                lista = gestionar.ObtenerControl();

                var listaa = (from ce in lista
                             select new
                             {
                                 ce.Empleado,
                                 ce.usuario.usuario,
                                 ce.loginn,
                                 ce.logout,
                                 ce.maquina,

                             }).ToList();
                dgvControlEntrada.DataSource = listaa;
               
                          


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
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
               from ce in lista
               where ce.Empleado.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   ce.Empleado,
                   ce.usuario.usuario,
                   ce.loginn,
                   ce.logout,
                   ce.maquina,

               }).ToList();
                dgvControlEntrada.DataSource = resultado;

            }

            if (rbusuario.Checked)
            {
                
                var resultado = (
               from ce in lista
               where ce.Empleado.ToUpper().StartsWith(textBox1.Text.ToUpper())
               select new
               {
                   ce.Empleado,
                   ce.usuario.usuario,
                   ce.loginn,
                   ce.logout,
                   ce.maquina,

               }).ToList();
                dgvControlEntrada.DataSource = resultado;

            }
        }

     

        private void rbempleado_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Empleado";

        }

        private void rbusuario_CheckedChanged(object sender, EventArgs e)
        {
            lblnombre.Text = "Usuario";
        }
    }
}
