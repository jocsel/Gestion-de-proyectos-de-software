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
    public partial class frmMostrarReporteLavadoServicio : Form
    {
        public string servicio { get; set; }
        public frmMostrarReporteLavadoServicio()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarReporteLavadoServicio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_ReporteLavadoServicio' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteLavadoServicioTableAdapter.Fill(this.dtsLavado.sp_ReporteLavadoServicio, servicio);

            this.reportViewer1.RefreshReport();
        }
    }
}
