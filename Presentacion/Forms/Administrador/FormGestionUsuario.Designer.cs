namespace Presentacion.Forms.FormsAdministrador
{
    partial class frmGestionUsuario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            panel1 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            btnBuscar = new FontAwesome.Sharp.IconButton();
            txtBuscar = new System.Windows.Forms.TextBox();
            dGVUsuarios = new System.Windows.Forms.DataGridView();
            ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            NombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Contraseña = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            btnModificar = new FontAwesome.Sharp.IconButton();
            btnAgregar = new FontAwesome.Sharp.IconButton();
            txtUsuario = new System.Windows.Forms.TextBox();
            txtID = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            cmbRol = new System.Windows.Forms.ComboBox();
            label7 = new System.Windows.Forms.Label();
            txtContraseña = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            txtSaldo = new System.Windows.Forms.TextBox();
            panel2 = new System.Windows.Forms.Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGVUsuarios).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnBuscar);
            panel1.Controls.Add(txtBuscar);
            panel1.Controls.Add(dGVUsuarios);
            panel1.Location = new System.Drawing.Point(38, 14);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(842, 257);
            panel1.TabIndex = 31;
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label5.ForeColor = System.Drawing.Color.White;
            label5.Location = new System.Drawing.Point(20, 16);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(251, 29);
            label5.TabIndex = 12;
            label5.Text = "Buscar usuario por Nombre:";
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = System.Drawing.Color.Black;
            btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBuscar.IconSize = 20;
            btnBuscar.Location = new System.Drawing.Point(609, 13);
            btnBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new System.Drawing.Size(103, 32);
            btnBuscar.TabIndex = 13;
            btnBuscar.Text = "Buscar";
            btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtBuscar.Location = new System.Drawing.Point(278, 16);
            txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(324, 23);
            txtBuscar.TabIndex = 14;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // dGVUsuarios
            // 
            dGVUsuarios.AllowUserToAddRows = false;
            dGVUsuarios.AllowUserToDeleteRows = false;
            dGVUsuarios.AllowUserToResizeColumns = false;
            dGVUsuarios.AllowUserToResizeRows = false;
            dGVUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dGVUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(45, 66, 91);
            dGVUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dGVUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dGVUsuarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dGVUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dGVUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGVUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { ID, Rol, NombreUsuario, Contraseña, Saldo });
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(45, 66, 91);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dGVUsuarios.DefaultCellStyle = dataGridViewCellStyle4;
            dGVUsuarios.EnableHeadersVisualStyles = false;
            dGVUsuarios.GridColor = System.Drawing.Color.SteelBlue;
            dGVUsuarios.Location = new System.Drawing.Point(13, 51);
            dGVUsuarios.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dGVUsuarios.Name = "dGVUsuarios";
            dGVUsuarios.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(45, 66, 91);
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dGVUsuarios.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dGVUsuarios.RowHeadersVisible = false;
            dGVUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dGVUsuarios.Size = new System.Drawing.Size(816, 198);
            dGVUsuarios.TabIndex = 15;
            dGVUsuarios.CellDoubleClick += dGVUsuarios_CellDoubleClick;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Rol
            // 
            Rol.DataPropertyName = "Rol";
            Rol.HeaderText = "Rol";
            Rol.Name = "Rol";
            Rol.ReadOnly = true;
            // 
            // NombreUsuario
            // 
            NombreUsuario.DataPropertyName = "Nombre";
            dataGridViewCellStyle2.Format = "C2";
            NombreUsuario.DefaultCellStyle = dataGridViewCellStyle2;
            NombreUsuario.HeaderText = "Nombre";
            NombreUsuario.Name = "NombreUsuario";
            NombreUsuario.ReadOnly = true;
            // 
            // Contraseña
            // 
            Contraseña.DataPropertyName = "Contraseña";
            Contraseña.HeaderText = "Contraseña";
            Contraseña.Name = "Contraseña";
            Contraseña.ReadOnly = true;
            Contraseña.Visible = false;
            // 
            // Saldo
            // 
            Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            Saldo.DefaultCellStyle = dataGridViewCellStyle3;
            Saldo.HeaderText = "Saldo";
            Saldo.Name = "Saldo";
            Saldo.ReadOnly = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnEliminar.IconColor = System.Drawing.Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 25;
            btnEliminar.Location = new System.Drawing.Point(656, 128);
            btnEliminar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(124, 35);
            btnEliminar.TabIndex = 42;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnModificar.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            btnModificar.IconColor = System.Drawing.Color.Black;
            btnModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnModificar.IconSize = 25;
            btnModificar.Location = new System.Drawing.Point(656, 70);
            btnModificar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(124, 35);
            btnModificar.TabIndex = 41;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnAgregar.IconColor = System.Drawing.Color.Black;
            btnAgregar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnAgregar.IconSize = 25;
            btnAgregar.Location = new System.Drawing.Point(656, 14);
            btnAgregar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new System.Drawing.Size(124, 35);
            btnAgregar.TabIndex = 40;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtUsuario.Location = new System.Drawing.Point(155, 99);
            txtUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtUsuario.MaxLength = 20;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new System.Drawing.Size(389, 21);
            txtUsuario.TabIndex = 37;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtID.Location = new System.Drawing.Point(155, 12);
            txtID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new System.Drawing.Size(144, 21);
            txtID.TabIndex = 36;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(28, 59);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 29);
            label3.TabIndex = 34;
            label3.Text = "Rol:";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(28, 99);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(117, 29);
            label2.TabIndex = 33;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(28, 14);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 29);
            label1.TabIndex = 32;
            label1.Text = "ID:";
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRol.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Cliente" });
            cmbRol.Location = new System.Drawing.Point(155, 59);
            cmbRol.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new System.Drawing.Size(144, 24);
            cmbRol.TabIndex = 43;
            // 
            // label7
            // 
            label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label7.ForeColor = System.Drawing.Color.White;
            label7.Location = new System.Drawing.Point(23, 134);
            label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(128, 29);
            label7.TabIndex = 44;
            label7.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtContraseña.Location = new System.Drawing.Point(155, 138);
            txtContraseña.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtContraseña.MaxLength = 16;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new System.Drawing.Size(389, 21);
            txtContraseña.TabIndex = 45;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label8.ForeColor = System.Drawing.Color.White;
            label8.Location = new System.Drawing.Point(321, 12);
            label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(72, 29);
            label8.TabIndex = 46;
            label8.Text = "Saldo:";
            // 
            // txtSaldo
            // 
            txtSaldo.Enabled = false;
            txtSaldo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            txtSaldo.Location = new System.Drawing.Point(400, 12);
            txtSaldo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.ReadOnly = true;
            txtSaldo.Size = new System.Drawing.Size(144, 22);
            txtSaldo.TabIndex = 47;
            txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
            panel2.Controls.Add(btnEliminar);
            panel2.Controls.Add(txtContraseña);
            panel2.Controls.Add(btnModificar);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(btnAgregar);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtSaldo);
            panel2.Controls.Add(txtID);
            panel2.Controls.Add(txtUsuario);
            panel2.Controls.Add(cmbRol);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Location = new System.Drawing.Point(38, 278);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(844, 177);
            panel2.TabIndex = 48;
            // 
            // frmGestionUsuario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(34, 33, 74);
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "frmGestionUsuario";
            Text = "FormGestionUsuario";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGVUsuarios).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dGVUsuarios;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contraseña;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
    }
}