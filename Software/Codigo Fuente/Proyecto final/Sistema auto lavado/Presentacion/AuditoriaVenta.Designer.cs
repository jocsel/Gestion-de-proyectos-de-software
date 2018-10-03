namespace Presentacion
{
    partial class AuditoriaVenta
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
            this.dgvAuditoriaventa = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbventas = new System.Windows.Forms.RadioButton();
            this.rbestado = new System.Windows.Forms.RadioButton();
            this.lblnombre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.rbempleado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaventa)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAuditoriaventa
            // 
            this.dgvAuditoriaventa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaventa.Location = new System.Drawing.Point(12, 96);
            this.dgvAuditoriaventa.Name = "dgvAuditoriaventa";
            this.dgvAuditoriaventa.ReadOnly = true;
            this.dgvAuditoriaventa.Size = new System.Drawing.Size(832, 263);
            this.dgvAuditoriaventa.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbempleado);
            this.groupBox3.Controls.Add(this.rbventas);
            this.groupBox3.Controls.Add(this.rbestado);
            this.groupBox3.Controls.Add(this.lblnombre);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 42);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // rbventas
            // 
            this.rbventas.AutoSize = true;
            this.rbventas.Location = new System.Drawing.Point(632, 16);
            this.rbventas.Name = "rbventas";
            this.rbventas.Size = new System.Drawing.Size(99, 18);
            this.rbventas.TabIndex = 3;
            this.rbventas.TabStop = true;
            this.rbventas.Text = "Numventas";
            this.rbventas.UseVisualStyleBackColor = true;
            this.rbventas.CheckedChanged += new System.EventHandler(this.rbventas_CheckedChanged);
            // 
            // rbestado
            // 
            this.rbestado.AutoSize = true;
            this.rbestado.Location = new System.Drawing.Point(557, 16);
            this.rbestado.Name = "rbestado";
            this.rbestado.Size = new System.Drawing.Size(69, 18);
            this.rbestado.TabIndex = 2;
            this.rbestado.TabStop = true;
            this.rbestado.Text = "Estado";
            this.rbestado.UseVisualStyleBackColor = true;
            this.rbestado.CheckedChanged += new System.EventHandler(this.rbestado_CheckedChanged);
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(50, 20);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(80, 14);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Numventa :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(136, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(407, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 29);
            this.panel2.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(295, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "CONTROL DE VENTAS";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::Presentacion.Properties.Resources.X;
            this.pictureBox8.Location = new System.Drawing.Point(830, 0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(26, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 2;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // rbempleado
            // 
            this.rbempleado.AutoSize = true;
            this.rbempleado.Location = new System.Drawing.Point(737, 16);
            this.rbempleado.Name = "rbempleado";
            this.rbempleado.Size = new System.Drawing.Size(89, 18);
            this.rbempleado.TabIndex = 26;
            this.rbempleado.TabStop = true;
            this.rbempleado.Text = "Empleado";
            this.rbempleado.UseVisualStyleBackColor = true;
            this.rbempleado.CheckedChanged += new System.EventHandler(this.rbempleado_CheckedChanged);
            // 
            // AuditoriaVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 382);
            this.Controls.Add(this.dgvAuditoriaventa);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuditoriaVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuditoriaVenta";
            this.Load += new System.EventHandler(this.AuditoriaVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaventa)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAuditoriaventa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.RadioButton rbestado;
        private System.Windows.Forms.RadioButton rbventas;
        private System.Windows.Forms.RadioButton rbempleado;
    }
}