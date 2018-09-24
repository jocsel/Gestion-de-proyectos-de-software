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
    public partial class frmbuscarproveedor : Form
    {
        List<EProveedor> listaproveedor;
        public int? Id_Proveedor;
        public string Nombre_Proveedor;

        public frmbuscarproveedor()
        {
            InitializeComponent();
        }


        private void ActualizarLista()
        {
            NProveedor listaPro = new NProveedor();
            listaproveedor = listaPro.ObtenerListaProveedor();

            var lista = (from pro in listaproveedor
                         select new
                         {
                             pro.idProveedor,
                             Nombres = pro.nombres,
                             Apellidos = pro.apellidos,
                             RUC = pro.RUC,
                             Telefono = pro.telefono,
                             Correo = pro.correo,
                             Direccion = pro.direccion,
                             Empresa = pro.nombreempresa,
                             Estado = pro.estado
                         

                         }).ToList();
            dataGridView1.DataSource = lista;
            dataGridView1.Columns["idProveedor"].Visible = true;
         

        }

        private void frmbuscarproveedor_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al obtener los datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                Id_Proveedor = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["idProveedor"].Value.ToString());
                Nombre_Proveedor = dataGridView1.Rows[e.RowIndex].Cells["Nombres"].Value.ToString();
              
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
