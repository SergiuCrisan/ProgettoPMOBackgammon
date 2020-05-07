using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    class ListaLbl
    {
        private List<Label> Lista;
        public List<Label> LeggiLista
        {
            get
            {
                return this.Lista;
            }
        }
        public void CreaLista(int dimensioni)
        {
            Lista = new List<Label>(new Label[dimensioni]);
        }
        public void ModificaElementoLista(Label nuovo, int posizione)
        {
            Lista[posizione] = nuovo;
        }
    }
}
