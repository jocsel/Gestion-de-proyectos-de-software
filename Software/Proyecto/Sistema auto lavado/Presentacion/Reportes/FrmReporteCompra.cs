﻿using System;
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
    public partial class FrmReporteCompra : Form
    {
        public FrmReporteCompra()
        {
            InitializeComponent();
        }
        public int X { get; set; }
        public int Y { get; set; }

        private void FrmReporteCompra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetReporteCompra.reportecompra' Puede moverla o quitarla según sea necesario.
            this.reportecompraTableAdapter.Fill(this.DataSetReporteCompra.reportecompra,X);
            // TODO: esta línea de código carga datos en la tabla 'DataSetReporteCompra.getdetallecompra' Puede moverla o quitarla según sea necesario.
            this.getdetallecompraTableAdapter.Fill(this.DataSetReporteCompra.getdetallecompra,Y);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
