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
    public partial class frmMostrarReporteLavadoEmpleado : Form
    {
        public string Empleado { get; set; }
        public frmMostrarReporteLavadoEmpleado()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarReporteLavadoEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_ReporteLavadoNombre' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteLavadoNombreTableAdapter.Fill(this.dtsLavado.sp_ReporteLavadoNombre,Empleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
