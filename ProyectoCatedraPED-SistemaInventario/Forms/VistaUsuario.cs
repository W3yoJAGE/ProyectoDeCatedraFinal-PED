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
using ProyectoCatedraPED_SistemaInventario.Modelo;

namespace ProyectoCatedraPED_SistemaInventario
{
    public partial class VistaUsuario : Form
    {
        public VistaUsuario()
        {
            InitializeComponent();
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(groupBox1);
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(groupBox2);
            RedondeadoDeFormularioYBotones.RedondeoBtn(btnEliminar);

        }
        List<Producto> productos = new List<Producto>();

        private void CargarCatalogo()
        {
            flowLayoutPanel1.Controls.Clear();

            using (SistemaInventarioPedEntities db =
                   new SistemaInventarioPedEntities())
            {
                // IDs activos
                var productosActivos = db.Productos
                    .Where(p => p.Activo == true)
                    .Select(p => p.ID_Producto)
                    .ToList();

                // catálogo sin duplicados:
                // si un producto tiene varias ofertas,
                // toma la de mayor prioridad
                var productos = db.vw_CatalogoProductos
                    .Where(p => productosActivos.Contains(p.ID_Producto))
                    .ToList()
                    .GroupBy(p => p.ID_Producto)
                    .Select(g => g.OrderByDescending(x => x.Prioridad).First())
                    .ToList();

                // MAX HEAP
                MaxHeapOfertas heap = new MaxHeapOfertas();

                foreach (var p in productos)
                {
                    heap.Insertar(new OfertaHeap
                    {
                        ID_Oferta = p.ID_Producto,
                        Producto = p.Nombre,
                        PorcentajeDescuento =
                            p.PorcentajeDescuento ?? 0,
                        Descripcion =
                            p.OfertaDescripcion,
                        Prioridad =
                            p.Prioridad ?? 0,
                        Activa = true
                    });
                }

                // extraer ordenados y renderizar
                while (heap.Cantidad > 0)
                {
                    var item = heap.ExtraerMaximo();

                    var producto = productos.FirstOrDefault(
                        p => p.ID_Producto == item.ID_Oferta);

                    if (producto != null)
                    {
                        CartaDeProducto card =
                            new CartaDeProducto();

                        card.CargarProducto(
                            producto.Categoria,
                            producto.Nombre,
                            producto.PrecioOriginal,
                            producto.PrecioFinal ??
                                producto.PrecioOriginal,
                            producto.PorcentajeDescuento ?? 0,
                            producto.OfertaDescripcion,
                            producto.RutaImagen
                        );

                        flowLayoutPanel1.Controls.Add(card);
                    }
                }
            }
        }
        private void BuscarProductos(string texto)
        {
            flowLayoutPanel1.Controls.Clear();

            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var productosActivos = db.Productos
                    .Where(p => p.Activo == true
                             && (p.Nombre.Contains(texto) ||
                                 p.Codigo.Contains(texto)))
                    .Select(p => p.ID_Producto)
                    .ToList();

                var lista = db.vw_CatalogoProductos
                    .Where(v => productosActivos.Contains(v.ID_Producto))
                    .ToList();

                foreach (var p in lista)
                {
                    CartaDeProducto card = new CartaDeProducto();

                    card.CargarProducto(
                        p.Categoria,
                        p.Nombre,
                        p.PrecioOriginal,
                        p.PrecioFinal ?? p.PrecioOriginal,
                        p.PorcentajeDescuento ?? 0,
                        p.OfertaDescripcion,
                        p.RutaImagen
                    );

                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }
        private void CargarCategorias()
        {
            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var categorias = db.Categorias
                    .Select(c => new
                    {
                        c.ID_Categoria,
                        c.Nombre
                    })
                    .ToList();

                categorias.Insert(0, new
                {
                    ID_Categoria = 0,
                    Nombre = "Todas"
                });

                cbCategorias.DataSource = categorias;
                cbCategorias.DisplayMember = "Nombre";
                cbCategorias.ValueMember = "ID_Categoria";
            }
        }
        private void MostrarProductos()
        {
            flowLayoutPanel1.Controls.Clear();

            CargarCatalogo();
        }

        private void FiltrarPorCategoria()
        {
            flowLayoutPanel1.Controls.Clear();

            string categoriaSeleccionada = cbCategorias.Text;

            using (SistemaInventarioPedEntities db =
                   new SistemaInventarioPedEntities())
            {
                var queryProductos = db.Productos
                    .Where(p => p.Activo == true);

                if (categoriaSeleccionada != "Todas")
                {
                    queryProductos = queryProductos
                        .Where(p => p.Categorias.Nombre == categoriaSeleccionada);
                }

                var idsValidos = queryProductos
                    .Select(p => p.ID_Producto)
                    .ToList();

                var lista = db.vw_CatalogoProductos
                    .Where(v => idsValidos.Contains(v.ID_Producto))
                    .ToList()
                    .GroupBy(v => v.ID_Producto)
                    .Select(g => g.OrderByDescending(x => x.Prioridad).First())
                    .ToList();

                foreach (var p in lista)
                {
                    CartaDeProducto card = new CartaDeProducto();

                    card.CargarProducto(
                        p.Categoria,
                        p.Nombre,
                        p.PrecioOriginal,
                        p.PrecioFinal ?? p.PrecioOriginal,
                        p.PorcentajeDescuento ?? 0,
                        p.OfertaDescripcion,
                        p.RutaImagen
                    );

                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }

        private void VistaUsuario_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarCatalogo();

            MostrarProductos();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
    
            BuscarProductos(txtBuscarProducto.Text.Trim());
        }

        private void cbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPorCategoria();
        }
    }
}
