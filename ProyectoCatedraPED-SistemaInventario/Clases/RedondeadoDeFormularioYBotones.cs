using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PantallasPrograma
{
    public static class RedondeadoDeFormularioYBotones
    {
        public static void RedondeoForm(Form f1 )
        {

            if (f1.WindowState == FormWindowState.Maximized)
            {
                f1.Region = null;
                return;
            }

            int radio = 30; // radio del borde
            GraphicsPath path = new GraphicsPath();

            // Crea un rectángulo con esquinas redondeadas
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddLine(radio, 0, f1.Width - radio, 0);
            path.AddArc(new Rectangle(f1.Width - radio, 0, radio, radio), -90, 90);
            path.AddLine(f1.Width, radio, f1.Width, f1.Height - radio);
            path.AddArc(new Rectangle(f1.Width - radio, f1.Height - radio, radio, radio), 0, 90);
            path.AddLine(f1.Width - radio, f1.Height, radio, f1.Height);
            path.AddArc(new Rectangle(0, f1.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();
           
            // Aplica la región redondeada al formulario
            f1.Region = new Region(path);
            f1.Invalidate();
           
           


        }

        public static void RedondeoBtn(Control b1)
        {

            int radio = 30; // radio del borde
            GraphicsPath path = new GraphicsPath();

            // Crea un rectángulo con esquinas redondeadas
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            path.AddLine(radio, 0, b1.Width - radio, 0);
            path.AddArc(new Rectangle(b1.Width - radio, 0, radio, radio), -90, 90);
            path.AddLine(b1.Width, radio, b1.Width, b1.Height - radio);
            path.AddArc(new Rectangle(b1.Width - radio, b1.Height - radio, radio, radio), 0, 90);
            path.AddLine(b1.Width - radio, b1.Height, radio, b1.Height);
            path.AddArc(new Rectangle(0, b1.Height - radio, radio, radio), 90, 90);
            path.CloseFigure();

            // Aplica la región redondeada al botonsito
            b1.Region = new Region(path);
            b1.Invalidate();




        }

        public static void RedondeadoGroupBox(GroupBox gb)
        {
            int radio = 40; // radio del borde
            gb.Paint += (sender, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Medir altura del texto
                SizeF textSize = e.Graphics.MeasureString(gb.Text, gb.Font);

                // Ajustar el rectángulo para quitar más región en la parte superior
                int espacioSuperior = 40; // más espacio que antes
                Rectangle rect = new Rectangle(
                    0,
                    espacioSuperior / 2,
                    gb.Width - 1,
                    gb.Height - espacioSuperior / 1
                );

                // Crear camino redondeado
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                path.CloseFigure();

                // Asignar región redondeada
                gb.Region = new Region(path);

                // Dibujar borde con color Ivory
                using (Pen pen = new Pen(Color.FromArgb(208, 205, 201), 2)) // usando ya el azul bonito para los bordes 
                {
                    e.Graphics.DrawPath(pen, path);
                }

                // Dibujar el texto en la parte superior
                e.Graphics.DrawString(gb.Text, gb.Font, new SolidBrush(gb.ForeColor), 10, 0);
            };

            gb.Invalidate(); // Forzar redibujo

        }

        public static void FormatearDataGridView(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 230, 242);

            // HEADER
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 42;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(43, 108, 176); // azul botones
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(43, 108, 176);

            // FILAS
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(244, 248, 252); // azul clarito alterno

            dgv.RowsDefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgv.RowsDefaultCellStyle.Font = new Font("Inter", 9, FontStyle.Regular);
            dgv.RowsDefaultCellStyle.Padding = new Padding(5);

            // CELDAS
            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(66, 153, 225); // azul selección

            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Altura filas
            dgv.RowTemplate.Height = 36;

            // Quitar bordes feos extra
            dgv.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            dgv.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single;
        }

    }
}
