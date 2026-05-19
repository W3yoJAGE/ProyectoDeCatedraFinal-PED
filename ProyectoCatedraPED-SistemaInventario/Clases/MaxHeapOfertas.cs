using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCatedraPED_SistemaInventario
{
    public class MaxHeapOfertas
    {
        private List<OfertaHeap> monticulo = new List<OfertaHeap>();

        public int Cantidad
        {
            get { return monticulo.Count; }
        }

        // INSERTAR
        public void Insertar(OfertaHeap oferta)
        {
            monticulo.Add(oferta);
            ReordenarHaciaArriba(monticulo.Count - 1);
        }

        // EXTRAER MÁXIMO
        public OfertaHeap ExtraerMaximo()
        {
            if (monticulo.Count == 0) return null;

            OfertaHeap maximo = monticulo[0];
            monticulo[0] = monticulo[monticulo.Count - 1];
            monticulo.RemoveAt(monticulo.Count - 1);

            ReordenarHaciaAbajo(0);

            return maximo;
        }

        // SUBIR ELEMENTO
        private void ReordenarHaciaArriba(int indice)
        {
            while (indice > 0)
            {
                int padre = (indice - 1) / 2;

                if (monticulo[indice].Prioridad <=
                    monticulo[padre].Prioridad)
                    break;

                Intercambiar(indice, padre);
                indice = padre;
            }
        }

        // BAJAR ELEMENTO
        private void ReordenarHaciaAbajo(int indice)
        {
            while (true)
            {
                int izquierda = 2 * indice + 1;
                int derecha = 2 * indice + 2;
                int mayor = indice;

                if (izquierda < monticulo.Count &&
                    monticulo[izquierda].Prioridad >
                    monticulo[mayor].Prioridad)
                {
                    mayor = izquierda;
                }

                if (derecha < monticulo.Count &&
                    monticulo[derecha].Prioridad >
                    monticulo[mayor].Prioridad)
                {
                    mayor = derecha;
                }

                if (mayor == indice)
                    break;

                Intercambiar(indice, mayor);
                indice = mayor;
            }
        }

        // INTERCAMBIO
        private void Intercambiar(int a, int b)
        {
            OfertaHeap temporal = monticulo[a];
            monticulo[a] = monticulo[b];
            monticulo[b] = temporal;
        }
    }
}
