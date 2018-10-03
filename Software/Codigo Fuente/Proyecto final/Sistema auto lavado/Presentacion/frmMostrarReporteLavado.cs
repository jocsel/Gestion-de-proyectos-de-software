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
    public partial class frmMostrarReporteLavado : Form
    {
        public DateTime fecha { get; set; }
        public string nombre{ get; set; }
        public string vehiculo { get; set; }
        public string servicio { get; set; }
        public frmMostrarReporteLavado()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMostrarReporteLavado_Load(object sender, EventArgs e)
        {
            try
            {
                frmReporteLavado fechas = new frmReporteLavado();
                
                // TODO: esta línea de código carga datos en la tabla 'dtsLavado.sp_ReporteLavado' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteLavadoFechaTableAdapter.Fill(this.dtsLavado.sp_ReporteLavadoFecha,fecha);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
