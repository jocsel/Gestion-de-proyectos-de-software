using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class FrmReporteVenta : Form
    {
        public FrmReporteVenta()
        {
            InitializeComponent();
        }
        public int X { get; set; }
        public int Y { get; set; }
        private void FrmReporteVenta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReporteVenta.getdetalleventa' Puede moverla o quitarla según sea necesario.
            this.getdetalleventaTableAdapter.Fill(this.DataSetReporteVenta.getdetalleventa,X);
            // TODO: esta línea de código carga datos en la tabla 'DataSetReporteVenta.reporteventa' Puede moverla o quitarla según sea necesario.
            this.reporteventaTableAdapter.Fill(this.DataSetReporteVenta.reporteventa,Y);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
