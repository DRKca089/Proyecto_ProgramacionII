namespace Presentacion.Forms
{
    partial class FormReporte
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReporteStockBajo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReporteTopVendidos = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTotalIngresos = new System.Windows.Forms.Label();
            this.dGVTop = new System.Windows.Forms.DataGridView();
            this.clmTopCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTopNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTopCantidD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dGVStockBajo = new System.Windows.Forms.DataGridView();
            this.clmStockCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStockNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStockCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStockBajo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Stock bajo:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Total ingresos:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(22, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Top productos vendidos:";
            // 
            // txtReporteStockBajo
            // 
            this.txtReporteStockBajo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReporteStockBajo.Location = new System.Drawing.Point(25, 50);
            this.txtReporteStockBajo.MaxLength = 6;
            this.txtReporteStockBajo.Name = "txtReporteStockBajo";
            this.txtReporteStockBajo.Size = new System.Drawing.Size(206, 22);
            this.txtReporteStockBajo.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(102, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 25);
            this.label5.TabIndex = 26;
            // 
            // txtReporteTopVendidos
            // 
            this.txtReporteTopVendidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReporteTopVendidos.Location = new System.Drawing.Point(25, 130);
            this.txtReporteTopVendidos.MaxLength = 6;
            this.txtReporteTopVendidos.Name = "txtReporteTopVendidos";
            this.txtReporteTopVendidos.Size = new System.Drawing.Size(206, 22);
            this.txtReporteTopVendidos.TabIndex = 27;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.lblTotalIngresos);
            this.panel1.Controls.Add(this.dGVTop);
            this.panel1.Controls.Add(this.dGVStockBajo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(251, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 407);
            this.panel1.TabIndex = 30;
            // 
            // lblTotalIngresos
            // 
            this.lblTotalIngresos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIngresos.ForeColor = System.Drawing.Color.White;
            this.lblTotalIngresos.Location = new System.Drawing.Point(131, 366);
            this.lblTotalIngresos.Name = "lblTotalIngresos";
            this.lblTotalIngresos.Size = new System.Drawing.Size(130, 23);
            this.lblTotalIngresos.TabIndex = 39;
            // 
            // dGVTop
            // 
            this.dGVTop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVTop.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dGVTop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVTop.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGVTop.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVTop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVTop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVTop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTopCodigo,
            this.clmTopNombre,
            this.clmTopCantidD});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVTop.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVTop.EnableHeadersVisualStyles = false;
            this.dGVTop.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVTop.Location = new System.Drawing.Point(13, 196);
            this.dGVTop.Name = "dGVTop";
            this.dGVTop.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVTop.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVTop.RowHeadersVisible = false;
            this.dGVTop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVTop.Size = new System.Drawing.Size(457, 155);
            this.dGVTop.TabIndex = 34;
            // 
            // clmTopCodigo
            // 
            this.clmTopCodigo.HeaderText = "Código";
            this.clmTopCodigo.Name = "clmTopCodigo";
            this.clmTopCodigo.ReadOnly = true;
            // 
            // clmTopNombre
            // 
            this.clmTopNombre.HeaderText = "Nombre";
            this.clmTopNombre.Name = "clmTopNombre";
            this.clmTopNombre.ReadOnly = true;
            // 
            // clmTopCantidD
            // 
            this.clmTopCantidD.HeaderText = "Cant. Vendida";
            this.clmTopCantidD.Name = "clmTopCantidD";
            this.clmTopCantidD.ReadOnly = true;
            // 
            // dGVStockBajo
            // 
            this.dGVStockBajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVStockBajo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dGVStockBajo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGVStockBajo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dGVStockBajo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVStockBajo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGVStockBajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVStockBajo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmStockCodigo,
            this.clmStockNombre,
            this.clmStockCantidad});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVStockBajo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dGVStockBajo.EnableHeadersVisualStyles = false;
            this.dGVStockBajo.GridColor = System.Drawing.Color.SteelBlue;
            this.dGVStockBajo.Location = new System.Drawing.Point(13, 38);
            this.dGVStockBajo.Name = "dGVStockBajo";
            this.dGVStockBajo.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVStockBajo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dGVStockBajo.RowHeadersVisible = false;
            this.dGVStockBajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dGVStockBajo.Size = new System.Drawing.Size(457, 127);
            this.dGVStockBajo.TabIndex = 33;
            // 
            // clmStockCodigo
            // 
            this.clmStockCodigo.HeaderText = "Código";
            this.clmStockCodigo.Name = "clmStockCodigo";
            this.clmStockCodigo.ReadOnly = true;
            // 
            // clmStockNombre
            // 
            this.clmStockNombre.HeaderText = "Nombre";
            this.clmStockNombre.Name = "clmStockNombre";
            this.clmStockNombre.ReadOnly = true;
            // 
            // clmStockCantidad
            // 
            this.clmStockCantidad.HeaderText = "Cant. Disponible";
            this.clmStockCantidad.Name = "clmStockCantidad";
            this.clmStockCantidad.ReadOnly = true;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(148, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 25);
            this.label7.TabIndex = 32;
            this.label7.Text = "Productos Más Vendidos";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(148, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Productos con Stock Bajo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReporte.IconChar = FontAwesome.Sharp.IconChar.Pen;
            this.btnGenerarReporte.IconColor = System.Drawing.Color.Black;
            this.btnGenerarReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGenerarReporte.IconSize = 18;
            this.btnGenerarReporte.Location = new System.Drawing.Point(52, 264);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(166, 26);
            this.btnGenerarReporte.TabIndex = 28;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.txtReporteTopVendidos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtReporteStockBajo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReporte";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVStockBajo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReporteStockBajo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReporteTopVendidos;
        private FontAwesome.Sharp.IconButton btnGenerarReporte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dGVTop;
        private System.Windows.Forms.DataGridView dGVStockBajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStockCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStockNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStockCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTopCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTopNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTopCantidD;
        private System.Windows.Forms.Label lblTotalIngresos;
    }
}