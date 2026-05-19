namespace ProyectoCatedraPED_SistemaInventario
{
    partial class OfertasPantalla
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
            this.gp3 = new System.Windows.Forms.GroupBox();
            this.dtJerarquiaOfertas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.gp2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescripcionPromocion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCodigoProducto = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.txtPorcentajeDescuento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gp3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtJerarquiaOfertas)).BeginInit();
            this.gp2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp3
            // 
            this.gp3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gp3.BackColor = System.Drawing.Color.White;
            this.gp3.Controls.Add(this.dtJerarquiaOfertas);
            this.gp3.Controls.Add(this.label2);
            this.gp3.Location = new System.Drawing.Point(336, 7);
            this.gp3.Name = "gp3";
            this.gp3.Size = new System.Drawing.Size(463, 321);
            this.gp3.TabIndex = 3;
            this.gp3.TabStop = false;
            // 
            // dtJerarquiaOfertas
            // 
            this.dtJerarquiaOfertas.AllowUserToDeleteRows = false;
            this.dtJerarquiaOfertas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtJerarquiaOfertas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtJerarquiaOfertas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtJerarquiaOfertas.Location = new System.Drawing.Point(20, 80);
            this.dtJerarquiaOfertas.Margin = new System.Windows.Forms.Padding(2);
            this.dtJerarquiaOfertas.Name = "dtJerarquiaOfertas";
            this.dtJerarquiaOfertas.ReadOnly = true;
            this.dtJerarquiaOfertas.RowHeadersWidth = 51;
            this.dtJerarquiaOfertas.RowTemplate.Height = 24;
            this.dtJerarquiaOfertas.Size = new System.Drawing.Size(411, 195);
            this.dtJerarquiaOfertas.TabIndex = 10;
            this.dtJerarquiaOfertas.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtJerarquiaOfertas_CellValueChanged);
            this.dtJerarquiaOfertas.CurrentCellDirtyStateChanged += new System.EventHandler(this.dtJerarquiaOfertas_CurrentCellDirtyStateChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(422, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "📊 Jerarquía de Ofertas (Prioridad MaxHeap)";
            // 
            // gp2
            // 
            this.gp2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gp2.BackColor = System.Drawing.Color.White;
            this.gp2.Controls.Add(this.label5);
            this.gp2.Controls.Add(this.txtDescripcionPromocion);
            this.gp2.Controls.Add(this.label4);
            this.gp2.Controls.Add(this.cbCodigoProducto);
            this.gp2.Controls.Add(this.label3);
            this.gp2.Controls.Add(this.btnFinalizar);
            this.gp2.Controls.Add(this.txtPorcentajeDescuento);
            this.gp2.Controls.Add(this.label1);
            this.gp2.Location = new System.Drawing.Point(4, 7);
            this.gp2.Margin = new System.Windows.Forms.Padding(1);
            this.gp2.Name = "gp2";
            this.gp2.Size = new System.Drawing.Size(310, 321);
            this.gp2.TabIndex = 2;
            this.gp2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label5.Location = new System.Drawing.Point(29, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Descripcion de la Promocion";
            // 
            // txtDescripcionPromocion
            // 
            this.txtDescripcionPromocion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtDescripcionPromocion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcionPromocion.ForeColor = System.Drawing.Color.Ivory;
            this.txtDescripcionPromocion.Location = new System.Drawing.Point(32, 209);
            this.txtDescripcionPromocion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcionPromocion.Multiline = true;
            this.txtDescripcionPromocion.Name = "txtDescripcionPromocion";
            this.txtDescripcionPromocion.Size = new System.Drawing.Size(251, 25);
            this.txtDescripcionPromocion.TabIndex = 18;
            this.txtDescripcionPromocion.Text = "   Venta de Verano, Outlet, etc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label4.Location = new System.Drawing.Point(29, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Porcentaje de Descuento (%)";
            // 
            // cbCodigoProducto
            // 
            this.cbCodigoProducto.FormattingEnabled = true;
            this.cbCodigoProducto.Location = new System.Drawing.Point(32, 94);
            this.cbCodigoProducto.Name = "cbCodigoProducto";
            this.cbCodigoProducto.Size = new System.Drawing.Size(251, 21);
            this.cbCodigoProducto.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Inter", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label3.Location = new System.Drawing.Point(29, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Código del Producto";
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.btnFinalizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(32, 255);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(251, 37);
            this.btnFinalizar.TabIndex = 14;
            this.btnFinalizar.Text = "Finalizar Transacción ➡️";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // txtPorcentajeDescuento
            // 
            this.txtPorcentajeDescuento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.txtPorcentajeDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPorcentajeDescuento.ForeColor = System.Drawing.Color.Ivory;
            this.txtPorcentajeDescuento.Location = new System.Drawing.Point(32, 150);
            this.txtPorcentajeDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtPorcentajeDescuento.Multiline = true;
            this.txtPorcentajeDescuento.Name = "txtPorcentajeDescuento";
            this.txtPorcentajeDescuento.Size = new System.Drawing.Size(251, 25);
            this.txtPorcentajeDescuento.TabIndex = 9;
            this.txtPorcentajeDescuento.Text = "    0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "🏷️ Crear Oferta";
            // 
            // OfertasPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(803, 334);
            this.Controls.Add(this.gp3);
            this.Controls.Add(this.gp2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OfertasPantalla";
            this.Text = "Ofertas";
            this.Load += new System.EventHandler(this.Ofertas_Load);
            this.gp3.ResumeLayout(false);
            this.gp3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtJerarquiaOfertas)).EndInit();
            this.gp2.ResumeLayout(false);
            this.gp2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gp3;
        private System.Windows.Forms.DataGridView dtJerarquiaOfertas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gp2;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.TextBox txtPorcentajeDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCodigoProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescripcionPromocion;
        private System.Windows.Forms.Label label4;
    }
}