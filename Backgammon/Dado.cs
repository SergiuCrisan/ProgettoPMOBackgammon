using System.Collections.Generic;

namespace Backgammon
{
    public sealed class Dado
    {
        // ATTRIBUTI
        private int valore;                      // valore del dado
        private int utilizzi = 0;                // utilizzi rimasti del dado
        private bool sonoScelto;                 // serve alla gestione della scelta del dado
        // PROPRIETA'
        public int Valore
        {
            get
            {
                return this.valore;
            }
            set
            {
                this.valore = value;
            }
        }
        public int Utilizzi
        {
            get
            {
                return this.utilizzi;
            }
            set
            {
                utilizzi = value;
            }
        }
        public bool SonoScelto
        {
            get
            {
                return sonoScelto;
            }
            set
            {
                this.sonoScelto = value;
            }
        }
        //Multiton
        static Dictionary<string, Dado> dado = new Dictionary<string, Dado>();
        static object _lock = new object();
        private Dado()
        {

        }
        public static Dado Instance(string nome)
        {
            lock (_lock)
            {
                if(!dado.ContainsKey(nome))
                {
                    dado.Add(nome, new Dado());
                }
            }
            return dado[nome];
        }
        // METODI
        public void DecrementaUtilizziDado()    // decrementa di 1 gli utilizzi del dado
        {
            Utilizzi--;
        }
        public void AzzeraUtilizzi()            // azzera gli utilizzi del dado
        {
            this.utilizzi = 0;
        }
        public void AzzeraValore()              // azzera il valore del dado
        {
            if (utilizzi == 0)
            {
                valore = 0;
            }
        }
    }
}
