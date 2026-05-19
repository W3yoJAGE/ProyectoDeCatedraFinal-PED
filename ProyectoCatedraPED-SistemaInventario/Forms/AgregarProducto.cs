using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PantallasPrograma;
using ProyectoCatedraPED_SistemaInventario.Modelo;

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class AgregarProducto : Form
    {

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam);
        
        public AgregarProducto()
        {
            InitializeComponent();
            RedondeadoDeFormularioYBotones.RedondeoForm(this);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnGuardarProducto);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnPreview);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnVolver);
            LimpiarCampos();
            CargarCategorias();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
           
        }
        private void CargarCategorias()
        {
            using (SistemaInventarioPedEntities db =
             new SistemaInventarioPedEntities())
            {
                var categorias = db.Categorias.ToList();

                cbCategoria.DataSource = categorias;
                cbCategoria.DisplayMember = "Nombre";
                cbCategoria.ValueMember = "ID_Categoria";
                cbCategoria.SelectedIndex = 0;
            }
        }
        private void GenerarCodigoProducto()
        {
            using (SistemaInventarioPedEntities db =
                   new SistemaInventarioPedEntities())
            {
                var ultimoProducto = db.Productos
                    .OrderByDescending(p => p.ID_Producto)
                    .FirstOrDefault();

                int nuevoNumero = 1;

                if (ultimoProducto != null)
                {
                    nuevoNumero = ultimoProducto.ID_Producto+1;
                }

                txtCodigo.Text = "PRD-" + nuevoNumero.ToString("D3");
                txtCodigo.ForeColor = Color.Black;
              //  MessageBox.Show("si"+ nuevoNumero);
            }
        }
      
        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
          
        }

        private void GuardarProducto()
        {
            if (!ValidarCampos()) return;

            using (SistemaInventarioPedEntities db =
                   new SistemaInventarioPedEntities())
            {
                Productos producto = new Productos();

                producto.Codigo = txtCodigo.Text.Trim();
                producto.Nombre = txtNombre.Text.Trim();
                producto.ID_Categoria =
                    Convert.ToInt32(cbCategoria.SelectedValue);
                producto.Precio =
                    Convert.ToDecimal(txtPrecio.Text);
                producto.Stock =
                    Convert.ToInt32(txtCantidad.Text);
                producto.RutaImagen = txtURLImagen.Text.Trim();
                producto.Activo = true;

                db.Productos.Add(producto);
                db.SaveChanges();
            }

            MessageBox.Show("Producto agregado correctamente.");

            LimpiarCampos();
        }

        private bool ValidarCampos()
        {
            if (txtCodigo.Text == "Código" ||
                txtNombre.Text == "Nombre" ||
                txtPrecio.Text == "Precio" ||
                txtCantidad.Text == "Cantidad")
            {
                MessageBox.Show("Complete todos los campos.");
                return false;
            }

            decimal precio;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio inválido.");
                return false;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("Cantidad inválida.");
                return false;
            }


            // Validaciones para el campo Nombre
            if (!Validaciones.NoVacio(txtNombre, "Nombre")) // Verifica que no esté vacío
                return false;

            if (!Validaciones.SoloLetras(txtNombre, "Nombre")) // Verifica que solo contenga letras
                return false;
            // Validaciones para el campo Precio
            if (!Validaciones.NoVacio(txtPrecio, "Precio"))// Verifica que no esté vacío
                return false;

            if (!Validaciones.SoloNumeros(txtPrecio, "Precio"))// Verifica que solo contenga números
                return false;

            // Validaciones para el campo Url Imagen
            if (!Validaciones.NoVacio(txtURLImagen, "URL Imagen"))// Verifica que no esté vacío
                return false;

            if (!Validaciones.UrlValida(txtURLImagen, "URL Imagen"))// Verifica que sea una URL válida
                return false;

            return true;
        }
        private void LimpiarCampos()
        {
            

            txtNombre.Text = "Nombre";
            txtNombre.ForeColor = Color.Gray;

            txtPrecio.Text = "Precio";
            txtPrecio.ForeColor = Color.Gray;

            txtCantidad.Text = "Cantidad";
            txtCantidad.ForeColor = Color.Gray;

            txtURLImagen.Text = "https://...";
            txtURLImagen.ForeColor = Color.Gray;

            pbPreview.Image = null;

            GenerarCodigoProducto();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            GuardarProducto();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string url = txtURLImagen.Text.Trim();

            //    MessageBox.Show("[" + url + "]");

                System.Net.ServicePointManager.SecurityProtocol =
                    System.Net.SecurityProtocolType.Tls12;

                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);

                request.Method = "GET";

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pbPreview.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen: " + ex.Message);
               

            }
        }

        private void BarraSuperiorAzul_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
