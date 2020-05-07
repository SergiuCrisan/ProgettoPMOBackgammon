using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Backgammon
{
    class Controllo
    {
        public ListaPB Pedine = new ListaPB();                              // lista PictureBox delle pedine
        public ListaPB Dadi = new ListaPB();                                // lista PictureBox dei dadi
        public ListaLbl IndiciPedine = new ListaLbl();                      // lista di label che indicano il numero di pedine in più oltre le 5 visibili
        public ListaInt PedineInPiù = new ListaInt();                       // numero pedine in più oltre le 5 visibili
        // ATTRIBUTI
        private readonly Random rnd = new Random();                         // variabile che serve ad assegnare un valore randomico ai dadi
        private int pedineBianche;                                          // numero pedine rimaste giocatore bianco
        private int pedineNere;                                             // numero pedine rimaste giocatore nero
        //PROPRIETA'
        public int PedineBianche
        {
            get
            {
                return this.pedineBianche;
            }
            set
            {
                this.pedineBianche = value;
            }
        }
        public int PedineNere
        {
            get
            {

                return this.pedineNere;
            }
            set
            {

                this.pedineNere = value;
            }
        }
        // Singleton
        private static Controllo instance = null;
        // METODI
        private Controllo() { }
        public static Controllo Instance()
        {
            if (instance == null)
            {
                instance = new Controllo();
            }

            return instance;
        }
        // fine singleton
        // metodi gestione gioco
        public string ChiHaVinto()                                          // controlla se qualcuno ha vinto e restituisce il colore del vincitore
        {
            string risposta = null;
            if (PedineBianche == 0)
            {
                risposta = "Bianco";
            }
            else if (PedineNere == 0)
            {
                risposta = "Nero";
            }
            return risposta;
        }
        // metodi gestione turni 
        public void InvertiTurno()                                          // cambia il giocatore che deve giocare
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            if (bianco.MioTurno)
            {
                bianco.MioTurno = false;
            }
            else
            {
                bianco.MioTurno = true;
            }
            if (nero.MioTurno)
            {
                nero.MioTurno = false;
            }
            else
            {
                nero.MioTurno = true;
            }
        }
        public Giocatore MostraTurno()                                      // ritorna il giocatore che deve giocare
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            Giocatore turno = null;
            if (bianco.MioTurno)
            {
                turno = bianco;
            }
            else if (nero.MioTurno)
            {
                turno = nero;
            }
            return turno;
        }
        // fine metodi gestione turni
        // metodi gestione pedine
        public void ContaPedine()                                           // conta quante pedine hanno ancora i giocatori
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            int i;
            PedineBianche = 0;
            PedineNere = 0;
            for (i = 0; i < 122; i++)
            {
                if (Equals(ColorePedina(i), bianco.Colore))
                {
                    PedineBianche++;
                    if (i % 5 == 4)
                    {
                        PedineBianche += PedineInPiù.LeggiLista[TrovaIdTriangolo(i)];
                    }
                    if (i == 121)
                    {
                        PedineBianche += PedineInPiù.LeggiLista[i] - 1;
                    }
                }
                if (Equals(ColorePedina(i), nero.Colore))
                {
                    PedineNere++;
                    if (i % 5 == 4 && i != 120)
                    {
                        PedineNere += PedineInPiù.LeggiLista[TrovaIdTriangolo(i)];
                    }
                    else if (i == 120)
                    {
                        PedineNere += PedineInPiù.LeggiLista[i] - 1;
                    }
                }
            }
        }
        public int ContaPedineSuTriangolo(int idPedina)                     // restituisce il numero di pedine su un triangolo (Max 5)
        {
            int i;
            int contatore = 0;
            for (i = TrovaIdTriangolo(idPedina); i < TrovaIdTriangolo(idPedina) + 5; i++)
            {
                if (!Equals(ColorePedina(i), "Libero"))
                {
                    contatore++;
                }
            }
            return contatore;
        }
        private int TrovaIdPedina(PictureBox pedina)                         // restituisce l'id della pedina
        {
            int i;
            int id = -1;
            for (i = 0; i < Pedine.LeggiLista.Count; i++)
            {
                if (Equals(pedina.Name, Pedine.LeggiLista[i].Name))
                {
                    id = i;
                }
            }
            return id;
            //int i;
            //int id = -1;
            //for (i = 0; i < 122; i++)
            //{
            //    if ((Pedine[i].Left <= pedina.Left) && (Pedine[i].Top <= pedina.Top) && (Pedine[i].Bottom >= pedina.Bottom) && (Pedine[i].Right >= pedina.Right))
            //    {
            //        id = i;
            //    }
            //}
            //return id;
        }
        public int TrovaIdTriangolo(int idPedina)                           // restituisce l'id del triangolo
        {
            int id = -1;
            if (idPedina % 5 == 0)
            {
                id = idPedina;
            }
            else if (idPedina % 5 < 5 && idPedina % 5 > 0)
            {
                id = idPedina - (idPedina % 5);
            }
            return id;
        }
        public string ColoreTriangolo(int idPedina)                         // restituisce il colore del triangolo
        {
            return Pedine.LeggiLista[TrovaIdTriangolo(idPedina)].Tag.ToString();
        }
        public string ColorePedina(int idPedina)                            // restituisce il colore della pedina
        {
            return Pedine.LeggiLista[idPedina].Tag.ToString();
        }
        public bool TriangoloLibero(int idPedina)                           // ritorna se il triangolo è libero oppure no
        {
            bool risposta;
            if (Equals(ColoreTriangolo(idPedina), "Libero"))
            {
                risposta = true;
            }
            else
            {
                risposta = false;
            }
            return risposta;
        }
        public void CambiaColorePedina(int idPedina, string colore)         // modifica il colore di una pedina
        {
            if (Equals(colore, "Libero"))
            {
                Pedine.LeggiLista[idPedina].Image = null;
                Pedine.LeggiLista[idPedina].Tag = "Libero";
            }
            else
            {
                Pedine.LeggiLista[idPedina].Tag = colore;
                if (Equals(colore, "Bianco"))
                {
                    Pedine.LeggiLista[idPedina].Image = Properties.Resources.pedinaBianco;
                }
                else if (Equals(colore, "Nero"))
                {
                    Pedine.LeggiLista[idPedina].Image = Properties.Resources.pedinaNero;
                }
            }
        }
        public void AggiornaIndiciPedine()                                  // aggiorna l'indice delle pedine in più oltre le 5
        {
            int i;
            for (i = 0; i < 120; i += 5)
            {
                if (PedineInPiù.LeggiLista[i] > 0)
                {
                    IndiciPedine.LeggiLista[i].Text = PedineInPiù.LeggiLista[i].ToString();
                }
                else
                {
                    IndiciPedine.LeggiLista[i].Text = "";
                }
            }
            for (i = 120; i < 122; i++)
            {
                if (PedineInPiù.LeggiLista[i] > 1)
                {
                    IndiciPedine.LeggiLista[i].Text = (PedineInPiù.LeggiLista[i] - 1).ToString();
                }
                else
                {
                    IndiciPedine.LeggiLista[i].Text = "";
                }
            }
        }
        public void TogliUtlimaPedinaTriangolo(int idPedina)                // togli l'utlima pedina dal triangolo
        {
            if (ContaPedineSuTriangolo(idPedina) < 5)                                                               // se ho meno di 5 pezzi
            {
                CambiaColorePedina(TrovaIdTriangolo(idPedina) + ContaPedineSuTriangolo(idPedina) - 1, "Libero");
            }
            else if (ContaPedineSuTriangolo(idPedina) == 5 && PedineInPiù.LeggiLista[TrovaIdTriangolo(idPedina)] == 0)   // se ho 5 pezzi
            {
                CambiaColorePedina(TrovaIdTriangolo(idPedina) + 4, "Libero");
            }
            else if (ContaPedineSuTriangolo(idPedina) == 5 && PedineInPiù.LeggiLista[TrovaIdTriangolo(idPedina)] > 0)    // se ho più di 5 pezzi
            {
                PedineInPiù.ModificaElementoLista(PedineInPiù.LeggiLista[TrovaIdTriangolo(idPedina)] - 1,TrovaIdTriangolo(idPedina));
                AggiornaIndiciPedine();
            }
        }
        public void AggiungiPedinaSuTriangolo(int idPedina, string colore)  // aggiunge pedina del colore specificato in cima al triangolo
        {
            if (ContaPedineSuTriangolo(idPedina) < 5)                                                         // se ho meno di 5 pezzi
            {
                CambiaColorePedina(TrovaIdTriangolo(idPedina) + ContaPedineSuTriangolo(idPedina), colore);
            }
            else if (ContaPedineSuTriangolo(idPedina) == 5 && PedineInPiù.LeggiLista[TrovaIdTriangolo(idPedina)] >= 0)   // se ho 5 pezzi
            {
                PedineInPiù.ModificaElementoLista(PedineInPiù.LeggiLista[TrovaIdTriangolo(idPedina)] + 1, TrovaIdTriangolo(idPedina));
                AggiornaIndiciPedine();
            }
        }
        // fine metodi gesione pedine
        // metodi gestione dadi
        public Dado DadoScelto()                                            // restituisce il dado scelto dal giocatore
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            Dado scelto = null;
            if (dado1.SonoScelto && dado1.Valore > 0)
            {
                scelto = dado1;
            }
            else if (dado2.SonoScelto && dado2.Valore > 0)
            {
                scelto = dado2;
            }
            return scelto;
        }
        public void AggiornaDadi()                                          // aggiorna immagini dadi
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            switch (dado1.Valore)
            {
                case 1:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado1;
                    Dadi.LeggiLista[0].Tag = "1";
                    break;

                case 2:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado2;
                    Dadi.LeggiLista[0].Tag = "2";
                    break;

                case 3:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado3;
                    Dadi.LeggiLista[0].Tag = "3";
                    break;

                case 4:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado4;
                    Dadi.LeggiLista[0].Tag = "4";
                    break;

                case 5:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado5;
                    Dadi.LeggiLista[0].Tag = "5";
                    break;

                case 6:
                    Dadi.LeggiLista[0].Image = Properties.Resources.dado6;
                    Dadi.LeggiLista[0].Tag = "6";
                    break;
                case 0:
                    Dadi.LeggiLista[0].Image = null;
                    break;
            }
            switch (dado2.Valore)
            {
                case 1:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado1;
                    Dadi.LeggiLista[1].Tag = "1";
                    break;

                case 2:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado2;
                    Dadi.LeggiLista[1].Tag = "2";
                    break;

                case 3:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado3;
                    Dadi.LeggiLista[1].Tag = "3";
                    break;

                case 4:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado4;
                    Dadi.LeggiLista[1].Tag = "4";
                    break;

                case 5:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado5;
                    Dadi.LeggiLista[1].Tag = "5";
                    break;

                case 6:
                    Dadi.LeggiLista[1].Image = Properties.Resources.dado6;
                    Dadi.LeggiLista[1].Tag = "6";
                    break;
                case 0:
                    Dadi.LeggiLista[1].Image = null;
                    break;
            }

        }
        private bool Doppio()                                                // controlla se è uscito doppio
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            bool risposta;
            if (dado1.Valore == dado2.Valore)
            {
                risposta = true;
            }
            else
            {
                risposta = false;
            }
            return risposta;
        }
        public void ImpostaUtilizziDadi()                                   // imposta l'utilizzo dei dadi appena tirati
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            if (Doppio())
            {
                dado1.Utilizzi = 2;
                dado2.Utilizzi = 2;
            }
            else
            {
                dado1.Utilizzi = 1;
                dado2.Utilizzi = 1;
            }
        }
        public void AzzeraUtilizziDadi()                                    // azzera utilizzi dadi
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            dado1.AzzeraUtilizzi();
            dado2.AzzeraUtilizzi();
        }
        public void AzzeraValoreDadi()                                      // azzera il valore dei dadi
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            dado1.AzzeraValore();
            dado2.AzzeraValore();
        }
        public void LanciaDadi()                                            // cambia valore dadi
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            dado1.Valore = rnd.Next(1, 7);
            dado2.Valore = rnd.Next(1, 7);
        }
        public bool UtilizziRimasti()                                       // ritorna true se sono ancora rimasti degli utilizzi
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            bool risposta;
            if (dado1.Utilizzi == 0 && dado2.Utilizzi == 0)
            {
                risposta = false;
            }
            else
            {
                risposta = true;
            }
            return risposta;
        }
        // fine metodi gestione dadi
        // fine metodi gestione gioco
        // metodi per il movimento
        public string MuoviPedina(object pedina, object giocatore)          // fa muovere le pedine ai giocatori e restituisce l'esito
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            string messaggio = "OK";
            if (Equals(giocatore, bianco))
            {
                if (TrovaIdPedina((PictureBox)pedina) < 120 && Equals(ColorePedina(TrovaIdPedina((PictureBox)pedina)), bianco.Colore))    // se la pedina è in campo
                {
                    if (bianco.PossoMuovereGenerale(this))                                          // se posso muovere
                    {
                        if (bianco.PossoMuovereQuesto(this, TrovaIdPedina((PictureBox)pedina)))
                        {
                            bianco.MuoviPedina(this, TrovaIdPedina((PictureBox)pedina));        // muovo
                        }
                        else
                        {
                            messaggio = "Mossa non possibile";
                        }
                    }
                    else                                                                    // se non posso muovere
                    {
                        messaggio = "Non ci sono\nmosse disponibili";                       // messaggio errore
                    }
                }
                else
                {
                    messaggio = "Non puoi muovere\nquella pedina";
                }
            }
            else if (Equals(giocatore, nero))
            {
                if (TrovaIdPedina((PictureBox)pedina) < 120 && Equals(ColorePedina(TrovaIdPedina((PictureBox)pedina)), nero.Colore))    // se la pedina è in campo
                {
                    if (nero.PossoMuovereGenerale(this))                                            // se posso muovere
                    {
                        if (nero.PossoMuovereQuesto(this, TrovaIdPedina((PictureBox)pedina)))
                        {
                            nero.MuoviPedina(this, TrovaIdPedina((PictureBox)pedina));        // muovo
                        }
                        else
                        {
                            messaggio = "Mossa non possibile";
                        }
                    }
                    else                                                                    // se non posso muovere
                    {
                        messaggio = "Non ci sono\nmosse disponibili";                       // messaggio errore
                    }
                }
                else
                {
                    messaggio = "Non puoi muovere\nquella pedina";
                }
            }
            return messaggio;
        }
        public string RimettiPedina(object pedina, object giocatore)        // fa rimettere le pedine mangiate ai giocatori e restituisce l'esito
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            string messaggio = "OK";
            if (Equals(giocatore, bianco))
            {
                if (TrovaIdPedina((PictureBox)pedina) > 120)
                {
                    if (bianco.PossoRimettereGenerale(this))
                    {
                        if (bianco.PossoRimettereQui(this))
                        {
                            bianco.RimettiPedina(this, TrovaIdPedina((PictureBox)pedina));
                        }
                        else
                        {
                            messaggio = "Mossa non possibile";
                            if (DadoScelto() == dado1 && dado2.Valore == 0)
                            {
                                messaggio = "Non ci sono\nmosse disponibili";
                            }
                            else if (DadoScelto() == dado2 && dado1.Valore == 0)
                            {
                                messaggio = "Non ci sono\nmosse disponibili";
                            }
                        }
                    }
                    else
                    {
                        messaggio = "Non ci sono\nmosse disponibili";
                    }
                }
                else
                {
                    messaggio = "Devi reinserire\nle pedine";
                }
            }
            if (Equals(giocatore, nero))
            {
                if (TrovaIdPedina((PictureBox)pedina) == 120)
                {

                    if (nero.PossoRimettereGenerale(this))
                    {
                        if (nero.PossoRimettereQui(this))
                        {
                            nero.RimettiPedina(this, TrovaIdPedina((PictureBox)pedina));
                        }
                        else
                        {
                            messaggio = "Mossa non possibile";
                            if (DadoScelto() == dado1 && dado2.Valore == 0)
                            {
                                messaggio = "Non ci sono\nmosse disponibili";
                            }
                            else if (DadoScelto() == dado2 && dado1.Valore == 0)
                            {
                                messaggio = "Non ci sono\nmosse disponibili";
                            }
                        }
                    }
                    else
                    {
                        messaggio = "Non ci sono\nmosse disponibili";
                    }
                }
                else
                {
                    messaggio = "Devi reinserire\nle pedine";
                }
            }

            return messaggio;
        }
        public string TogliPedina(object giocatore)                         // fa togliere le pedine ai giocatori a fine partita e restituisce l'esito
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            string messaggio = "OK";
            if (Equals(giocatore, bianco))
            {
                messaggio = bianco.TogliPedina(this);
            }
            else if (Equals(giocatore, nero))
            {
                messaggio = nero.TogliPedina(this);
            }
            return messaggio;
        }
        public string QualeMovimento(Giocatore giocatore)                   // restituisce il movimento che bisogna fare
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            string movimento;
            if (Equals(giocatore, bianco))
            {
                if (bianco.PedineMangiate)            // se ho pedine fuori
                {
                    movimento = "Rimetti";
                }
                else if (bianco.PossoTogliere(this) && (dado1.Valore != 0 || dado2.Valore != 0)) // se posso togliere
                {
                    movimento = "Scelta";
                }
                else                                    // non posso togliere quindi muovo
                {
                    movimento = "Muovi";
                }
            }
            else if (Equals(giocatore, nero))
            {
                if (nero.PedineMangiate)            // se ho pedine fuori
                {
                    movimento = "Rimetti";
                }
                else if (nero.PossoTogliere(this)) // se posso togliere
                {
                    movimento = "Scelta";
                }
                else                                    // non posso togliere quindi muovo
                {
                    movimento = "Muovi";
                }
            }
            else
            {
                movimento = "Errore";
            }

            return movimento;
        }
        // fine metodi per il movimento
    }
}
