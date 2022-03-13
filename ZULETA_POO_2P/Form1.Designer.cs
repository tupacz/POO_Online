namespace ZULETA_POO_2P
{
    partial class Form1
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
            this.datagridClientes = new System.Windows.Forms.DataGridView();
            this.Clientes = new System.Windows.Forms.GroupBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnBajaCliente = new System.Windows.Forms.Button();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgClPrestamosVencidos = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgClPrestamosPagados = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.dgClPrestamosNoPagados = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAltaPrestamoDolares = new System.Windows.Forms.Button();
            this.btnModifPrestamo = new System.Windows.Forms.Button();
            this.btnBajaPrestamo = new System.Windows.Forms.Button();
            this.btnAltaPrestamoPesos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.datagridPagados = new System.Windows.Forms.DataGridView();
            this.datagridNoPagados = new System.Windows.Forms.DataGridView();
            this.lblTodos = new System.Windows.Forms.Label();
            this.datagridPrestamos = new System.Windows.Forms.DataGridView();
            this.textBoxFechaSistema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRecalcularFecha = new System.Windows.Forms.Button();
            this.lblFechaSistema = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridClientes)).BeginInit();
            this.Clientes.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosVencidos)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosPagados)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosNoPagados)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPagados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridNoPagados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrestamos)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridClientes
            // 
            this.datagridClientes.AllowUserToAddRows = false;
            this.datagridClientes.AllowUserToDeleteRows = false;
            this.datagridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridClientes.Location = new System.Drawing.Point(6, 42);
            this.datagridClientes.Name = "datagridClientes";
            this.datagridClientes.ReadOnly = true;
            this.datagridClientes.RowHeadersWidth = 51;
            this.datagridClientes.RowTemplate.Height = 24;
            this.datagridClientes.Size = new System.Drawing.Size(347, 156);
            this.datagridClientes.TabIndex = 0;
            this.datagridClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridClientes_CellClick);
            // 
            // Clientes
            // 
            this.Clientes.Controls.Add(this.btnAsignar);
            this.Clientes.Controls.Add(this.btnModificarCliente);
            this.Clientes.Controls.Add(this.btnBajaCliente);
            this.Clientes.Controls.Add(this.btnAltaCliente);
            this.Clientes.Controls.Add(this.groupBox5);
            this.Clientes.Controls.Add(this.groupBox4);
            this.Clientes.Controls.Add(this.groupBox3);
            this.Clientes.Controls.Add(this.datagridClientes);
            this.Clientes.Location = new System.Drawing.Point(12, 65);
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(1410, 267);
            this.Clientes.TabIndex = 1;
            this.Clientes.TabStop = false;
            this.Clientes.Text = "Todos los Clientes";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(249, 204);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(104, 49);
            this.btnAsignar.TabIndex = 9;
            this.btnAsignar.Text = "Adquirir prestamo seleccionado";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.Location = new System.Drawing.Point(168, 204);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(75, 49);
            this.btnModificarCliente.TabIndex = 8;
            this.btnModificarCliente.Text = "Modif.";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.BtnModificarCliente_Click);
            // 
            // btnBajaCliente
            // 
            this.btnBajaCliente.Location = new System.Drawing.Point(87, 204);
            this.btnBajaCliente.Name = "btnBajaCliente";
            this.btnBajaCliente.Size = new System.Drawing.Size(75, 49);
            this.btnBajaCliente.TabIndex = 7;
            this.btnBajaCliente.Text = "Baja";
            this.btnBajaCliente.UseVisualStyleBackColor = true;
            this.btnBajaCliente.Click += new System.EventHandler(this.BtnBajaCliente_Click);
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.Location = new System.Drawing.Point(6, 204);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(75, 49);
            this.btnAltaCliente.TabIndex = 6;
            this.btnAltaCliente.Text = "Alta";
            this.btnAltaCliente.UseVisualStyleBackColor = true;
            this.btnAltaCliente.Click += new System.EventHandler(this.BtnAltaCliente_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dgClPrestamosVencidos);
            this.groupBox5.Location = new System.Drawing.Point(1055, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(342, 192);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Préstamos Vencidos";
            // 
            // dgClPrestamosVencidos
            // 
            this.dgClPrestamosVencidos.AllowUserToAddRows = false;
            this.dgClPrestamosVencidos.AllowUserToDeleteRows = false;
            this.dgClPrestamosVencidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClPrestamosVencidos.Location = new System.Drawing.Point(6, 21);
            this.dgClPrestamosVencidos.Name = "dgClPrestamosVencidos";
            this.dgClPrestamosVencidos.ReadOnly = true;
            this.dgClPrestamosVencidos.RowHeadersWidth = 51;
            this.dgClPrestamosVencidos.RowTemplate.Height = 24;
            this.dgClPrestamosVencidos.Size = new System.Drawing.Size(330, 156);
            this.dgClPrestamosVencidos.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgClPrestamosPagados);
            this.groupBox4.Location = new System.Drawing.Point(707, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 192);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Préstamos Pagados";
            // 
            // dgClPrestamosPagados
            // 
            this.dgClPrestamosPagados.AllowUserToAddRows = false;
            this.dgClPrestamosPagados.AllowUserToDeleteRows = false;
            this.dgClPrestamosPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClPrestamosPagados.Location = new System.Drawing.Point(6, 21);
            this.dgClPrestamosPagados.Name = "dgClPrestamosPagados";
            this.dgClPrestamosPagados.ReadOnly = true;
            this.dgClPrestamosPagados.RowHeadersWidth = 51;
            this.dgClPrestamosPagados.RowTemplate.Height = 24;
            this.dgClPrestamosPagados.Size = new System.Drawing.Size(330, 156);
            this.dgClPrestamosPagados.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPagar);
            this.groupBox3.Controls.Add(this.dgClPrestamosNoPagados);
            this.groupBox3.Location = new System.Drawing.Point(359, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(342, 240);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Préstamos no pagados";
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(6, 183);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 49);
            this.btnPagar.TabIndex = 6;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // dgClPrestamosNoPagados
            // 
            this.dgClPrestamosNoPagados.AllowUserToAddRows = false;
            this.dgClPrestamosNoPagados.AllowUserToDeleteRows = false;
            this.dgClPrestamosNoPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgClPrestamosNoPagados.Location = new System.Drawing.Point(6, 21);
            this.dgClPrestamosNoPagados.Name = "dgClPrestamosNoPagados";
            this.dgClPrestamosNoPagados.ReadOnly = true;
            this.dgClPrestamosNoPagados.RowHeadersWidth = 51;
            this.dgClPrestamosNoPagados.RowTemplate.Height = 24;
            this.dgClPrestamosNoPagados.Size = new System.Drawing.Size(330, 156);
            this.dgClPrestamosNoPagados.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAltaPrestamoDolares);
            this.groupBox2.Controls.Add(this.btnModifPrestamo);
            this.groupBox2.Controls.Add(this.btnBajaPrestamo);
            this.groupBox2.Controls.Add(this.btnAltaPrestamoPesos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.datagridPagados);
            this.groupBox2.Controls.Add(this.datagridNoPagados);
            this.groupBox2.Controls.Add(this.lblTodos);
            this.groupBox2.Controls.Add(this.datagridPrestamos);
            this.groupBox2.Location = new System.Drawing.Point(12, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1057, 275);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Préstamos";
            // 
            // btnAltaPrestamoDolares
            // 
            this.btnAltaPrestamoDolares.Location = new System.Drawing.Point(94, 220);
            this.btnAltaPrestamoDolares.Name = "btnAltaPrestamoDolares";
            this.btnAltaPrestamoDolares.Size = new System.Drawing.Size(78, 49);
            this.btnAltaPrestamoDolares.TabIndex = 13;
            this.btnAltaPrestamoDolares.Text = "Alta Pres. Dólares";
            this.btnAltaPrestamoDolares.UseVisualStyleBackColor = true;
            this.btnAltaPrestamoDolares.Click += new System.EventHandler(this.BtnAltaPrestamoDolares_Click);
            // 
            // btnModifPrestamo
            // 
            this.btnModifPrestamo.Location = new System.Drawing.Point(259, 221);
            this.btnModifPrestamo.Name = "btnModifPrestamo";
            this.btnModifPrestamo.Size = new System.Drawing.Size(75, 49);
            this.btnModifPrestamo.TabIndex = 12;
            this.btnModifPrestamo.Text = "Modif.";
            this.btnModifPrestamo.UseVisualStyleBackColor = true;
            this.btnModifPrestamo.Click += new System.EventHandler(this.BtnModifPrestamo_Click);
            // 
            // btnBajaPrestamo
            // 
            this.btnBajaPrestamo.Location = new System.Drawing.Point(178, 221);
            this.btnBajaPrestamo.Name = "btnBajaPrestamo";
            this.btnBajaPrestamo.Size = new System.Drawing.Size(75, 49);
            this.btnBajaPrestamo.TabIndex = 11;
            this.btnBajaPrestamo.Text = "Baja";
            this.btnBajaPrestamo.UseVisualStyleBackColor = true;
            this.btnBajaPrestamo.Click += new System.EventHandler(this.BtnBajaPrestamo_Click);
            // 
            // btnAltaPrestamoPesos
            // 
            this.btnAltaPrestamoPesos.Location = new System.Drawing.Point(6, 221);
            this.btnAltaPrestamoPesos.Name = "btnAltaPrestamoPesos";
            this.btnAltaPrestamoPesos.Size = new System.Drawing.Size(82, 49);
            this.btnAltaPrestamoPesos.TabIndex = 10;
            this.btnAltaPrestamoPesos.Text = "Alta Pres. Pesos";
            this.btnAltaPrestamoPesos.UseVisualStyleBackColor = true;
            this.btnAltaPrestamoPesos.Click += new System.EventHandler(this.BtnAltaPrestamoPesos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(710, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Préstamos pagados";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Prestamos no pagados";
            // 
            // datagridPagados
            // 
            this.datagridPagados.AllowUserToAddRows = false;
            this.datagridPagados.AllowUserToDeleteRows = false;
            this.datagridPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPagados.Location = new System.Drawing.Point(713, 47);
            this.datagridPagados.Name = "datagridPagados";
            this.datagridPagados.ReadOnly = true;
            this.datagridPagados.RowHeadersWidth = 51;
            this.datagridPagados.RowTemplate.Height = 24;
            this.datagridPagados.Size = new System.Drawing.Size(330, 168);
            this.datagridPagados.TabIndex = 3;
            // 
            // datagridNoPagados
            // 
            this.datagridNoPagados.AllowUserToAddRows = false;
            this.datagridNoPagados.AllowUserToDeleteRows = false;
            this.datagridNoPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridNoPagados.Location = new System.Drawing.Point(365, 47);
            this.datagridNoPagados.Name = "datagridNoPagados";
            this.datagridNoPagados.ReadOnly = true;
            this.datagridNoPagados.RowHeadersWidth = 51;
            this.datagridNoPagados.RowTemplate.Height = 24;
            this.datagridNoPagados.Size = new System.Drawing.Size(330, 168);
            this.datagridNoPagados.TabIndex = 2;
            // 
            // lblTodos
            // 
            this.lblTodos.AutoSize = true;
            this.lblTodos.Location = new System.Drawing.Point(7, 22);
            this.lblTodos.Name = "lblTodos";
            this.lblTodos.Size = new System.Drawing.Size(196, 17);
            this.lblTodos.TabIndex = 1;
            this.lblTodos.Text = "Todos los préstamos emitidos";
            // 
            // datagridPrestamos
            // 
            this.datagridPrestamos.AllowUserToAddRows = false;
            this.datagridPrestamos.AllowUserToDeleteRows = false;
            this.datagridPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridPrestamos.Location = new System.Drawing.Point(6, 47);
            this.datagridPrestamos.Name = "datagridPrestamos";
            this.datagridPrestamos.ReadOnly = true;
            this.datagridPrestamos.RowHeadersWidth = 51;
            this.datagridPrestamos.RowTemplate.Height = 24;
            this.datagridPrestamos.Size = new System.Drawing.Size(347, 168);
            this.datagridPrestamos.TabIndex = 0;
            // 
            // textBoxFechaSistema
            // 
            this.textBoxFechaSistema.Location = new System.Drawing.Point(149, 14);
            this.textBoxFechaSistema.Name = "textBoxFechaSistema";
            this.textBoxFechaSistema.Size = new System.Drawing.Size(100, 22);
            this.textBoxFechaSistema.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha del Sistema:";
            // 
            // btnRecalcularFecha
            // 
            this.btnRecalcularFecha.Location = new System.Drawing.Point(255, 14);
            this.btnRecalcularFecha.Name = "btnRecalcularFecha";
            this.btnRecalcularFecha.Size = new System.Drawing.Size(85, 23);
            this.btnRecalcularFecha.TabIndex = 5;
            this.btnRecalcularFecha.Text = "Recalcular";
            this.btnRecalcularFecha.UseVisualStyleBackColor = true;
            this.btnRecalcularFecha.Click += new System.EventHandler(this.BtnRecalcular_Click);
            // 
            // lblFechaSistema
            // 
            this.lblFechaSistema.AutoSize = true;
            this.lblFechaSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSistema.ForeColor = System.Drawing.Color.Green;
            this.lblFechaSistema.Location = new System.Drawing.Point(347, 18);
            this.lblFechaSistema.Name = "lblFechaSistema";
            this.lblFechaSistema.Size = new System.Drawing.Size(159, 17);
            this.lblFechaSistema.TabIndex = 6;
            this.lblFechaSistema.Text = "-> Fecha del sistema";
            this.lblFechaSistema.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 625);
            this.Controls.Add(this.lblFechaSistema);
            this.Controls.Add(this.btnRecalcularFecha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxFechaSistema);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Clientes);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.datagridClientes)).EndInit();
            this.Clientes.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosVencidos)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosPagados)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClPrestamosNoPagados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPagados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridNoPagados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridPrestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridClientes;
        private System.Windows.Forms.GroupBox Clientes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView datagridPrestamos;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgClPrestamosNoPagados;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgClPrestamosVencidos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgClPrestamosPagados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datagridPagados;
        private System.Windows.Forms.DataGridView datagridNoPagados;
        private System.Windows.Forms.Label lblTodos;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnBajaCliente;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.Button btnModifPrestamo;
        private System.Windows.Forms.Button btnBajaPrestamo;
        private System.Windows.Forms.Button btnAltaPrestamoPesos;
        private System.Windows.Forms.TextBox textBoxFechaSistema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRecalcularFecha;
        private System.Windows.Forms.Button btnAltaPrestamoDolares;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label lblFechaSistema;
    }
}

