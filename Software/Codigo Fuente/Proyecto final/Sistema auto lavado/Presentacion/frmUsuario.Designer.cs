namespace Presentacion
{
    partial class frmUsuario
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.lblestado = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkbtnFacComp = new System.Windows.Forms.CheckBox();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.chkBtnPersonas = new System.Windows.Forms.CheckBox();
            this.chkBtnLavado = new System.Windows.Forms.CheckBox();
            this.chkBtnMantenimiento = new System.Windows.Forms.CheckBox();
            this.chkBtnProducto = new System.Windows.Forms.CheckBox();
            this.chkBtnUsuarios = new System.Windows.Forms.CheckBox();
            this.chkBtnFacturar = new System.Windows.Forms.CheckBox();
            this.chkLavado = new System.Windows.Forms.CheckBox();
            this.chkMantenimiento = new System.Windows.Forms.CheckBox();
            this.chkReporte = new System.Windows.Forms.CheckBox();
            this.chkProductos = new System.Windows.Forms.CheckBox();
            this.chkPersonas = new System.Windows.Forms.CheckBox();
            this.chkFacturar = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 29);
            this.panel2.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.X;
            this.pictureBox1.Location = new System.Drawing.Point(810, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(355, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "USUARIO";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = global::Presentacion.Properties.Resources.X;
            this.pictureBox8.Location = new System.Drawing.Point(1146, -1);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(26, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 2;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEmpleado);
            this.groupBox2.Controls.Add(this.btnEmpleado);
            this.groupBox2.Controls.Add(this.lblestado);
            this.groupBox2.Controls.Add(this.txtNombreUsuario);
            this.groupBox2.Controls.Add(this.cmbEstado);
            this.groupBox2.Controls.Add(this.lblNombreUsuario);
            this.groupBox2.Controls.Add(this.txtContraseña);
            this.groupBox2.Controls.Add(this.lblContraseña);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(30, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(808, 156);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del Usuario";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 15;
            this.label1.Text = "Empleado";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(105, 40);
            this.txtEmpleado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.Size = new System.Drawing.Size(218, 22);
            this.txtEmpleado.TabIndex = 4;
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackgroundImage = global::Presentacion.Properties.Resources.icons8_búsqueda_481;
            this.btnEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmpleado.Location = new System.Drawing.Point(331, 40);
            this.btnEmpleado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(40, 24);
            this.btnEmpleado.TabIndex = 12;
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(469, 93);
            this.lblestado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(51, 14);
            this.lblestado.TabIndex = 14;
            this.lblestado.Text = "Estado";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(532, 42);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(248, 22);
            this.txtNombreUsuario.TabIndex = 5;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(532, 85);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(248, 22);
            this.cmbEstado.TabIndex = 13;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(469, 50);
            this.lblNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(55, 14);
            this.lblNombreUsuario.TabIndex = 2;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(105, 85);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(218, 22);
            this.txtContraseña.TabIndex = 6;
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(12, 88);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(81, 14);
            this.lblContraseña.TabIndex = 3;
            this.lblContraseña.Text = "Contraseña";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkbtnFacComp);
            this.groupBox3.Controls.Add(this.chkLog);
            this.groupBox3.Controls.Add(this.chkBtnPersonas);
            this.groupBox3.Controls.Add(this.chkBtnLavado);
            this.groupBox3.Controls.Add(this.chkBtnMantenimiento);
            this.groupBox3.Controls.Add(this.chkBtnProducto);
            this.groupBox3.Controls.Add(this.chkBtnUsuarios);
            this.groupBox3.Controls.Add(this.chkBtnFacturar);
            this.groupBox3.Controls.Add(this.chkLavado);
            this.groupBox3.Controls.Add(this.chkMantenimiento);
            this.groupBox3.Controls.Add(this.chkReporte);
            this.groupBox3.Controls.Add(this.chkProductos);
            this.groupBox3.Controls.Add(this.chkPersonas);
            this.groupBox3.Controls.Add(this.chkFacturar);
            this.groupBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(30, 197);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(808, 202);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // chkbtnFacComp
            // 
            this.chkbtnFacComp.AutoSize = true;
            this.chkbtnFacComp.Location = new System.Drawing.Point(567, 78);
            this.chkbtnFacComp.Name = "chkbtnFacComp";
            this.chkbtnFacComp.Size = new System.Drawing.Size(176, 18);
            this.chkbtnFacComp.TabIndex = 13;
            this.chkbtnFacComp.Text = "Menu Facturar Compra";
            this.chkbtnFacComp.UseVisualStyleBackColor = true;
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Location = new System.Drawing.Point(567, 36);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(57, 18);
            this.chkLog.TabIndex = 12;
            this.chkLog.Text = "Logs";
            this.chkLog.UseVisualStyleBackColor = true;
            // 
            // chkBtnPersonas
            // 
            this.chkBtnPersonas.AutoSize = true;
            this.chkBtnPersonas.Location = new System.Drawing.Point(190, 159);
            this.chkBtnPersonas.Name = "chkBtnPersonas";
            this.chkBtnPersonas.Size = new System.Drawing.Size(125, 18);
            this.chkBtnPersonas.TabIndex = 11;
            this.chkBtnPersonas.Text = "Menu personas";
            this.chkBtnPersonas.UseVisualStyleBackColor = true;
            // 
            // chkBtnLavado
            // 
            this.chkBtnLavado.AutoSize = true;
            this.chkBtnLavado.Location = new System.Drawing.Point(381, 78);
            this.chkBtnLavado.Name = "chkBtnLavado";
            this.chkBtnLavado.Size = new System.Drawing.Size(113, 18);
            this.chkBtnLavado.TabIndex = 10;
            this.chkBtnLavado.Text = "Menu Lavado";
            this.chkBtnLavado.UseVisualStyleBackColor = true;
            // 
            // chkBtnMantenimiento
            // 
            this.chkBtnMantenimiento.AutoSize = true;
            this.chkBtnMantenimiento.Location = new System.Drawing.Point(190, 78);
            this.chkBtnMantenimiento.Name = "chkBtnMantenimiento";
            this.chkBtnMantenimiento.Size = new System.Drawing.Size(162, 18);
            this.chkBtnMantenimiento.TabIndex = 9;
            this.chkBtnMantenimiento.Text = "Menu Mantenimiento";
            this.chkBtnMantenimiento.UseVisualStyleBackColor = true;
            // 
            // chkBtnProducto
            // 
            this.chkBtnProducto.AutoSize = true;
            this.chkBtnProducto.Location = new System.Drawing.Point(15, 159);
            this.chkBtnProducto.Name = "chkBtnProducto";
            this.chkBtnProducto.Size = new System.Drawing.Size(123, 18);
            this.chkBtnProducto.TabIndex = 8;
            this.chkBtnProducto.Text = "Menu producto";
            this.chkBtnProducto.UseVisualStyleBackColor = true;
            // 
            // chkBtnUsuarios
            // 
            this.chkBtnUsuarios.AutoSize = true;
            this.chkBtnUsuarios.Location = new System.Drawing.Point(13, 78);
            this.chkBtnUsuarios.Name = "chkBtnUsuarios";
            this.chkBtnUsuarios.Size = new System.Drawing.Size(121, 18);
            this.chkBtnUsuarios.TabIndex = 7;
            this.chkBtnUsuarios.Text = "Menu usuarios";
            this.chkBtnUsuarios.UseVisualStyleBackColor = true;
            // 
            // chkBtnFacturar
            // 
            this.chkBtnFacturar.AutoSize = true;
            this.chkBtnFacturar.Location = new System.Drawing.Point(567, 117);
            this.chkBtnFacturar.Name = "chkBtnFacturar";
            this.chkBtnFacturar.Size = new System.Drawing.Size(121, 18);
            this.chkBtnFacturar.TabIndex = 6;
            this.chkBtnFacturar.Text = "Menu Facturar";
            this.chkBtnFacturar.UseVisualStyleBackColor = true;
            // 
            // chkLavado
            // 
            this.chkLavado.AutoSize = true;
            this.chkLavado.Location = new System.Drawing.Point(381, 117);
            this.chkLavado.Name = "chkLavado";
            this.chkLavado.Size = new System.Drawing.Size(74, 18);
            this.chkLavado.TabIndex = 5;
            this.chkLavado.Text = "Lavado";
            this.chkLavado.UseVisualStyleBackColor = true;
            // 
            // chkMantenimiento
            // 
            this.chkMantenimiento.AutoSize = true;
            this.chkMantenimiento.Location = new System.Drawing.Point(190, 117);
            this.chkMantenimiento.Name = "chkMantenimiento";
            this.chkMantenimiento.Size = new System.Drawing.Size(123, 18);
            this.chkMantenimiento.TabIndex = 4;
            this.chkMantenimiento.Text = "Mantenimiento";
            this.chkMantenimiento.UseVisualStyleBackColor = true;
            // 
            // chkReporte
            // 
            this.chkReporte.AutoSize = true;
            this.chkReporte.Location = new System.Drawing.Point(381, 36);
            this.chkReporte.Name = "chkReporte";
            this.chkReporte.Size = new System.Drawing.Size(78, 18);
            this.chkReporte.TabIndex = 3;
            this.chkReporte.Text = "Reporte";
            this.chkReporte.UseVisualStyleBackColor = true;
            // 
            // chkProductos
            // 
            this.chkProductos.AutoSize = true;
            this.chkProductos.Location = new System.Drawing.Point(190, 36);
            this.chkProductos.Name = "chkProductos";
            this.chkProductos.Size = new System.Drawing.Size(92, 18);
            this.chkProductos.TabIndex = 2;
            this.chkProductos.Text = "Productos";
            this.chkProductos.UseVisualStyleBackColor = true;
            // 
            // chkPersonas
            // 
            this.chkPersonas.AutoSize = true;
            this.chkPersonas.Location = new System.Drawing.Point(15, 117);
            this.chkPersonas.Name = "chkPersonas";
            this.chkPersonas.Size = new System.Drawing.Size(87, 18);
            this.chkPersonas.TabIndex = 1;
            this.chkPersonas.Text = "Personas";
            this.chkPersonas.UseVisualStyleBackColor = true;
            // 
            // chkFacturar
            // 
            this.chkFacturar.AutoSize = true;
            this.chkFacturar.Location = new System.Drawing.Point(13, 36);
            this.chkFacturar.Name = "chkFacturar";
            this.chkFacturar.Size = new System.Drawing.Size(82, 18);
            this.chkFacturar.TabIndex = 0;
            this.chkFacturar.Text = "Facturar";
            this.chkFacturar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 418);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(811, 71);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funciones";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Presentacion.Properties.Resources.icons8_por_nueva_copia_40;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(166, 21);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(116, 28);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Image = global::Presentacion.Properties.Resources.icons8_editar_propiedad_482;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(290, 21);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(116, 28);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Presentacion.Properties.Resources.icons8_más_32__1_;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(414, 21);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(116, 28);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Presentacion.Properties.Resources.icons8_cancel_48;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(538, 21);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(116, 28);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(27, 495);
            this.dgvUsuarios.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(811, 165);
            this.dgvUsuarios.TabIndex = 26;
            this.dgvUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellDoubleClick);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 672);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuario";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkBtnPersonas;
        private System.Windows.Forms.CheckBox chkBtnLavado;
        private System.Windows.Forms.CheckBox chkBtnMantenimiento;
        private System.Windows.Forms.CheckBox chkBtnProducto;
        private System.Windows.Forms.CheckBox chkBtnUsuarios;
        private System.Windows.Forms.CheckBox chkBtnFacturar;
        private System.Windows.Forms.CheckBox chkLavado;
        private System.Windows.Forms.CheckBox chkMantenimiento;
        private System.Windows.Forms.CheckBox chkReporte;
        private System.Windows.Forms.CheckBox chkProductos;
        private System.Windows.Forms.CheckBox chkPersonas;
        private System.Windows.Forms.CheckBox chkFacturar;
        private System.Windows.Forms.CheckBox chkbtnFacComp;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}