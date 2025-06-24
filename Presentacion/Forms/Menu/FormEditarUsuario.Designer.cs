namespace Presentacion.Forms.FormsCliente
{
    partial class frmEditarUsuario
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
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCambiarContraseña = new FontAwesome.Sharp.IconButton();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.txtNuevaContraseña = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnGuardarCambios = new FontAwesome.Sharp.IconButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDepositar = new FontAwesome.Sharp.IconButton();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Datos del Usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.btnCambiarContraseña);
            this.panel1.Controls.Add(this.txtConfirmarContraseña);
            this.panel1.Controls.Add(this.txtNuevaContraseña);
            this.panel1.Controls.Add(this.txtContraseña);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.btnGuardarCambios);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(27, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 267);
            this.panel1.TabIndex = 34;
            // 
            // btnCambiarContraseña
            // 
            this.btnCambiarContraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarContraseña.IconChar = FontAwesome.Sharp.IconChar.Certificate;
            this.btnCambiarContraseña.IconColor = System.Drawing.Color.Black;
            this.btnCambiarContraseña.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCambiarContraseña.IconSize = 25;
            this.btnCambiarContraseña.Location = new System.Drawing.Point(496, 222);
            this.btnCambiarContraseña.Name = "btnCambiarContraseña";
            this.btnCambiarContraseña.Size = new System.Drawing.Size(181, 30);
            this.btnCambiarContraseña.TabIndex = 30;
            this.btnCambiarContraseña.Text = "Cambiar Contraseña";
            this.btnCambiarContraseña.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarContraseña.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarContraseña.UseVisualStyleBackColor = true;
            this.btnCambiarContraseña.Click += new System.EventHandler(this.btnCambiarContraseña_Click);
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(196, 229);
            this.txtConfirmarContraseña.MaxLength = 16;
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(279, 23);
            this.txtConfirmarContraseña.TabIndex = 27;
            this.txtConfirmarContraseña.UseSystemPasswordChar = true;
            // 
            // txtNuevaContraseña
            // 
            this.txtNuevaContraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaContraseña.Location = new System.Drawing.Point(179, 186);
            this.txtNuevaContraseña.MaxLength = 16;
            this.txtNuevaContraseña.Name = "txtNuevaContraseña";
            this.txtNuevaContraseña.Size = new System.Drawing.Size(296, 23);
            this.txtNuevaContraseña.TabIndex = 26;
            this.txtNuevaContraseña.UseSystemPasswordChar = true;
            // 
            // txtContraseña
            // 
            this.txtContraseña.Enabled = false;
            this.txtContraseña.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(179, 150);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.ReadOnly = true;
            this.txtContraseña.Size = new System.Drawing.Size(295, 23);
            this.txtContraseña.TabIndex = 25;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(93, 88);
            this.txtUsuario.MaxLength = 20;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(382, 23);
            this.txtUsuario.TabIndex = 24;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(93, 51);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(81, 23);
            this.txtID.TabIndex = 23;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.btnGuardarCambios.IconColor = System.Drawing.Color.Black;
            this.btnGuardarCambios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardarCambios.IconSize = 25;
            this.btnGuardarCambios.Location = new System.Drawing.Point(496, 81);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(181, 30);
            this.btnGuardarCambios.TabIndex = 22;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 25);
            this.label8.TabIndex = 21;
            this.label8.Text = "Confirmar Contraseña:";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(15, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Nueva Contraseña:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Contraseña Actual:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Usuario:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "ID:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Saldo y Dinero";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Saldo actual:";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(14, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 25);
            this.label9.TabIndex = 18;
            this.label9.Text = "Monto a depositar:";
            // 
            // btnDepositar
            // 
            this.btnDepositar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepositar.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckDollar;
            this.btnDepositar.IconColor = System.Drawing.Color.Black;
            this.btnDepositar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDepositar.IconSize = 25;
            this.btnDepositar.Location = new System.Drawing.Point(314, 84);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(109, 26);
            this.btnDepositar.TabIndex = 28;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepositar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // txtSaldo
            // 
            this.txtSaldo.Enabled = false;
            this.txtSaldo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(179, 46);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(114, 23);
            this.txtSaldo.TabIndex = 28;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.Location = new System.Drawing.Point(179, 87);
            this.txtMonto.MaxLength = 6;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(114, 23);
            this.txtMonto.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.txtMonto);
            this.panel2.Controls.Add(this.txtSaldo);
            this.panel2.Controls.Add(this.btnDepositar);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(27, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(695, 129);
            this.panel2.TabIndex = 35;
            // 
            // frmEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEditarUsuario";
            this.Text = "FormEditarUsuario";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnGuardarCambios;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.TextBox txtNuevaContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtID;
        private FontAwesome.Sharp.IconButton btnCambiarContraseña;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton btnDepositar;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Panel panel2;
    }
}