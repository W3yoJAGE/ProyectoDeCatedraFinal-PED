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
    public partial class TerminalPV : Form
    {
        public TerminalPV()
        {
            InitializeComponent();
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(gp2);
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(gp3);

        }

        List<dynamic> carrito = new List<dynamic>();
        private void BuscarProductosPOS(string texto)
        {
            using (SistemaInventarioPedEntities db =
                new SistemaInventarioPedEntities())
            {
                var productos = (
                    from p in db.Productos
                    join v in db.vw_CatalogoProductos
                        on p.ID_Producto equals v.ID_Producto
                    where p.Activo == true
                    && (p.Nombre.Contains(texto) ||
                        p.Codigo.Contains(texto))
                    select new
                    {
                        v.ID_Producto,
                        v.Codigo,
                        v.Nombre,
                        Precio = v.PrecioFinal ?? v.PrecioOriginal,
                        v.Stock
                    }
                ).ToList();

                dtTerminalPunto.DataSource = productos;
            }
        }

        private void AgregarProductoCarrito(int idProducto)
        {
            using (SistemaInventarioPedEntities db =
        new SistemaInventarioPedEntities())
            {
                var producto = db.vw_CatalogoProductos
                    .FirstOrDefault(p => p.ID_Producto == idProducto);

                if (producto == null) return;

                decimal precioVenta = producto.PrecioFinal ?? producto.PrecioOriginal;

                carrito.Add(new
                {
                    producto.ID_Producto,
                    producto.Nombre,
                    Precio = precioVenta,
                    Cantidad = 1,
                    Subtotal = precioVenta
                });

                dtTerminalPunto.DataSource = null;
                dtTerminalPunto.DataSource = carrito;
            }
        }

        private void CargarVentasRecientes()
        {
            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var ventas = db.Ventas
                    .OrderByDescending(v => v.FechaHora)
                    .Take(10)
                    .Select(v => new
                    {
                        v.ID_Venta,
                        v.FechaHora,
                        v.Total
                    })
                    .ToList();

                dtVentasRecientes.DataSource = ventas;
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarProductosPOS(txtBuscarProducto.Text.Trim());
        }

        private void dtTerminalPunto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(
                    dtTerminalPunto.Rows[e.RowIndex]
                    .Cells["ID_Producto"].Value
                );

                AgregarProductoCarrito(id);
            }
        }

        private void TerminalPV_Load(object sender, EventArgs e)
        {
            RedondeadoDeFormularioYBotones.FormatearDataGridView(dtTerminalPunto);
            RedondeadoDeFormularioYBotones.FormatearDataGridView(dtVentasRecientes);

            CargarVentasRecientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e) //btn finalizar transaccion, lo cree con otro nombre
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("No hay productos.");
                return;
            }

            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                decimal total = carrito.Sum(x => (decimal)x.Subtotal);

                Ventas venta = new Ventas
                {
                    FechaHora = DateTime.Now,
                    Total = total
                };

                db.Ventas.Add(venta);
                db.SaveChanges();

                foreach (var item in carrito)
                {
                    DetalleVentas detalle = new DetalleVentas
                    {
                        ID_Venta = venta.ID_Venta,
                        ID_Producto = item.ID_Producto,
                        Cantidad = item.Cantidad,
                        PrecioUnitarioVenta = item.Precio
                    };

                    db.DetalleVentas.Add(detalle);
                }

                db.SaveChanges();
            }

            carrito.Clear();
            dtTerminalPunto.DataSource = null;

            CargarVentasRecientes();

            MessageBox.Show("Venta registrada.");
        }
    }
}
