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
    public partial class OfertasPantalla : Form
    {
        public OfertasPantalla()
        {
            InitializeComponent();
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(gp2);
            RedondeadoDeFormularioYBotones.RedondeadoGroupBox(gp3);
            RedondeadoDeFormularioYBotones.FormatearDataGridView(dtJerarquiaOfertas);



        }
        private void CargarProductosCombo()
        {
            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                var productos = db.Productos
                    .Where(p => p.Activo == true)
                    .Select(p => new
                    {
                        p.ID_Producto,
                        Display = p.Nombre + " (" + p.Codigo + ")"
                    })
                    .ToList();

                cbCodigoProducto.DataSource = productos;
                cbCodigoProducto.DisplayMember = "Display";
                cbCodigoProducto.ValueMember = "ID_Producto";
            }
        }
        private void CrearOferta()
        {
            if (cbCodigoProducto.SelectedValue == null)
            {
                MessageBox.Show("Seleccione producto.");
                return;
            }

            int idProducto = Convert.ToInt32(cbCodigoProducto.SelectedValue);

            int descuento;
            if (!int.TryParse(txtPorcentajeDescuento.Text, out descuento))
            {
                MessageBox.Show("Ingrese descuento válido.");
                return;
            }

            string descripcion = txtDescripcionPromocion.Text.Trim();

            using (SistemaInventarioPedEntities db = new SistemaInventarioPedEntities())
            {
                try
                {
                    Ofertas oferta = new Ofertas();

                    oferta.ID_Producto = idProducto;
                    oferta.PorcentajeDescuento = descuento;
                    oferta.Descripcion = descripcion;
                    oferta.Prioridad = descuento;

                    // CAMPO OBLIGATORIO
                    oferta.Activa = true;

                    db.Ofertas.Add(oferta);
                    db.SaveChanges(); // Aquí es donde SQL interviene si hay duplicado

                    MessageBox.Show("Oferta creada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarCampos();
                    CargarOfertas();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    // Captura la restricción de SQL
                    MessageBox.Show("Este producto ya tiene una oferta activa. Desactive la oferta actual antes de agregar una nueva.", "Oferta Duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    // Captura cualquier otro error para que el programa no se cierre
                    MessageBox.Show("Ocurrió un error al guardar la oferta: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CargarOfertas()
        {
            using (SistemaInventarioPedEntities db =
            new SistemaInventarioPedEntities())
            {
                var ofertasDB = db.Ofertas
                    .Where(o => o.Activa == true &&
                                o.Productos.Activo == true)
                    .Select(o => new OfertaHeap
                    {
                        ID_Oferta = o.ID_Oferta,
                        Producto = o.Productos.Nombre,
                        PorcentajeDescuento = o.PorcentajeDescuento,
                        Descripcion = o.Descripcion,
                        Prioridad = o.Prioridad,
                        Activa = o.Activa
                    })
                    .ToList();

                MaxHeapOfertas heap = new MaxHeapOfertas();

                // insertar al heap
                foreach (var oferta in ofertasDB)
                {
                    heap.Insertar(oferta);
                }

                // extraer ordenadas
                List<OfertaHeap> ordenadas =
                    new List<OfertaHeap>();

                while (heap.Cantidad > 0)
                {
                    ordenadas.Add(heap.ExtraerMaximo());
                }

                dtJerarquiaOfertas.DataSource = ordenadas;
                dtJerarquiaOfertas.ReadOnly = false;
                dtJerarquiaOfertas.Columns["Activa"].ReadOnly = false;
            }
        }
        private void LimpiarCampos()
        {
            txtPorcentajeDescuento.Clear();
            txtDescripcionPromocion.Clear();
            cbCodigoProducto.SelectedIndex = 0;
        }

        private void Ofertas_Load(object sender, EventArgs e)
        {
            CargarProductosCombo();
            CargarOfertas();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            CrearOferta();
        }

        private void dtJerarquiaOfertas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dtJerarquiaOfertas.IsCurrentCellDirty)
            {
                dtJerarquiaOfertas.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtJerarquiaOfertas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dtJerarquiaOfertas.Columns[e.ColumnIndex].Name
                == "Activa")
            {
                int idOferta = Convert.ToInt32(
                    dtJerarquiaOfertas.Rows[e.RowIndex]
                    .Cells["ID_Oferta"].Value);

                bool activa = Convert.ToBoolean(
                    dtJerarquiaOfertas.Rows[e.RowIndex]
                    .Cells["Activa"].Value);

                using (SistemaInventarioPedEntities db =
                       new SistemaInventarioPedEntities())
                {
                    var oferta = db.Ofertas
                        .FirstOrDefault(o =>
                            o.ID_Oferta == idOferta);

                    if (oferta != null)
                    {
                        oferta.Activa = activa;
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
