using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Backgammon
{
    public partial class Backgammon : Form
    {
        private bool dadiLanciati = false;
        public Backgammon()
        {
            InitializeComponent();
            InizializzaTavola();
        }
        // metodi da usare all'avvio
        private void ImpostaListaPedine()                                   // posiziona le PictureBox delle pedine in ordine nella lista
        {
            Controllo controllo = Controllo.Instance();
            controllo.Pedine.CreaLista(122);
            controllo.Pedine.ModificaElementoLista(picPezzo1, 0);
            controllo.Pedine.ModificaElementoLista(picPezzo2, 1);
            controllo.Pedine.ModificaElementoLista(picPezzo3, 2);
            controllo.Pedine.ModificaElementoLista(picPezzo4, 3);
            controllo.Pedine.ModificaElementoLista(picPezzo5, 4);
            controllo.Pedine.ModificaElementoLista(picPezzo6, 5);
            controllo.Pedine.ModificaElementoLista(picPezzo7, 6);
            controllo.Pedine.ModificaElementoLista(picPezzo8, 7);
            controllo.Pedine.ModificaElementoLista(picPezzo9, 8);
            controllo.Pedine.ModificaElementoLista(picPezzo10, 9);
            controllo.Pedine.ModificaElementoLista(picPezzo11, 10);
            controllo.Pedine.ModificaElementoLista(picPezzo12, 11);
            controllo.Pedine.ModificaElementoLista(picPezzo13, 12);
            controllo.Pedine.ModificaElementoLista(picPezzo14, 13);
            controllo.Pedine.ModificaElementoLista(picPezzo15, 14);
            controllo.Pedine.ModificaElementoLista(picPezzo16, 15);
            controllo.Pedine.ModificaElementoLista(picPezzo17, 16);
            controllo.Pedine.ModificaElementoLista(picPezzo18, 17);
            controllo.Pedine.ModificaElementoLista(picPezzo19, 18);
            controllo.Pedine.ModificaElementoLista(picPezzo20, 19);
            controllo.Pedine.ModificaElementoLista(picPezzo21, 20);
            controllo.Pedine.ModificaElementoLista(picPezzo22, 21);
            controllo.Pedine.ModificaElementoLista(picPezzo23, 22);
            controllo.Pedine.ModificaElementoLista(picPezzo24, 23);
            controllo.Pedine.ModificaElementoLista(picPezzo25, 24);
            controllo.Pedine.ModificaElementoLista(picPezzo26, 25);
            controllo.Pedine.ModificaElementoLista(picPezzo27, 26);
            controllo.Pedine.ModificaElementoLista(picPezzo28, 27);
            controllo.Pedine.ModificaElementoLista(picPezzo29, 28);
            controllo.Pedine.ModificaElementoLista(picPezzo30, 29);
            controllo.Pedine.ModificaElementoLista(picPezzo31, 30);
            controllo.Pedine.ModificaElementoLista(picPezzo32, 31);
            controllo.Pedine.ModificaElementoLista(picPezzo33, 32);
            controllo.Pedine.ModificaElementoLista(picPezzo34, 33);
            controllo.Pedine.ModificaElementoLista(picPezzo35, 34);
            controllo.Pedine.ModificaElementoLista(picPezzo36, 35);
            controllo.Pedine.ModificaElementoLista(picPezzo37, 36);
            controllo.Pedine.ModificaElementoLista(picPezzo38, 37);
            controllo.Pedine.ModificaElementoLista(picPezzo39, 38);
            controllo.Pedine.ModificaElementoLista(picPezzo40, 39);
            controllo.Pedine.ModificaElementoLista(picPezzo41, 40);
            controllo.Pedine.ModificaElementoLista(picPezzo42, 41);
            controllo.Pedine.ModificaElementoLista(picPezzo43, 42);
            controllo.Pedine.ModificaElementoLista(picPezzo44, 43);
            controllo.Pedine.ModificaElementoLista(picPezzo45, 44);
            controllo.Pedine.ModificaElementoLista(picPezzo46, 45);
            controllo.Pedine.ModificaElementoLista(picPezzo47, 46);
            controllo.Pedine.ModificaElementoLista(picPezzo48, 47);
            controllo.Pedine.ModificaElementoLista(picPezzo49, 48);
            controllo.Pedine.ModificaElementoLista(picPezzo50, 49);
            controllo.Pedine.ModificaElementoLista(picPezzo51, 50);
            controllo.Pedine.ModificaElementoLista(picPezzo52, 51);
            controllo.Pedine.ModificaElementoLista(picPezzo53, 52);
            controllo.Pedine.ModificaElementoLista(picPezzo54, 53);
            controllo.Pedine.ModificaElementoLista(picPezzo55, 54);
            controllo.Pedine.ModificaElementoLista(picPezzo56, 55);
            controllo.Pedine.ModificaElementoLista(picPezzo57, 56);
            controllo.Pedine.ModificaElementoLista(picPezzo58, 57);
            controllo.Pedine.ModificaElementoLista(picPezzo59, 58);
            controllo.Pedine.ModificaElementoLista(picPezzo60, 59);
            controllo.Pedine.ModificaElementoLista(picPezzo61, 60);
            controllo.Pedine.ModificaElementoLista(picPezzo62, 61);
            controllo.Pedine.ModificaElementoLista(picPezzo63, 62);
            controllo.Pedine.ModificaElementoLista(picPezzo64, 63);
            controllo.Pedine.ModificaElementoLista(picPezzo65, 64);
            controllo.Pedine.ModificaElementoLista(picPezzo66, 65);
            controllo.Pedine.ModificaElementoLista(picPezzo67, 66);
            controllo.Pedine.ModificaElementoLista(picPezzo68, 67);
            controllo.Pedine.ModificaElementoLista(picPezzo69, 68);
            controllo.Pedine.ModificaElementoLista(picPezzo70, 69);
            controllo.Pedine.ModificaElementoLista(picPezzo71, 70);
            controllo.Pedine.ModificaElementoLista(picPezzo72, 71);
            controllo.Pedine.ModificaElementoLista(picPezzo73, 72);
            controllo.Pedine.ModificaElementoLista(picPezzo74, 73);
            controllo.Pedine.ModificaElementoLista(picPezzo75, 74);
            controllo.Pedine.ModificaElementoLista(picPezzo76, 75);
            controllo.Pedine.ModificaElementoLista(picPezzo77, 76);
            controllo.Pedine.ModificaElementoLista(picPezzo78, 77);
            controllo.Pedine.ModificaElementoLista(picPezzo79, 78);
            controllo.Pedine.ModificaElementoLista(picPezzo80, 79);
            controllo.Pedine.ModificaElementoLista(picPezzo81, 80);
            controllo.Pedine.ModificaElementoLista(picPezzo82, 81);
            controllo.Pedine.ModificaElementoLista(picPezzo83, 82);
            controllo.Pedine.ModificaElementoLista(picPezzo84, 83);
            controllo.Pedine.ModificaElementoLista(picPezzo85, 84);
            controllo.Pedine.ModificaElementoLista(picPezzo86, 85);
            controllo.Pedine.ModificaElementoLista(picPezzo87, 86);
            controllo.Pedine.ModificaElementoLista(picPezzo88, 87);
            controllo.Pedine.ModificaElementoLista(picPezzo89, 88);
            controllo.Pedine.ModificaElementoLista(picPezzo90, 89);
            controllo.Pedine.ModificaElementoLista(picPezzo91, 90);
            controllo.Pedine.ModificaElementoLista(picPezzo92, 91);
            controllo.Pedine.ModificaElementoLista(picPezzo93, 92);
            controllo.Pedine.ModificaElementoLista(picPezzo94, 93);
            controllo.Pedine.ModificaElementoLista(picPezzo95, 94);
            controllo.Pedine.ModificaElementoLista(picPezzo96, 95);
            controllo.Pedine.ModificaElementoLista(picPezzo97, 96);
            controllo.Pedine.ModificaElementoLista(picPezzo98, 97);
            controllo.Pedine.ModificaElementoLista(picPezzo99, 98);
            controllo.Pedine.ModificaElementoLista(picPezzo100, 99);
            controllo.Pedine.ModificaElementoLista(picPezzo101, 100);
            controllo.Pedine.ModificaElementoLista(picPezzo102, 101);
            controllo.Pedine.ModificaElementoLista(picPezzo103, 102);
            controllo.Pedine.ModificaElementoLista(picPezzo104, 103);
            controllo.Pedine.ModificaElementoLista(picPezzo105, 104);
            controllo.Pedine.ModificaElementoLista(picPezzo106, 105);
            controllo.Pedine.ModificaElementoLista(picPezzo107, 106);
            controllo.Pedine.ModificaElementoLista(picPezzo108, 107);
            controllo.Pedine.ModificaElementoLista(picPezzo109, 108);
            controllo.Pedine.ModificaElementoLista(picPezzo110, 109);
            controllo.Pedine.ModificaElementoLista(picPezzo111, 110);
            controllo.Pedine.ModificaElementoLista(picPezzo112, 111);
            controllo.Pedine.ModificaElementoLista(picPezzo113, 112);
            controllo.Pedine.ModificaElementoLista(picPezzo114, 113);
            controllo.Pedine.ModificaElementoLista(picPezzo115, 114);
            controllo.Pedine.ModificaElementoLista(picPezzo116, 115);
            controllo.Pedine.ModificaElementoLista(picPezzo117, 116);
            controllo.Pedine.ModificaElementoLista(picPezzo118, 117);
            controllo.Pedine.ModificaElementoLista(picPezzo119, 118);
            controllo.Pedine.ModificaElementoLista(picPezzo120, 119);
            controllo.Pedine.ModificaElementoLista(picPezzoOutNero, 120);
            controllo.Pedine.ModificaElementoLista(picPezzoOutBianco, 121);
        }
        private void ImpostaCaratteristichePedine()                         // modifica alcune delle proprietà delle pedine
        {
            Controllo controllo = Controllo.Instance();
            for (int i = 0; i < controllo.Pedine.LeggiLista.Count; i++)
            {
                controllo.Pedine.LeggiLista[i].Parent = picBoard;
                controllo.Pedine.LeggiLista[i].BackColor = Color.Transparent;
                controllo.Pedine.LeggiLista[i].Click += new EventHandler(this.Movimento);
                controllo.Pedine.LeggiLista[i].Visible = true;
            }
        }
        private void ImpostaListaIndiciPedine()                             // posiziona le Label che mostrano se ci sono più di 5 pedine su un triangolo in ordine nella lista
        {
            Controllo controllo = Controllo.Instance();
            controllo.IndiciPedine.CreaLista(122);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi0, 0);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi1, 5);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi2, 10);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi3, 15);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi4, 20);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi5, 25);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi6, 30);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi7, 35);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi8, 40);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi9, 45);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi10, 50);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi11, 55);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi12, 60);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi13, 65);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi14, 70);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi15, 75);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi16, 80);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi17, 85);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi18, 90);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi19, 95);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi20, 100);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi21, 105);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi22, 110);
            controllo.IndiciPedine.ModificaElementoLista(lblMoltiPezzi23, 115);
            controllo.IndiciPedine.ModificaElementoLista(lblOutNero, 120);
            controllo.IndiciPedine.ModificaElementoLista(lblOutBianco, 121);
        }
        private void ImpostaCaratteristicheIndiciPedine()                   // imposta il testo die tutte le Label della lista = ""
        {
            Controllo controllo = Controllo.Instance();
            int i;
            for (i = 0; i < 116; i += 5)
            {
                controllo.IndiciPedine.LeggiLista[i].Text = "";
            }
            for (i = 120; i < 122; i++)
            {
                controllo.IndiciPedine.LeggiLista[i].Text = "";
            }
        }
        private void ImpostaListaPedineInPiù()                              // imposta la lista del contatore delle pedine in più
        {
            Controllo controllo = Controllo.Instance();
            controllo.PedineInPiù.CreaLista(122);
            int i;
            for (i = 0; i < 122; i++)
            {
                controllo.PedineInPiù.ModificaElementoLista( 0, i);
            }
        }
        private void ImpostaListaDadi()                                     // posiziona le PictureBox dei dadi nella lista
        {
            Controllo controllo = Controllo.Instance();
            controllo.Dadi.CreaLista(2);
            controllo.Dadi.ModificaElementoLista(picDado1, 0);
            controllo.Dadi.ModificaElementoLista(picDado2, 1);
        }
        private void ImpostaInizioGioco()                                   // mette le pedine nella posizione di inizio partita
        {
            Controllo controllo = Controllo.Instance();
            for (int i = 0; i < controllo.Pedine.LeggiLista.Count; i++)
            {
                if (i < 2)
                {
                    controllo.CambiaColorePedina(i, "Bianco");
                }
                else if (i > 24 && i < 30)
                {
                    controllo.CambiaColorePedina(i, "Nero");
                }
                else if (i > 34 && i < 38)
                {
                    controllo.CambiaColorePedina(i, "Nero");
                }
                else if (i > 54 && i < 60)
                {
                    controllo.CambiaColorePedina(i, "Bianco");
                }
                else if (i > 59 && i < 65)
                {
                    controllo.CambiaColorePedina(i, "Nero");
                }
                else if (i > 79 && i < 83)
                {
                    controllo.CambiaColorePedina(i, "Bianco");
                }
                else if (i > 89 && i < 95)
                {
                    controllo.CambiaColorePedina(i, "Bianco");
                }
                else if (i > 114 && i < 117)
                {
                    controllo.CambiaColorePedina(i, "Nero");
                }
                else if (i > 119)
                {
                    controllo.Pedine.LeggiLista[i].Parent = this;
                    controllo.CambiaColorePedina(i, "Libero");
                }
                else
                {
                    controllo.CambiaColorePedina(i, "Libero");
                }
            }

        }
        private void InizializzaTavola()                                    // ragruppa tutte le funzioni da fare all'avvio del gioco
        {
            Controllo controllo = Controllo.Instance();
            ImpostaListaPedine();
            ImpostaCaratteristichePedine();
            ImpostaListaIndiciPedine();
            ImpostaCaratteristicheIndiciPedine();
            ImpostaListaPedineInPiù();
            ImpostaListaDadi();
            ImpostaInizioGioco();
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            bianco.Colore = "Bianco";
            bianco.MioTurno = true;
            nero.Colore = "Nero";
            nero.MioTurno = false;
            controllo.ContaPedine();
        }
        // metodi funzionamento gioco
        private void ControllaVittoria()                                     // stampa in lblInfoBox il vincitore
        {
            Controllo controllo = Controllo.Instance();
            if (controllo.ChiHaVinto() != null)
            {
                lblInfoBox.Text = "Ha vinto\nGiocatore " + controllo.ChiHaVinto();
                btnLanciaDadi.Text = "Gioca Ancora";
            }
        }
        private void CambioTurno()                                           // cambia il turno
        {
            Controllo controllo = Controllo.Instance();
            dadiLanciati = false;
            controllo.AzzeraUtilizziDadi();
            controllo.AzzeraValoreDadi();
            controllo.InvertiTurno();
            controllo.ContaPedine();
            lblTurnoGiocatore.Text = "Turno di\n" + controllo.MostraTurno().Colore;
        }
        private void Movimento(object pedina, EventArgs e)                   // gestisce i movimenti delle pedine
        {
            Controllo controllo = Controllo.Instance();
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            string messaggio = "ERROR";
            if (controllo.DadoScelto() != null)
            {
                if (dadiLanciati)
                {
                    switch (controllo.QualeMovimento(controllo.MostraTurno()))
                    {
                        case "Muovi":
                            messaggio = controllo.MuoviPedina(pedina, controllo.MostraTurno());
                            break;
                        case "Rimetti":
                            messaggio = controllo.RimettiPedina(pedina, controllo.MostraTurno());
                            break;
                        case "Scelta":
                            if (dado1.Valore != 0 || dado2.Valore != 0)
                            {
                                using (Scelta scelta = new Scelta())
                                {
                                    if (scelta.ShowDialog() == DialogResult.OK)
                                    {
                                        messaggio = controllo.MuoviPedina(pedina, controllo.MostraTurno());
                                    }
                                    else if (scelta.ShowDialog() == DialogResult.Cancel)
                                    {
                                        messaggio = controllo.TogliPedina(controllo.MostraTurno());
                                    }
                                }
                            }
                            break;
                    }
                }
                switch (messaggio)
                {
                    case "Non ci sono\nmosse disponibili":
                        CambioTurno();
                        lblInfoBox.Text = messaggio;
                        break;
                    case "OK":
                        controllo.DadoScelto().DecrementaUtilizziDado();
                        controllo.DadoScelto().AzzeraValore();
                        if (controllo.UtilizziRimasti())
                        {
                            lblInfoBox.Text = "Scegli il dado";
                        }
                        else
                        {
                            CambioTurno();
                        }
                        break;
                    default:
                        lblInfoBox.Text = messaggio;
                        break;
                }
                controllo.AggiornaDadi();
                controllo.ContaPedine();
                ControllaVittoria();
            }
        }
        private void picDado1_Click(object sender, EventArgs e)              // azione sul click del dado di sinistra
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            dado1.SonoScelto = true;
            dado2.SonoScelto = false;
            if (picDado1.Image != null)
            {
                lblInfoBox.Text = "Hai scelto il\ndado con valore: " + dado1.Valore;
            }
        }

        private void picDado2_Click(object sender, EventArgs e)              // azione sul click del dado di destra
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            dado1.SonoScelto = false;
            dado2.SonoScelto = true;
            if (picDado2.Image != null)
            {
                lblInfoBox.Text = "Hai scelto il\ndado con valore: " + dado2.Valore;
            }
        }

        private void btnLanciaDadi_Click_1(object sender, EventArgs e)       // azione sul click del bottone lancia dadi
        {
            Controllo controllo = Controllo.Instance();
            if (controllo.ChiHaVinto() != null)
            {
                InizializzaTavola();
                controllo.AzzeraUtilizziDadi();
                controllo.AzzeraValoreDadi();
                btnLanciaDadi.Text = "Lancia Dadi";
            }
            else if (!controllo.UtilizziRimasti())
            {
                controllo.LanciaDadi();
                controllo.ImpostaUtilizziDadi();
                controllo.AggiornaDadi();
                lblTurnoGiocatore.Text = "Turno di\n" + controllo.MostraTurno().Colore;
                lblInfoBox.Text = "Scegli il dado";
                dadiLanciati = true;
            }
            else
            {
                lblInfoBox.Text = "Devi ancora finire\ndi muovere";
            }
        }

    }
}

