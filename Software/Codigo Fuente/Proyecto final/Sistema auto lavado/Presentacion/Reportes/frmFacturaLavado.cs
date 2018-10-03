using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmFacturaLavado : Form
    {
        public int idLavado { get; set; }
        public frmFacturaLavado()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFacturaLavado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_facturaLavado' Puede moverla o quitarla según sea necesario.
            try
            {
                this.sp_facturaLavadoTableAdapter.Fill(this.dtsLavado.sp_facturaLavado, idLavado);
                this.reportViewer1.RefreshReport();
            }

            catch (Exception ex) {
                this.reportViewer1.RefreshReport();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
