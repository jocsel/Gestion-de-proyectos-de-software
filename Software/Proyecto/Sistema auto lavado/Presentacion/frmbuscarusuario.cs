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
    public partial class frmbuscarusuario : Form
    {
        public int IdUsuario;
        public string Nombre_Usuario;
        public List<EUsuario> listarUsua;

        public frmbuscarusuario()
        {
            InitializeComponent();
        }
        public void ActualizarLista()
        {
            NUsuario gestioUsuario = new NUsuario();
            listarUsua = gestioUsuario.SelectRow();
            var lista = (from usuario in listarUsua
                         select new
                         {

                             usuario.Empleado.nombres,
                             usuario.Empleado.cargo,
                             Nombre_Usuario = usuario.usuario,
                             usuario.password,                         
                             usuario.idUsuario
                        
                         }).ToList();
            dgvusuario.DataSource = lista;
            dgvusuario.Columns["idUsuario"].Visible = false;
          
         
        }

        private void frmbuscarusuario_Load(object sender, EventArgs e)
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

        private void dgvusuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                IdUsuario = Convert.ToInt32(dgvusuario.Rows[e.RowIndex].Cells["idUsuario"].Value.ToString());
                Nombre_Usuario = dgvusuario.Rows[e.RowIndex].Cells["Nombre_Usuario"].Value.ToString();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvusuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
