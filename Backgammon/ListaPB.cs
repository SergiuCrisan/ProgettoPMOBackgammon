using System.Collections.Generic;
using System.Windows.Forms;

namespace Backgammon
{
    class ListaPB
    {
        private List<PictureBox> Lista;
        public List<PictureBox> LeggiLista
        {
            get
            {
                return this.Lista;
            }
        }
        public void CreaLista(int dimensioni)
        {
            Lista = new List<PictureBox>(new PictureBox[dimensioni]);
        }
        public void ModificaElementoLista(PictureBox nuovo, int posizione)
        {
            Lista[posizione] = nuovo;
        }
    }
}
