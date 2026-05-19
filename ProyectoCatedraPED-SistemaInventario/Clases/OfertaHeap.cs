using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCatedraPED_SistemaInventario
{
    public class OfertaHeap
    {
        public int ID_Oferta { get; set; }
        public string Producto { get; set; }
        public int PorcentajeDescuento { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public bool Activa { get; set; }
    }
}
