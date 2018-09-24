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
    public partial class frmMostrarReporteLavadoVehiculo : Form
    {
        public string vehiculo{ get; set; }
        public frmMostrarReporteLavadoVehiculo()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarReporteLavadoVehiculo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_ReporteLavadoVehiculo' Puede moverla o quitarla según sea necesario.
            this.sp_ReporteLavadoVehiculoTableAdapter.Fill(this.dtsLavado.sp_ReporteLavadoVehiculo,vehiculo);

            this.reportViewer1.RefreshReport();
        }
    }
}
