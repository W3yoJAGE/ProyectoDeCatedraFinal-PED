using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PantallasPrograma;

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class CartaDeProducto : UserControl
    {
        public CartaDeProducto()
        {
            InitializeComponent();
            
          
        }
        
        public void CargarProducto(
            string categoria,
            string nombre,
            decimal precioOriginal,
            decimal precioFinal,
            int descuento,
            string descripcionOferta,
            string rutaImagen
        )
        {
            lblCategoria.Text = categoria;
            lblProducto.Text = nombre;
            lblPrecioNuevo.Text = "$" + precioFinal.ToString("0.00");
            lblPrecioViejo.Text = "$" + precioOriginal.ToString("0.00");
            lblDescuento.Text = "-" + descuento + "%";
            lblDescripcion.Text = descripcionOferta;
            try
            {
                if (!string.IsNullOrWhiteSpace(rutaImagen))
                {
                    pictureBox1.Load(rutaImagen);
                }
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void CartaDeProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
