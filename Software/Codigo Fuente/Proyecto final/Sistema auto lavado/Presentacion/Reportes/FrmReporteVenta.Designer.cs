namespace Presentacion.Reportes
{
    partial class FrmReporteVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.getdetalleventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteVenta = new Presentacion.Reportes.DataSetReporteVenta();
            this.reporteventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getdetalleventaTableAdapter = new Presentacion.Reportes.DataSetReporteVentaTableAdapters.getdetalleventaTableAdapter();
            this.reporteventaTableAdapter = new Presentacion.Reportes.DataSetReporteVentaTableAdapters.reporteventaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.getdetalleventaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteventaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // getdetalleventaBindingSource
            // 
            this.getdetalleventaBindingSource.DataMember = "getdetalleventa";
            this.getdetalleventaBindingSource.DataSource = this.DataSetReporteVenta;
            // 
            // DataSetReporteVenta
            // 
            this.DataSetReporteVenta.DataSetName = "DataSetReporteVenta";
            this.DataSetReporteVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reporteventaBindingSource
            // 
            this.reporteventaBindingSource.DataMember = "reporteventa";
            this.reporteventaBindingSource.DataSource = this.DataSetReporteVenta;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getdetalleventaBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.reporteventaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.ReportVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(844, 543);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // getdetalleventaTableAdapter
            // 
            this.getdetalleventaTableAdapter.ClearBeforeFill = true;
            // 
            // reporteventaTableAdapter
            // 
            this.reporteventaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 543);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteVenta";
            this.Text = "FrmReporteVenta";
            this.Load += new System.EventHandler(this.FrmReporteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.getdetalleventaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteventaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getdetalleventaBindingSource;
        private DataSetReporteVenta DataSetReporteVenta;
        private System.Windows.Forms.BindingSource reporteventaBindingSource;
        private DataSetReporteVentaTableAdapters.getdetalleventaTableAdapter getdetalleventaTableAdapter;
        private DataSetReporteVentaTableAdapters.reporteventaTableAdapter reporteventaTableAdapter;
    }
}