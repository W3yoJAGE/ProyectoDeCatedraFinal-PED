namespace ProyectoCatedraPED_SistemaInventario
{
    partial class TerminalPV
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
            this.gp2 = new System.Windows.Forms.GroupBox();
            this.dtTerminalPunto = new System.Windows.Forms.DataGridView();
            this.btnFinTransaccion = new System.Windows.Forms.Button();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gp3 = new System.Windows.Forms.GroupBox();
            this.dtVentasRecientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gp2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTerminalPunto)).BeginInit();
            this.gp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVentasRecientes)).BeginInit();
            this.SuspendLayout();
            // 
            // gp2
            // 
            this.gp2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gp2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.gp2.Controls.Add(this.dtTerminalPunto);
            this.gp2.Controls.Add(this.btnFinTransaccion);
            this.gp2.Controls.Add(this.txtBuscarProducto);
            this.gp2.Controls.Add(this.label1);
            this.gp2.Location = new System.Drawing.Point(12, 22);
            this.gp2.Margin = new System.Windows.Forms.Padding(1);
            this.gp2.Name = "gp2";
            this.gp2.Size = new System.Drawing.Size(521, 321);
            this.gp2.TabIndex = 0;
            this.gp2.TabStop = false;
            // 
            // dtTerminalPunto
            // 
            this.dtTerminalPunto.AllowUserToDeleteRows = false;
            this.dtTerminalPunto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtTerminalPunto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtTerminalPunto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTerminalPunto.Location = new System.Drawing.Point(27, 119);
            this.dtTerminalPunto.Margin = new System.Windows.Forms.Padding(2);
            this.dtTerminalPunto.Name = "dtTerminalPunto";
            this.dtTerminalPunto.ReadOnly = true;
            this.dtTerminalPunto.RowHeadersWidth = 51;
            this.dtTerminalPunto.RowTemplate.Height = 24;
            this.dtTerminalPunto.Size = new System.Drawing.Size(467, 106);
            this.dtTerminalPunto.TabIndex = 11;
            this.dtTerminalPunto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtTerminalPunto_CellDoubleClick);
            // 
            // btnFinTransaccion
            // 
            this.btnFinTransaccion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(202)))), ((int)(((byte)(218)))));
            this.btnFinTransaccion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.btnFinTransaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinTransaccion.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinTransaccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btnFinTransaccion.Location = new System.Drawing.Point(330, 238);
            this.btnFinTransaccion.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinTransaccion.Name = "btnFinTransaccion";
            this.btnFinTransaccion.Size = new System.Drawing.Size(164, 37);
            this.btnFinTransaccion.TabIndex = 14;
            this.btnFinTransaccion.Text = "Finalizar Transacción ➡️";
            this.btnFinTransaccion.UseVisualStyleBackColor = false;
            this.btnFinTransaccion.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscarProducto.ForeColor = System.Drawing.Color.Ivory;
            this.txtBuscarProducto.Location = new System.Drawing.Point(27, 80);
            this.txtBuscarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarProducto.Multiline = true;
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(423, 24);
            this.txtBuscarProducto.TabIndex = 9;
            this.txtBuscarProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.label1.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "🛒 Terminal Punto de Venta";
            // 
            // gp3
            // 
            this.gp3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp3.BackColor = System.Drawing.Color.White;
            this.gp3.Controls.Add(this.dtVentasRecientes);
            this.gp3.Controls.Add(this.label2);
            this.gp3.Location = new System.Drawing.Point(549, 22);
            this.gp3.Name = "gp3";
            this.gp3.Size = new System.Drawing.Size(258, 321);
            this.gp3.TabIndex = 1;
            this.gp3.TabStop = false;
            // 
            // dtVentasRecientes
            // 
            this.dtVentasRecientes.AllowUserToDeleteRows = false;
            this.dtVentasRecientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVentasRecientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtVentasRecientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVentasRecientes.Location = new System.Drawing.Point(20, 80);
            this.dtVentasRecientes.Margin = new System.Windows.Forms.Padding(2);
            this.dtVentasRecientes.Name = "dtVentasRecientes";
            this.dtVentasRecientes.ReadOnly = true;
            this.dtVentasRecientes.RowHeadersWidth = 51;
            this.dtVentasRecientes.RowTemplate.Height = 24;
            this.dtVentasRecientes.Size = new System.Drawing.Size(209, 195);
            this.dtVentasRecientes.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "🧾 Ventas Recientes";
            // 
            // TerminalPV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(819, 373);
            this.Controls.Add(this.gp3);
            this.Controls.Add(this.gp2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TerminalPV";
            this.Text = "TerminalPV";
            this.Load += new System.EventHandler(this.TerminalPV_Load);
            this.gp2.ResumeLayout(false);
            this.gp2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtTerminalPunto)).EndInit();
            this.gp3.ResumeLayout(false);
            this.gp3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtVentasRecientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp2;
        private System.Windows.Forms.GroupBox gp3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Button btnFinTransaccion;
        private System.Windows.Forms.DataGridView dtTerminalPunto;
        private System.Windows.Forms.DataGridView dtVentasRecientes;
    }
}