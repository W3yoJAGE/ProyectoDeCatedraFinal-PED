using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PantallasPrograma;
using System.Runtime.InteropServices; //Para simular el drag de la pantalla

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class PantallaDashBoard : Form
    {
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam
        ); //así si vamos a poder agarrar la pantalla
        public PantallaDashBoard()
        {
            InitializeComponent();
            RedondeadoDeFormularioYBotones.RedondeoBtn(btn_Inventario);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btn_Ofertas);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btn_Terminal);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btn_VistaCliente);
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(gb1);
            RedondeadoDeFormularioYBotones.RedondeoForm(this);

        }
        Control botonActivo = null;
        private Form formularioActivo = null;
        private void abrirFormulario(Form formularioAbrir)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioAbrir;

            formularioAbrir.TopLevel = false;
            formularioAbrir.FormBorderStyle = FormBorderStyle.None;
            formularioAbrir.Dock = DockStyle.Fill;
            formularioAbrir.Size = panel1.ClientSize;

            panel1.Controls.Clear();
            panel1.Controls.Add(formularioAbrir);
            panel1.Tag = formularioAbrir;

            formularioAbrir.BringToFront();
            formularioAbrir.Show();

        }
        private void MouseAcciones(Control btn, int opcion)
        {
            if (opcion == 1) // CLICK
            {
                if (botonActivo != null) //si se vuelve a activar otro boton, boton activo ya habra almacenado al boton anterior y le regresará su formato
                {
                    
                    botonActivo.BackColor = Color.White; //pasar el hexadecimal a argb tambien es forma de denotar un color
                    botonActivo.ForeColor = Color.FromArgb(13, 26, 38);
                }

                // Activar el nuevo
                botonActivo = btn; //Durante el click, boton activo tendra la accion del boton que estamos presionando para ejecutar los cambios
                btn.BackColor = Color.FromArgb(41, 102, 163);
                btn.ForeColor = Color.White;
            }
            else if (opcion == 2 && btn != botonActivo) // Para la accion hover (mouse por encima) , botonActivo sirve para que no se active al momento de presionar el boton
            {
                btn.ForeColor = ColorTranslator.FromHtml("#808000");
            }
            else if (opcion == 3 && btn != botonActivo) // para la accion leave (se va el mouse de encima) 
            {
                btn.ForeColor = ColorTranslator.FromHtml("#E97451");
            }
        } //Funcion pra el control visual de los botones


        private void Salir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_Inventario_Click(object sender, EventArgs e)
        {
            abrirFormulario(new Inventario());
            MouseAcciones(btn_Inventario, 1);

        }

        private void btn_Terminal_Click(object sender, EventArgs e)
        {
            abrirFormulario(new TerminalPV());
            MouseAcciones(btn_Terminal, 1);
        }

        private void btn_Ofertas_Click(object sender, EventArgs e)
        {
            abrirFormulario(new OfertasPantalla());
            MouseAcciones(btn_Ofertas, 1);
        }

        private void btn_VistaCliente_Click(object sender, EventArgs e)
        {
            abrirFormulario(new VistaUsuario());
            MouseAcciones(btn_VistaCliente, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

            RedondeadoDeFormularioYBotones.RedondeoForm(this);
        }

        private void PantallaDashBoard_Resize(object sender, EventArgs e)
        {
            RedondeadoDeFormularioYBotones.RedondeoForm(this);
            if (formularioActivo != null)
            {
                formularioActivo.Size = panel1.ClientSize;
            }
        }

        private void BarraSuperiorAzul_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
