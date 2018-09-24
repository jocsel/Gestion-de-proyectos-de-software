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
    public partial class frmMostrarReporteMantenimiento : Form
    {
        public int idMatenimiento { get; set; }
        public frmMostrarReporteMantenimiento()
        {
            InitializeComponent();
        }
        

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarReporteMantenimiento_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_facturarMantenimiento' Puede moverla o quitarla según sea necesario.
            this.sp_facturarMantenimientoTableAdapter.Fill(this.dtsLavado.sp_facturarMantenimiento, idMatenimiento);

            this.reportViewer1.RefreshReport();
        }
    }
}
