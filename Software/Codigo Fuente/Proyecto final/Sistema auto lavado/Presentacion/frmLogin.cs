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
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wnsg, int wparam, int Lparam);


        private void btnlogin_Click(object sender, EventArgs e)
        {
            try {
                Negocio.NUsuario gestion = new Negocio.NUsuario();
                Entidades.EUsuario usuario = gestion.login(txtUsuario.Text,txtContraseña.Text);
                if (usuario.Empleado.nombres != null)
                {
                    Global.usuarioSesion = usuario;
                    DialogResult = DialogResult.OK;
                }
                else {
                    MessageBox.Show("Usuario o contraseña Incorrecta","Revise");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = "USUARIO";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO" )
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightBlue;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {

            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtContraseña_Enter_1(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "CONTRASEÑA")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.LightBlue;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave_1(object sender, EventArgs e)
        {

            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "CONTRASEÑA";
                txtContraseña.ForeColor = Color.DimGray;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
    }
}
