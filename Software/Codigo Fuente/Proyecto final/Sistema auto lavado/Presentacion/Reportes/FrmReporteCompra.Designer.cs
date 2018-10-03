namespace Presentacion.Reportes
{
    partial class FrmReporteCompra
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
            this.reportecompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetReporteCompra = new Presentacion.Reportes.DataSetReporteCompra();
            this.getdetallecompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportecompraTableAdapter = new Presentacion.Reportes.DataSetReporteCompraTableAdapters.reportecompraTableAdapter();
            this.getdetallecompraTableAdapter = new Presentacion.Reportes.DataSetReporteCompraTableAdapters.getdetallecompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportecompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getdetallecompraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportecompraBindingSource
            // 
            this.reportecompraBindingSource.DataMember = "reportecompra";
            this.reportecompraBindingSource.DataSource = this.DataSetReporteCompra;
            // 
            // DataSetReporteCompra
            // 
            this.DataSetReporteCompra.DataSetName = "DataSetReporteCompra";
            this.DataSetReporteCompra.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getdetallecompraBindingSource
            // 
            this.getdetallecompraBindingSource.DataMember = "getdetallecompra";
            this.getdetallecompraBindingSource.DataSource = this.DataSetReporteCompra;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.reportecompraBindingSource;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.getdetallecompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Presentacion.Reportes.ReportCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(839, 543);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // reportecompraTableAdapter
            // 
            this.reportecompraTableAdapter.ClearBeforeFill = true;
            // 
            // getdetallecompraTableAdapter
            // 
            this.getdetallecompraTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 543);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCompra";
            this.Text = "FrmReporteCompra";
            this.Load += new System.EventHandler(this.FrmReporteCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportecompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetReporteCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getdetallecompraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reportecompraBindingSource;
        private DataSetReporteCompra DataSetReporteCompra;
        private System.Windows.Forms.BindingSource getdetallecompraBindingSource;
        private DataSetReporteCompraTableAdapters.reportecompraTableAdapter reportecompraTableAdapter;
        private DataSetReporteCompraTableAdapters.getdetallecompraTableAdapter getdetallecompraTableAdapter;
    }
}