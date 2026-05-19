namespace ProyectoCatedraPED_SistemaInventario
{
    partial class PantallaDashBoard
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btn_VistaCliente = new System.Windows.Forms.Button();
            this.btn_Inventario = new System.Windows.Forms.Button();
            this.btn_Terminal = new System.Windows.Forms.Button();
            this.btn_Ofertas = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Salir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BarraSuperiorAzul = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gb1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraSuperiorAzul)).BeginInit();
            this.SuspendLayout();
            // 
            // gb1
            // 
            this.gb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb1.BackColor = System.Drawing.Color.White;
            this.gb1.Controls.Add(this.btn_VistaCliente);
            this.gb1.Controls.Add(this.btn_Inventario);
            this.gb1.Controls.Add(this.btn_Terminal);
            this.gb1.Controls.Add(this.btn_Ofertas);
            this.gb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb1.Location = new System.Drawing.Point(30, 73);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(835, 87);
            this.gb1.TabIndex = 1;
            this.gb1.TabStop = false;
            // 
            // btn_VistaCliente
            // 
            this.btn_VistaCliente.BackColor = System.Drawing.Color.White;
            this.btn_VistaCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_VistaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_VistaCliente.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_VistaCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btn_VistaCliente.Location = new System.Drawing.Point(468, 32);
            this.btn_VistaCliente.Name = "btn_VistaCliente";
            this.btn_VistaCliente.Size = new System.Drawing.Size(148, 27);
            this.btn_VistaCliente.TabIndex = 5;
            this.btn_VistaCliente.Text = "🏪 Vista del Cliente";
            this.btn_VistaCliente.UseVisualStyleBackColor = false;
            this.btn_VistaCliente.Click += new System.EventHandler(this.btn_VistaCliente_Click);
            // 
            // btn_Inventario
            // 
            this.btn_Inventario.BackColor = System.Drawing.Color.White;
            this.btn_Inventario.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Inventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Inventario.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Inventario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btn_Inventario.Location = new System.Drawing.Point(21, 32);
            this.btn_Inventario.Name = "btn_Inventario";
            this.btn_Inventario.Size = new System.Drawing.Size(113, 27);
            this.btn_Inventario.TabIndex = 2;
            this.btn_Inventario.Text = "📦 Inventario";
            this.btn_Inventario.UseVisualStyleBackColor = false;
            this.btn_Inventario.Click += new System.EventHandler(this.btn_Inventario_Click);
            // 
            // btn_Terminal
            // 
            this.btn_Terminal.BackColor = System.Drawing.Color.White;
            this.btn_Terminal.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Terminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Terminal.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Terminal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btn_Terminal.Location = new System.Drawing.Point(141, 32);
            this.btn_Terminal.Name = "btn_Terminal";
            this.btn_Terminal.Size = new System.Drawing.Size(202, 27);
            this.btn_Terminal.TabIndex = 3;
            this.btn_Terminal.Text = "🛍️ Terminal Punto de Venta";
            this.btn_Terminal.UseVisualStyleBackColor = false;
            this.btn_Terminal.Click += new System.EventHandler(this.btn_Terminal_Click);
            // 
            // btn_Ofertas
            // 
            this.btn_Ofertas.BackColor = System.Drawing.Color.White;
            this.btn_Ofertas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ofertas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ofertas.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ofertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(26)))), ((int)(((byte)(38)))));
            this.btn_Ofertas.Location = new System.Drawing.Point(348, 32);
            this.btn_Ofertas.Name = "btn_Ofertas";
            this.btn_Ofertas.Size = new System.Drawing.Size(113, 27);
            this.btn_Ofertas.TabIndex = 4;
            this.btn_Ofertas.Text = "🏷️ Ofertas";
            this.btn_Ofertas.UseVisualStyleBackColor = false;
            this.btn_Ofertas.Click += new System.EventHandler(this.btn_Ofertas_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(23, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 354);
            this.panel1.TabIndex = 2;
            // 
            // Salir
            // 
            this.Salir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Salir.Location = new System.Drawing.Point(847, 12);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(32, 23);
            this.Salir.TabIndex = 3;
            this.Salir.Text = "X";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.label1.Font = new System.Drawing.Font("Inter", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.label1.Location = new System.Drawing.Point(85, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sistema de Inventario ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.label2.Font = new System.Drawing.Font("Inter", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.label2.Location = new System.Drawing.Point(88, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sistema de Inventario ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProyectoCatedraPED_SistemaInventario.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 42);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // BarraSuperiorAzul
            // 
            this.BarraSuperiorAzul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.BarraSuperiorAzul.Dock = System.Windows.Forms.DockStyle.Top;
            this.BarraSuperiorAzul.Location = new System.Drawing.Point(0, 0);
            this.BarraSuperiorAzul.Name = "BarraSuperiorAzul";
            this.BarraSuperiorAzul.Size = new System.Drawing.Size(891, 66);
            this.BarraSuperiorAzul.TabIndex = 0;
            this.BarraSuperiorAzul.TabStop = false;
            this.BarraSuperiorAzul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BarraSuperiorAzul_MouseDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(804, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "⏹️";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PantallaDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(245)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(891, 529);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.BarraSuperiorAzul);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PantallaDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.PantallaDashBoard_Resize);
            this.gb1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarraSuperiorAzul)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BarraSuperiorAzul;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btn_VistaCliente;
        private System.Windows.Forms.Button btn_Inventario;
        private System.Windows.Forms.Button btn_Terminal;
        private System.Windows.Forms.Button btn_Ofertas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

