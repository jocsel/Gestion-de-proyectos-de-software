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
    public partial class frmbuscarcliente : Form
    {
        public int idcliente;
        public string nombre;
        List<ECliente> listacliente;
        public frmbuscarcliente()
        {
            InitializeComponent();
        }
        private void ActualizarLista()
        {

            NCliente gestion = new NCliente();
            listacliente = gestion.obtenerlistClientes();

            var lista = (from cliente in listacliente
                         where cliente.estado == "Activo"
                         select new
                         {
                             cliente.idCliente,
                             cliente.nombres,
                             cliente.apellido,
                             cliente.celular,
                             cliente.correo,
                             cliente.estado,

                         }).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["idCliente"].Visible = true;
            dataGridView1.Columns["estado"].Visible = true;


        }
        public void filtrar()
        {

            if (rbcodigo.Checked)
            {
                var lista = (from cliente in listacliente
                             where cliente.estado == "Activo" && cliente.idCliente.ToString().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 cliente.idCliente,
                                 cliente.nombres,
                                 cliente.apellido,
                                 cliente.celular,
                                 cliente.correo,
                                 cliente.estado,

                             }).ToList();
                dataGridView1.DataSource = lista;
                dataGridView1.Columns["idCliente"].Visible = true;
                dataGridView1.Columns["estado"].Visible = true;

            }


            if (rbNombre.Checked)
            {
                var lista = (from cliente in listacliente
                             where cliente.estado == "Activo" && cliente.nombres.ToUpper().StartsWith(textBox1.Text.ToUpper())
                             select new
                             {
                                 cliente.idCliente,
                                 cliente.nombres,
                                 cliente.apellido,
                                 cliente.celular,
                                 cliente.correo,
                                 cliente.estado,

                             }).ToList();
                dataGridView1.DataSource = lista;
                dataGridView1.Columns["idCliente"].Visible = true;
                dataGridView1.Columns["estado"].Visible = true;


            }



        }



        private void frmbuscarcliente_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();
                //NCliente gestion = new NCliente();
                //dataGridView1.DataSource = gestion.obtenerlistClientes();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                idcliente = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idCliente"].Value.ToString());
                nombre = dataGridView1.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
