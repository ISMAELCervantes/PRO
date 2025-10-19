namespace PantallaClientes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbBuscar = new Label();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            dataGridView1 = new DataGridView();
            región = new DataGridViewTextBoxColumn();
            país = new DataGridViewTextBoxColumn();
            fax = new DataGridViewTextBoxColumn();
            compañía = new DataGridViewTextBoxColumn();
            título = new DataGridViewTextBoxColumn();
            ciudad = new DataGridViewTextBoxColumn();
            Postal = new DataGridViewTextBoxColumn();
            teléfono = new DataGridViewTextBoxColumn();
            lbID = new Label();
            lbContacto = new Label();
            lbDirección = new Label();
            lbRegión = new Label();
            lbPaís = new Label();
            lbFax = new Label();
            lbCompañía = new Label();
            lbTítulo = new Label();
            lbCiudad = new Label();
            lbCPostal = new Label();
            lbTeléfono = new Label();
            txtID = new TextBox();
            txtContacto = new TextBox();
            txtDirección = new TextBox();
            txtRegión = new TextBox();
            txtPaís = new TextBox();
            txtFax = new TextBox();
            txtCompañía = new TextBox();
            txtTítulo = new TextBox();
            txtCiudad = new TextBox();
            txtCPostal = new TextBox();
            txtTeléfono = new TextBox();
            btnInsertar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lbBuscar
            // 
            lbBuscar.AutoSize = true;
            lbBuscar.Location = new Point(12, 40);
            lbBuscar.Name = "lbBuscar";
            lbBuscar.Size = new Size(55, 20);
            lbBuscar.TabIndex = 0;
            lbBuscar.Text = "Buscar:";
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(102, 33);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(125, 27);
            txtBusqueda.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(342, 36);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { región, país, fax, compañía, título, ciudad, Postal, teléfono });
            dataGridView1.Location = new Point(12, 105);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1051, 188);
            dataGridView1.TabIndex = 3;
            // 
            // región
            // 
            región.DataPropertyName = "Región";
            región.HeaderText = "Región";
            región.MinimumWidth = 6;
            región.Name = "región";
            región.Width = 125;
            // 
            // país
            // 
            país.DataPropertyName = "País";
            país.HeaderText = "País";
            país.MinimumWidth = 6;
            país.Name = "país";
            país.Width = 125;
            // 
            // fax
            // 
            fax.DataPropertyName = "Fax";
            fax.HeaderText = "Fax";
            fax.MinimumWidth = 6;
            fax.Name = "fax";
            fax.Width = 125;
            // 
            // compañía
            // 
            compañía.DataPropertyName = "Compañía";
            compañía.HeaderText = "Compañía";
            compañía.MinimumWidth = 6;
            compañía.Name = "compañía";
            compañía.Width = 125;
            // 
            // título
            // 
            título.DataPropertyName = "Título";
            título.HeaderText = "Título";
            título.MinimumWidth = 6;
            título.Name = "título";
            título.Width = 125;
            // 
            // ciudad
            // 
            ciudad.DataPropertyName = "Ciudad";
            ciudad.HeaderText = "Ciudad";
            ciudad.MinimumWidth = 6;
            ciudad.Name = "ciudad";
            ciudad.Width = 125;
            // 
            // Postal
            // 
            Postal.HeaderText = "C. Postal";
            Postal.MinimumWidth = 6;
            Postal.Name = "Postal";
            Postal.Width = 125;
            // 
            // teléfono
            // 
            teléfono.DataPropertyName = "Teléfono";
            teléfono.HeaderText = "Teléfono";
            teléfono.MinimumWidth = 6;
            teléfono.Name = "teléfono";
            teléfono.Width = 125;
            // 
            // lbID
            // 
            lbID.AutoSize = true;
            lbID.Location = new Point(17, 351);
            lbID.Name = "lbID";
            lbID.Size = new Size(27, 20);
            lbID.TabIndex = 4;
            lbID.Text = "ID:";
            // 
            // lbContacto
            // 
            lbContacto.AutoSize = true;
            lbContacto.Location = new Point(17, 424);
            lbContacto.Name = "lbContacto";
            lbContacto.Size = new Size(72, 20);
            lbContacto.TabIndex = 5;
            lbContacto.Text = "Contacto:";
            // 
            // lbDirección
            // 
            lbDirección.AutoSize = true;
            lbDirección.Location = new Point(17, 502);
            lbDirección.Name = "lbDirección";
            lbDirección.Size = new Size(75, 20);
            lbDirección.TabIndex = 6;
            lbDirección.Text = "Dirección:";
            // 
            // lbRegión
            // 
            lbRegión.AutoSize = true;
            lbRegión.Location = new Point(17, 575);
            lbRegión.Name = "lbRegión";
            lbRegión.Size = new Size(59, 20);
            lbRegión.TabIndex = 7;
            lbRegión.Text = "Región:";
            // 
            // lbPaís
            // 
            lbPaís.AutoSize = true;
            lbPaís.Location = new Point(17, 669);
            lbPaís.Name = "lbPaís";
            lbPaís.Size = new Size(37, 20);
            lbPaís.TabIndex = 8;
            lbPaís.Text = "País:";
            // 
            // lbFax
            // 
            lbFax.AutoSize = true;
            lbFax.Location = new Point(382, 351);
            lbFax.Name = "lbFax";
            lbFax.Size = new Size(33, 20);
            lbFax.TabIndex = 9;
            lbFax.Text = "Fax:";
            // 
            // lbCompañía
            // 
            lbCompañía.AutoSize = true;
            lbCompañía.Location = new Point(382, 424);
            lbCompañía.Name = "lbCompañía";
            lbCompañía.Size = new Size(80, 20);
            lbCompañía.TabIndex = 10;
            lbCompañía.Text = "Compañía:";
            // 
            // lbTítulo
            // 
            lbTítulo.AutoSize = true;
            lbTítulo.Location = new Point(383, 502);
            lbTítulo.Name = "lbTítulo";
            lbTítulo.Size = new Size(50, 20);
            lbTítulo.TabIndex = 11;
            lbTítulo.Text = "Título:";
            // 
            // lbCiudad
            // 
            lbCiudad.AutoSize = true;
            lbCiudad.Location = new Point(383, 575);
            lbCiudad.Name = "lbCiudad";
            lbCiudad.Size = new Size(59, 20);
            lbCiudad.TabIndex = 12;
            lbCiudad.Text = "Ciudad:";
            // 
            // lbCPostal
            // 
            lbCPostal.AutoSize = true;
            lbCPostal.Location = new Point(383, 654);
            lbCPostal.Name = "lbCPostal";
            lbCPostal.Size = new Size(67, 20);
            lbCPostal.TabIndex = 13;
            lbCPostal.Text = "C. Postal:";
            // 
            // lbTeléfono
            // 
            lbTeléfono.AutoSize = true;
            lbTeléfono.Location = new Point(775, 354);
            lbTeléfono.Name = "lbTeléfono";
            lbTeléfono.Size = new Size(70, 20);
            lbTeléfono.TabIndex = 14;
            lbTeléfono.Text = "Teléfono:";
            // 
            // txtID
            // 
            txtID.Location = new Point(102, 351);
            txtID.Name = "txtID";
            txtID.Size = new Size(209, 27);
            txtID.TabIndex = 15;
            // 
            // txtContacto
            // 
            txtContacto.Location = new Point(102, 424);
            txtContacto.Name = "txtContacto";
            txtContacto.Size = new Size(209, 27);
            txtContacto.TabIndex = 16;
            // 
            // txtDirección
            // 
            txtDirección.Location = new Point(102, 502);
            txtDirección.Name = "txtDirección";
            txtDirección.Size = new Size(209, 27);
            txtDirección.TabIndex = 17;
            // 
            // txtRegión
            // 
            txtRegión.Location = new Point(102, 575);
            txtRegión.Name = "txtRegión";
            txtRegión.Size = new Size(209, 27);
            txtRegión.TabIndex = 18;
            // 
            // txtPaís
            // 
            txtPaís.Location = new Point(102, 669);
            txtPaís.Name = "txtPaís";
            txtPaís.Size = new Size(209, 27);
            txtPaís.TabIndex = 19;
            // 
            // txtFax
            // 
            txtFax.Location = new Point(476, 351);
            txtFax.Name = "txtFax";
            txtFax.Size = new Size(228, 27);
            txtFax.TabIndex = 20;
            // 
            // txtCompañía
            // 
            txtCompañía.Location = new Point(476, 424);
            txtCompañía.Name = "txtCompañía";
            txtCompañía.Size = new Size(228, 27);
            txtCompañía.TabIndex = 21;
            // 
            // txtTítulo
            // 
            txtTítulo.Location = new Point(476, 499);
            txtTítulo.Name = "txtTítulo";
            txtTítulo.Size = new Size(228, 27);
            txtTítulo.TabIndex = 22;
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(476, 575);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(228, 27);
            txtCiudad.TabIndex = 23;
            // 
            // txtCPostal
            // 
            txtCPostal.Location = new Point(476, 651);
            txtCPostal.Name = "txtCPostal";
            txtCPostal.Size = new Size(228, 27);
            txtCPostal.TabIndex = 24;
            // 
            // txtTeléfono
            // 
            txtTeléfono.Location = new Point(864, 347);
            txtTeléfono.Name = "txtTeléfono";
            txtTeléfono.Size = new Size(176, 27);
            txtTeléfono.TabIndex = 25;
            // 
            // btnInsertar
            // 
            btnInsertar.Location = new Point(775, 424);
            btnInsertar.Name = "btnInsertar";
            btnInsertar.Size = new Size(92, 29);
            btnInsertar.TabIndex = 26;
            btnInsertar.Text = "Insertar";
            btnInsertar.UseVisualStyleBackColor = true;
            btnInsertar.Click += btnInsertar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(775, 502);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(92, 29);
            btnActualizar.TabIndex = 27;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(775, 566);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 29);
            btnEliminar.TabIndex = 28;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(775, 636);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 29;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 862);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnInsertar);
            Controls.Add(txtTeléfono);
            Controls.Add(txtCPostal);
            Controls.Add(txtCiudad);
            Controls.Add(txtTítulo);
            Controls.Add(txtCompañía);
            Controls.Add(txtFax);
            Controls.Add(txtPaís);
            Controls.Add(txtRegión);
            Controls.Add(txtDirección);
            Controls.Add(txtContacto);
            Controls.Add(txtID);
            Controls.Add(lbTeléfono);
            Controls.Add(lbCPostal);
            Controls.Add(lbCiudad);
            Controls.Add(lbTítulo);
            Controls.Add(lbCompañía);
            Controls.Add(lbFax);
            Controls.Add(lbPaís);
            Controls.Add(lbRegión);
            Controls.Add(lbDirección);
            Controls.Add(lbContacto);
            Controls.Add(lbID);
            Controls.Add(dataGridView1);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(lbBuscar);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbBuscar;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private DataGridView dataGridView1;
        private Label lbID;
        private Label lbContacto;
        private Label lbDirección;
        private Label lbRegión;
        private Label lbPaís;
        private Label lbFax;
        private Label lbCompañía;
        private Label lbTítulo;
        private Label lbCiudad;
        private Label lbCPostal;
        private Label lbTeléfono;
        private TextBox txtID;
        private TextBox txtContacto;
        private TextBox txtDirección;
        private TextBox txtRegión;
        private TextBox txtPaís;
        private TextBox txtFax;
        private TextBox txtCompañía;
        private TextBox txtTítulo;
        private TextBox txtCiudad;
        private TextBox txtCPostal;
        private TextBox txtTeléfono;
        private Button btnInsertar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridViewTextBoxColumn región;
        private DataGridViewTextBoxColumn país;
        private DataGridViewTextBoxColumn fax;
        private DataGridViewTextBoxColumn compañía;
        private DataGridViewTextBoxColumn título;
        private DataGridViewTextBoxColumn ciudad;
        private DataGridViewTextBoxColumn Postal;
        private DataGridViewTextBoxColumn teléfono;
    }
}
