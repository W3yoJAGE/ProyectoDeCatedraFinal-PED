using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PantallasPrograma;
using ProyectoCatedraPED_SistemaInventario.Modelo;

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class ModificarProducto : Form
    {
        // Variable para almacenar el ID del producto que vamos a editar
        private int idProductoSeleccionado;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Modificamos el constructor para que RECIBA el ID del producto
        public ModificarProducto(int idProducto)
        {
            InitializeComponent();
            this.idProductoSeleccionado = idProducto;

            RedondeadoDeFormularioYBotones.RedondeoForm(this);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnGuardarProducto);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnPreview);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnVolver);

            // Primero cargamos las categorías en el ComboBox
            CargarCategorias();

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
            // Luego cargamos los datos del producto seleccionado
            CargarDatosProducto();
        }

        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private void CargarCategorias()
        {
            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var categories = db.Categorias.ToList();
                cbCategoria.DataSource = categories;
                cbCategoria.DisplayMember = "Nombre";
                cbCategoria.ValueMember = "ID_Categoria";
                cbCategoria.SelectedIndex = 0;
            }
        }

        // Nuevo método para buscar el producto y rellenar los inputs
        private void CargarDatosProducto()
        {
            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var producto = db.Productos.Find(idProductoSeleccionado);

                if (producto != null)
                {
                    txtCodigo.Text = producto.Codigo;
                    txtCodigo.Enabled = false; // Deshabilitamos para que no se altere el código único
                    txtCodigo.ForeColor = Color.Black;

                    txtNombre.Text = producto.Nombre;
                    txtNombre.ForeColor = Color.Black;

                    cbCategoria.SelectedValue = producto.ID_Categoria;

                    txtPrecio.Text = producto.Precio.ToString();
                    txtPrecio.ForeColor = Color.Black;

                    txtCantidad.Text = producto.Stock.ToString();
                    txtCantidad.ForeColor = Color.Black;

                    txtURLImagen.Text = producto.RutaImagen;
                    txtURLImagen.ForeColor = Color.Black;

                    cmbEstado.SelectedItem =
                    producto.Activo ? "Activo" : "Inactivo";

                    // Si ya cuenta con una URL de imagen, intentamos cargar el Preview automáticamente
                    if (!string.IsNullOrWhiteSpace(producto.RutaImagen) && producto.RutaImagen != "https://...")
                    {
                        CargarImagenDesdeUrl(producto.RutaImagen);
                    }

                    cmbEstado.SelectedItem =
                         producto.Activo ? "Activo" : "Inactivo";
                }
                else
                {
                    MessageBox.Show("El producto seleccionado no pudo ser encontrado.");
                    this.Close();
                }
            }
        }

        // Modificamos el método para que edite en lugar de agregar (No usa .Add)
        private void GuardarProducto()
        {
            if (!ValidarCampos()) return;

            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                // Buscamos el registro original por su ID
                var producto = db.Productos.Find(idProductoSeleccionado);

                if (producto != null)
                {
                    // Asignamos los nuevos valores ingresados en el formulario
                    producto.Nombre = txtNombre.Text.Trim();
                    producto.ID_Categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                    producto.Precio = Convert.ToDecimal(txtPrecio.Text);
                    producto.Stock = Convert.ToInt32(txtCantidad.Text);
                    producto.RutaImagen = txtURLImagen.Text.Trim();
                    // Mantenemos el estado activo
                    producto.Activo =
                        cmbEstado.SelectedItem.ToString() == "Activo";

                    // Guardamos los cambios (Entity Framework detecta automáticamente la edición)
                    db.SaveChanges();

                    MessageBox.Show("Producto modificado correctamente.");
                    this.Close(); // Cerramos la ventana de edición al finalizar exitosamente
                }
                else
                {
                    MessageBox.Show("Error al intentar actualizar: El producto ya no existe.");
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Nombre" ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) || txtPrecio.Text == "Precio" ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) || txtCantidad.Text == "Cantidad")
            {
                MessageBox.Show("Complete todos los campos requeridos.");
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

            // Validaciones para el campo Url Imagen
            if (!Validaciones.NoVacio(txtURLImagen, "URL Imagen"))// Verifica que no esté vacío
                return false;

            if (!Validaciones.UrlValida(txtURLImagen, "URL Imagen"))// Verifica que sea una URL válida
                return false;

            return true;
        }

        // Método auxiliar reutilizable para procesar la imagen de internet
        private void CargarImagenDesdeUrl(string url)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "GET";

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pbPreview.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar imagen de vista previa: " + ex.Message);
            }
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
            string url = txtURLImagen.Text.Trim();
            if (!string.IsNullOrWhiteSpace(url) && url != "https://...")
            {
                CargarImagenDesdeUrl(url);
            }
        }

        private void BarraSuperiorAzul_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }
    }
}