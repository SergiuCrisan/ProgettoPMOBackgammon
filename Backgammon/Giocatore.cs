namespace Backgammon
{
    abstract class Giocatore
    {
        // ATTRIBUTI
        protected string colore;
        protected bool mioTurno;
        protected bool pedineMangiate = false;
        // PROPRIETA'
        public string Colore
        {
            get
            {
                return this.colore;
            }
            set
            {
                this.colore = value;
            }
        }
        public bool MioTurno
        {
            get
            {
                return this.mioTurno;
            }
            set
            {
                this.mioTurno = value;
            }
        }
        public bool PedineMangiate
        {
            get
            {
                return this.pedineMangiate;
            }
            set
            {
                this.pedineMangiate = value;
            }
        }
        // METODI
        public abstract void MuoviPedina(Controllo controllo, int idPedina);            // muove le pedine sul tabellone
        public abstract void RimettiPedina(Controllo controllo, int idPedina);          // rimette le pedine mangiate in gioco
        public abstract string TogliPedina(Controllo controllo);                        // toglie le pedine dal tabellone nella fase finale del gioco
        public abstract void MangiaPedina(Controllo controllo, int idPedina);           // mangia la pedina dell'avversario
        public abstract bool PossoMangiare(Controllo controllo, int idPedina);          // controlla se si può mangiare una pedina
        public abstract bool PossoRimettereGenerale(Controllo controllo);               // controlla se ho spazio per rimettere le pedine
        public abstract bool PossoRimettereQui(Controllo controllo);                    // controlla se lo spazio scelto in base al dado è libero per poter rimettere
        public abstract bool PossoTogliere(Controllo controllo);                        // controlla se tutte le pedine sono nella propria base così da poter toglierle
        public abstract bool PossoMuovereGenerale(Controllo controllo);                 // controlla se ho movimenti disponibili sul tabellone
        public abstract bool PossoMuovereQuesto(Controllo controllo, int idPedina);     // controlla che la mossa effettuata sia valida
        public abstract void AggiungiPedinaInOut(Controllo controllo);                  // aggiunge pedina del giocatore in out quando viene mangiata
        public abstract void TogliPedinaDaOut(Controllo controllo);                     // toglie pedina del giocatore da out quando viene rimessa in gioco
        protected abstract int PrimoTriangoloOccupatoBase(Controllo controllo);         // restituisce l'id del triangolo occupato dal giocaotre più esterno della propria base
    }
}
