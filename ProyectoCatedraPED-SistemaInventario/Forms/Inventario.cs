using PantallasPrograma;
using ProyectoCatedraPED_SistemaInventario.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnAgregarProducto);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnEliminar);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnBusquedaBinaria);

            RedondeadoDeFormularioYBotones.RedondeoBtn(btnModificar);

            RedondeadoDeFormularioYBotones.FormatearDataGridView(dtTabla);
            CargarProductos();
        }
        private ProductoBusqueda BusquedaBinaria(List<ProductoBusqueda> lista, string textoBuscado)
        {
            int izquierda = 0;
            int derecha = lista.Count - 1;

            textoBuscado = textoBuscado.ToLower();

            while (izquierda <= derecha)
            {
                int medio = (izquierda + derecha) / 2;

                string valorActual =
                    lista[medio].Nombre.ToLower();

                int comparacion =
                    string.Compare(valorActual,
                                   textoBuscado);

                if (comparacion == 0)
                {
                    return lista[medio];
                }

                if (comparacion < 0)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }

            return null;
        }
        private void CargarProductos()
        {
            using (SistemaInventarioPedEntities db =
             new SistemaInventarioPedEntities())
            {
                var lista = db.Productos
                    .Select(p => new ProductoBusqueda
                    {
                        ID_Producto = p.ID_Producto,
                        Codigo = p.Codigo,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Estado = p.Activo
                            ? "Activo"
                            : "Inactivo"
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                dtTabla.DataSource = lista;
            }
        }

        private void BuscarProductos(string texto)
        {
            using (SistemaInventarioPedEntities db =
              new SistemaInventarioPedEntities())
            {
                var lista = db.Productos
                    .Select(p => new ProductoBusqueda
                    {
                        ID_Producto = p.ID_Producto,
                        Codigo = p.Codigo,
                        Nombre = p.Nombre,
                        Precio = p.Precio,
                        Stock = p.Stock,
                        Estado = p.Activo
                            ? "Activo"
                            : "Inactivo"
                    })
                    .OrderBy(p => p.Nombre)
                    .ToList();

                ProductoBusqueda encontrado =
                    BusquedaBinaria(lista, texto);

                if (encontrado != null)
                {
                    dtTabla.DataSource =
                        new List<ProductoBusqueda>
                        {
                    encontrado
                        };
                }
                else
                {
                    dtTabla.DataSource = null;
                    MessageBox.Show(
                        "Producto no encontrado.");
                }
            }
        }

        private int ObtenerIdSeleccionado()
        {
            if (dtTabla.CurrentRow != null)
            {
                return Convert.ToInt32(
                    dtTabla.CurrentRow.Cells["ID_Producto"].Value
                );
            }

            return 0;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ObtenerIdSeleccionado();

            if (id == 0) return;

            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var producto = db.Productos.Find(id);

                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();
                }
            }

            CargarProductos();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
           
        }

        private void txtBuscarProducto_TextChanged_1(object sender, EventArgs e)
        {
            CargarProductos();

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dtTabla.CurrentRow == null)
            {
                MessageBox.Show("Seleccione producto.");
                return;
            }

            int idProducto = Convert.ToInt32(
                dtTabla.CurrentRow.Cells["ID_Producto"].Value
            );

            using (SistemaInventarioPedEntities db =
                   new SistemaInventarioPedEntities())
            {
                var producto = db.Productos.Find(idProducto);

                if (producto == null) return;

                producto.Activo = false;

                db.SaveChanges();
            }

            MessageBox.Show("Producto desactivado.");
            CargarProductos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            int idProducto = Convert.ToInt32(
             dtTabla.CurrentRow.Cells["ID_Producto"].Value);
            ModificarProducto frm = new ModificarProducto(idProducto);
            frm.ShowDialog();
        }

        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            AgregarProducto frm = new AgregarProducto();
            frm.ShowDialog();
            
        }

        private void btnBusquedaBinaria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarProducto.Text))
            {
                CargarProductos();
                return;
            }

            BuscarProductos(txtBuscarProducto.Text.Trim());
        }
    }
}
