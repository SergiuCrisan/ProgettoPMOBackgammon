using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon
{
    class ListaInt
    {
        private List<int> Lista;
        public List<int> LeggiLista
        {
            get
            {
                return this.Lista;
            }
        }
        public void CreaLista(int dimensioni)
        {
            Lista = new List<int>(new int[dimensioni]);
        }
        public void ModificaElementoLista(int nuovo, int posizione)
        {
            Lista[posizione] = nuovo;
        }
    }
}
