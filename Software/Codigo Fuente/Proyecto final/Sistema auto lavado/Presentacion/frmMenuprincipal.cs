using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class frmMenuprincipal : Form
    {
        public int FORMCOMPRA;
        
        public frmMenuprincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
    
        private void btnslide_Click(object sender, EventArgs e)
        {



            if (Menuvertical.Width == 72)
            {
                this.pictureBox1.Size = new System.Drawing.Size(150, 150);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Menuvertical.Width = 250;

            }
            else
            {
                this.pictureBox1.Size = new System.Drawing.Size(56, 61);
                this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Menuvertical.Width = 72;
            }
            

        }

        private void iconocerrar_Click(object sender, EventArgs e)
        {
            EControl_Entrada newcontrol = new EControl_Entrada();
            newcontrol.usuario.usuario = (lblUsuarios.Text);


            NControl_Entrada gestionarcontrol = new NControl_Entrada();
            gestionarcontrol.Insertar(newcontrol);
            Application.Restart();
        }

        private void iconomaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            iconomaximizar.Visible = false;
            iconorestaurar.Visible = true;

        }

        private void iconorestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconomaximizar.Visible = true;
            iconorestaurar.Visible = false;
        }

        private void iconominimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Barratitulo_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Menuvertical_Paint(object sender, PaintEventArgs e)
        {

        }

        public void AbrirFormInPanel(object FormHijo)

        {
            if (this.panelContenedor.Controls.Count > 0)
            this.panelContenedor.Controls.RemoveAt(0);
            Form fh = FormHijo as Form;
            fh.TopLevel = false;
          
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
     

        private void btnfacturar_Click(object sender, EventArgs e)
        {

            AbrirFormInPanel(new frmVenta());

        }

        private void btnpersonas_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmEmpleado());
        }

        private void btnproducto_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmProductos());
        }

        private void btnmantenimiento_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMantenimineto());
        }

        private void btnusuario_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmUsuario());
        }

        private void btncerrarsecion_Click(object sender, EventArgs e)
        {
            EControl_Entrada newcontrol = new EControl_Entrada();
            newcontrol.usuario.usuario = (lblUsuarios.Text);
            NControl_Entrada gestionarcontrol = new NControl_Entrada();
            gestionarcontrol.Insertar(newcontrol);
            Application.Restart();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void cOMPRAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmMenuprincipal_Load(object sender, EventArgs e)
        {
            lblUsuarios.Text = Global.usuarioSesion.usuario;
            fACTURARToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.facturar;
            eMPLEADOToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.personas;
            pRODUCTOToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.producto;
            reporteToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.reporte;
            mANTENIMINETOToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.mantenimiento;
            lAVADOToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.lavado;
            btnfacturar.Enabled = Global.usuarioSesion.Permiso.btnFacturar;
        //    btnpersonas.Enabled = Global.usuarioSesion.Permiso.btnPersonas;
          //  btnproducto.Enabled = Global.usuarioSesion.Permiso.btnProducto;
            btnmantenimiento.Enabled = Global.usuarioSesion.Permiso.btnMantenimiento;
            btnlavado.Enabled = Global.usuarioSesion.Permiso.btnLavado;
            //    btnusuario.Enabled = Global.usuarioSesion.Permiso.btnUsuarios;
            lOGSToolStripMenuItem.Enabled = Global.usuarioSesion.Permiso.logs;
            button1.Enabled = Global.usuarioSesion.Permiso.btnFacturarCompra;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void reporteFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormInPanel(new frmre());
        }

        private void btnlavado_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmLavado());
        }

        private void cOMPRAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmCompra());
        }

        private void vENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVenta());
        }

        private void eMPLEADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmEmpleado());
        }

        private void pROVEEDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmProveedor());
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmclientes());
        }

        private void aREAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmArea());
        }

        private void gRUPOTRABAJADORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmGrupoTrabajadores());
        }

        private void pRODUCTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void aLMACENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAlmacen());
        }

        private void cATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmCategoria());
        }

        private void mARCAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMarca());
        }

        private void vEHICULOMANTENIMINETOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVehiculoMan());
        }

        private void sERVICIOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmServicioMantenimiento());
        }

        private void mANTENIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmServicioVehiculo());
        }

        private void seToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmMantenimineto());
        }

        private void lAVADOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmLavado());
        }

        private void lAVADOVEHICULOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmLavadoVehiculo());
        }

        private void vEHICULOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmVehiculoLavado());
        }

        private void tIPOSDESERVICIOSLAVADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmServicioLavado());
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EControl_Entrada newcontrol = new EControl_Entrada();
            newcontrol.usuario.usuario = (lblUsuarios.Text);
            
         
            NControl_Entrada gestionarcontrol = new NControl_Entrada();
            gestionarcontrol.Insertar(newcontrol);
            Application.Restart();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            AbrirFormInPanel(new frmCompra());
        }

        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmUsuario());
        }

        private void dEVOLUCIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void controlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmControlEntrada());
        }

        private void mANTENIMIENTOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmAuditoriaMantenimiento());
            
        }

        private void lAVADOToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel( new fmrAuditoriaLavado());
        }

        private void vENTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new AuditoriaVenta());
        }

        private void aCTIVOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBuscarproducto());
        }

        private void aDMINISTRARPRODUCTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmProductos());
        }

        private void iNACTIVOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmBuscarproductoINACTIVO());
        }

        private void nknToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void cANCELADASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmbuscarfactura());
        }

        private void aNULADASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmbuscarfacturaINACTIVA());
        }

        private void cOMPRAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmAuditoriaCompra());
        }

        private void cOMPRAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmDevolucioncompra());
        }

        private void vENTAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmDevolucion());
          
        }

        private void aYUDAToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lAVADOToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new frmReporteLavado());
        }

        private void mANUALDEUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Program Files (x86)\\JAGUAR\\My Product Name\\DB\\manual.pdf";
            proc.Start();
            proc.Close();
        }

        private void lblUsuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
