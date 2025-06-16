namespace Presentacion.Forms
{
    partial class FormVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePackerVenta = new System.Windows.Forms.DateTimePicker();
            this.txtVentaCodigo = new System.Windows.Forms.TextBox();
            this.txtVentaNombre = new System.Windows.Forms.TextBox();
            this.txtVentaCantidad = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrarVenta = new FontAwesome.Sharp.IconButton();
            this.dGVVenta = new System.Windows.Forms.DataGridView();
            this.clmVentaNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVentaProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVentaCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmVentaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(30, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(231, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Registro de Ventas";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 18;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(403, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "Cantidad:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(403, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "Fecha:";
            // 
            // dateTimePackerVenta
            // 
            this.dateTimePackerVenta.Location = new System.Drawing.Point(484, 92);
            this.dateTimePackerVenta.Name = "dateTimePackerVenta";
            this.dateTimePackerVenta.Size = new System.Drawing.Size(250, 20);
            this.dateTimePackerVenta.TabIndex = 22;
            // 
            // txtVentaCodigo
            // 
            this.txtVentaCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaCodigo.Location = new System.Drawing.Point(120, 48);
            this.txtVentaCodigo.Name = "txtVentaCodigo";
            this.txtVentaCodigo.Size = new System.Drawing.Size(250, 22);
            this.txtVentaCodigo.TabIndex = 23;
            // 
            // txtVentaNombre
            // 
            this.txtVentaNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaNombre.Location = new System.Drawing.Point(484, 48);
            this.txtVentaNombre.Name = "txtVentaNombre";
            this.txtVentaNombre.ReadOnly = true;
            this.txtVentaNombre.Size = new System.Drawing.Size(250, 22);
            this.txtVentaNombre.TabIndex = 24;
            // 
            // txtVentaCantidad
            // 
            this.txtVentaCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVentaCantidad.Location = new System.Drawing.Point(120, 89);
            this.txtVentaCantidad.Name = "txtVentaCantidad";
            this.txtVentaCantidad.Size = new System.Drawing.Size(250, 22);
            this.txtVentaCantidad.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.dGVVenta);
            this.panel1.Location = new System.Drawing.Point(22, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 216);
            this.panel1.TabIndex = 28;
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.btnRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRegistrarVenta.IconSize = 25;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(34, 134);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(133, 30);
            this.btnRegistrarVenta.TabIndex = 26;
            this.btnRegistrarVenta.Text = "Registrar Venta";
            this.btnRegistrarVenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegistrarVenta.UseVisualStyleBackColor = true;
            // 
            // dGVVenta
            // 
            this.dGVVenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVVenta.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dGVVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVVenta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGVVenta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVVenta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmVentaNumero,
            this.clmVentaProducto,
            this.clmVentaCantidad,
            this.clmVentaTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVVenta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVVenta.EnableHeadersVisualStyles = false;
            this.dGVVenta.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVVenta.Location = new System.Drawing.Point(16, 26);
            this.dGVVenta.Name = "dGVVenta";
            this.dGVVenta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVVenta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVVenta.RowHeadersVisible = false;
            this.dGVVenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVVenta.Size = new System.Drawing.Size(699, 164);
            this.dGVVenta.TabIndex = 16;
            // 
            // clmVentaNumero
            // 
            this.clmVentaNumero.HeaderText = "Nº Venta";
            this.clmVentaNumero.Name = "clmVentaNumero";
            this.clmVentaNumero.ReadOnly = true;
            // 
            // clmVentaProducto
            // 
            this.clmVentaProducto.HeaderText = "Producto";
            this.clmVentaProducto.Name = "clmVentaProducto";
            this.clmVentaProducto.ReadOnly = true;
            // 
            // clmVentaCantidad
            // 
            this.clmVentaCantidad.HeaderText = "Cantidad";
            this.clmVentaCantidad.Name = "clmVentaCantidad";
            this.clmVentaCantidad.ReadOnly = true;
            // 
            // clmVentaTotal
            // 
            this.clmVentaTotal.HeaderText = "Total";
            this.clmVentaTotal.Name = "clmVentaTotal";
            this.clmVentaTotal.ReadOnly = true;
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrarVenta);
            this.Controls.Add(this.txtVentaCantidad);
            this.Controls.Add(this.txtVentaNombre);
            this.Controls.Add(this.txtVentaCodigo);
            this.Controls.Add(this.dateTimePackerVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Name = "FormVenta";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePackerVenta;
        private System.Windows.Forms.TextBox txtVentaCodigo;
        private System.Windows.Forms.TextBox txtVentaNombre;
        private System.Windows.Forms.TextBox txtVentaCantidad;
        private FontAwesome.Sharp.IconButton btnRegistrarVenta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dGVVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVentaNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVentaProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVentaCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmVentaTotal;
    }
}