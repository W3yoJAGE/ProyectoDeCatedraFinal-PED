using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCatedraPED_SistemaInventario
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal PrecioAnterior { get; set; }
        public int Descuento { get; set; }
        public string Descripcion { get; set; }
        public string RutaImagen { get; set; }
        public bool UltimasUnidades { get; set; }

    }
}
