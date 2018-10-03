namespace Presentacion
{
    partial class fmrAuditoriaLavado
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbplaca = new System.Windows.Forms.RadioButton();
            this.rbempleado = new System.Windows.Forms.RadioButton();
            this.lblnombre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvAuditoriaLavado = new System.Windows.Forms.DataGridView();
            this.rbtFecha = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaLavado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(856, 29);
            this.panel2.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(295, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "CONTROL DE LAVADO";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtFecha);
            this.groupBox3.Controls.Add(this.rbplaca);
            this.groupBox3.Controls.Add(this.rbempleado);
            this.groupBox3.Controls.Add(this.lblnombre);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(832, 42);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar";
            // 
            // rbplaca
            // 
            this.rbplaca.AutoSize = true;
            this.rbplaca.Location = new System.Drawing.Point(671, 16);
            this.rbplaca.Name = "rbplaca";
            this.rbplaca.Size = new System.Drawing.Size(61, 18);
            this.rbplaca.TabIndex = 3;
            this.rbplaca.TabStop = true;
            this.rbplaca.Text = "Placa";
            this.rbplaca.UseVisualStyleBackColor = true;
            // 
            // rbempleado
            // 
            this.rbempleado.AutoSize = true;
            this.rbempleado.Location = new System.Drawing.Point(571, 16);
            this.rbempleado.Name = "rbempleado";
            this.rbempleado.Size = new System.Drawing.Size(89, 18);
            this.rbempleado.TabIndex = 2;
            this.rbempleado.TabStop = true;
            this.rbempleado.Text = "Empleado";
            this.rbempleado.UseVisualStyleBackColor = true;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(50, 18);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(74, 14);
            this.lblnombre.TabIndex = 0;
            this.lblnombre.Text = "Empleado:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(125, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(421, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvAuditoriaLavado
            // 
            this.dgvAuditoriaLavado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditoriaLavado.Location = new System.Drawing.Point(12, 97);
            this.dgvAuditoriaLavado.Name = "dgvAuditoriaLavado";
            this.dgvAuditoriaLavado.ReadOnly = true;
            this.dgvAuditoriaLavado.Size = new System.Drawing.Size(832, 263);
            this.dgvAuditoriaLavado.TabIndex = 22;
            this.dgvAuditoriaLavado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditoriaMan_CellContentClick);
            // 
            // rbtFecha
            // 
            this.rbtFecha.AutoSize = true;
            this.rbtFecha.Location = new System.Drawing.Point(738, 14);
            this.rbtFecha.Name = "rbtFecha";
            this.rbtFecha.Size = new System.Drawing.Size(64, 18);
            this.rbtFecha.TabIndex = 4;
            this.rbtFecha.TabStop = true;
            this.rbtFecha.Text = "Fecha";
            this.rbtFecha.UseVisualStyleBackColor = true;
            // 
            // fmrAuditoriaLavado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 369);
            this.Controls.Add(this.dgvAuditoriaLavado);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmrAuditoriaLavado";
            this.Text = "fmrAuditoriaLavado";
            this.Load += new System.EventHandler(this.fmrAuditoriaLavado_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditoriaLavado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbplaca;
        private System.Windows.Forms.RadioButton rbempleado;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvAuditoriaLavado;
        private System.Windows.Forms.RadioButton rbtFecha;
    }
}