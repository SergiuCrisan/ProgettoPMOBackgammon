namespace Backgammon
{
    class GiocatoreNero : Giocatore
    {
        // ATTRIBUTI
        // Singleton
        private static GiocatoreNero instance = null;
        private GiocatoreNero() { }
        // METODI
        public static GiocatoreNero Instance()
        {
            if (instance == null)
                instance = new GiocatoreNero();
            return instance;
        }
        // fine singleton
        public override void MuoviPedina(Controllo controllo, int idPedina)
        {
            if (Equals(controllo.ColorePedina(idPedina), this.Colore)) // rimuove la pedina nera
            {
                controllo.TogliUtlimaPedinaTriangolo(idPedina);
                if (PossoMangiare(controllo, idPedina - (controllo.DadoScelto().Valore * 5)))
                {
                    MangiaPedina(controllo, controllo.TrovaIdTriangolo(idPedina - (controllo.DadoScelto().Valore * 5)));
                }
                else
                {
                    controllo.AggiungiPedinaSuTriangolo(idPedina - (controllo.DadoScelto().Valore * 5), this.Colore);
                }
            }
        }
        public override void RimettiPedina(Controllo controllo, int idPedina)
        {
            if (PossoMangiare(controllo, 120 - controllo.DadoScelto().Valore * 5))
            {
                MangiaPedina(controllo, controllo.TrovaIdTriangolo(120 - controllo.DadoScelto().Valore * 5));
                TogliPedinaDaOut(controllo);
            }
            else
            {
                controllo.AggiungiPedinaSuTriangolo(120 - controllo.DadoScelto().Valore * 5, this.Colore);
                TogliPedinaDaOut(controllo);
            }
        }
        public override string TogliPedina(Controllo controllo)
        {
            string messaggio = "OK";
            if (Equals(controllo.ColoreTriangolo(controllo.DadoScelto().Valore * 5 - 5), this.Colore))
            {
                controllo.TogliUtlimaPedinaTriangolo(controllo.DadoScelto().Valore * 5 - 5);
            }
            else if ((Equals(controllo.ColoreTriangolo(controllo.DadoScelto().Valore * 5 - 5), "Libero") || Equals(controllo.ColoreTriangolo(controllo.DadoScelto().Valore * 5 - 5), this.Colore)) && ((controllo.DadoScelto().Valore * 5 - 5)) >= PrimoTriangoloOccupatoBase(controllo))
            {
                controllo.TogliUtlimaPedinaTriangolo(PrimoTriangoloOccupatoBase(controllo));
            }
            else
            {
                messaggio = "Mossa non possibile";
            }
            return messaggio;
        }
        public override void MangiaPedina(Controllo controllo, int idPedina)
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            controllo.CambiaColorePedina(idPedina, "Libero");
            controllo.AggiungiPedinaSuTriangolo(idPedina, this.Colore);
            bianco.AggiungiPedinaInOut(controllo);
        }
        public override bool PossoMangiare(Controllo controllo, int idPedina)
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            bool risposta = false;
            if (Equals(controllo.ColoreTriangolo(idPedina), bianco.Colore) && controllo.ContaPedineSuTriangolo(idPedina) < 2)
            {
                risposta = true;
            }
            return risposta;
        }
        public override bool PossoRimettereGenerale(Controllo controllo)
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            bool risposta = false;
            if (dado1.Valore != 0 && !controllo.TriangoloLibero(120 - dado1.Valore * 5))
            {
                if (PossoMangiare(controllo, 120 - dado1.Valore * 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(120 - dado1.Valore * 5), this.Colore))
                {
                    risposta = true;
                }
            }
            else
            {
                risposta = true;
            }
            if (dado2.Valore != 0 && !controllo.TriangoloLibero(120 - dado2.Valore * 5))
            {
                if (PossoMangiare(controllo, 120 - dado2.Valore * 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(120 - dado2.Valore * 5), this.Colore))
                {
                    risposta = true;
                }
            }
            else
            {
                risposta = true;
            }
            return risposta;
        }
        public override bool PossoRimettereQui(Controllo controllo)
        {
            bool risposta = false;
            if (!controllo.TriangoloLibero(120 - controllo.DadoScelto().Valore * 5))
            {
                if (PossoMangiare(controllo, 120 - controllo.DadoScelto().Valore * 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(120 - controllo.DadoScelto().Valore * 5), this.Colore))
                {
                    risposta = true;
                }
            }
            else
            {
                risposta = true;
            }
            return risposta;
        }
        public override bool PossoTogliere(Controllo controllo)
        {
            bool risposta = false;
            int i;
            int contatorePedine = 0;
            for (i = 0; i < 30; i++)
            {
                if (Equals(controllo.ColorePedina(i), this.Colore))
                {
                    contatorePedine++;
                    if (i % 5 == 4 && i != 120)
                    {
                        contatorePedine += controllo.PedineInPiù.LeggiLista[controllo.TrovaIdTriangolo(i)];
                    }
                }
            }
            if (contatorePedine == controllo.PedineNere)
            {
                Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
                Dado dado2 = Dado.Instance("dado2");                             // dado di destra
                GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
                if (dado1.Valore != 0)
                {
                    if (Equals(controllo.ColoreTriangolo(dado1.Valore * 5 - 5), this.Colore))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(dado1.Valore * 5 - 5), "Libero") || Equals(controllo.ColoreTriangolo(i), bianco.Colore))
                    {
                        for (i = 25; i >= (dado1.Valore * 5 - 5); i -= 5)
                        {
                            if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), bianco.Colore))
                            {
                                risposta = true;
                            }
                            else
                            {
                                risposta = false;
                            }
                        }
                    }
                }
                if (dado2.Valore != 0)
                {
                    if (Equals(controllo.ColoreTriangolo(dado2.Valore * 5 - 5), this.Colore))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(dado2.Valore * 5 - 5), "Libero") || Equals(controllo.ColoreTriangolo(i), bianco.Colore))
                    {
                        for (i = 25; i >= (dado2.Valore * 5 - 5); i -= 5)
                        {
                            if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), bianco.Colore))
                            {
                                risposta = true;
                            }
                            else
                            {
                                risposta = false;
                            }
                        }
                    }
                }
            }
            return risposta;
        }
        public override bool PossoMuovereGenerale(Controllo controllo)
        {
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            bool risposta = false;
            int i;
            for (i = 0; i < 120; i++)
            {
                if (dado1.Valore != 0 && Equals(controllo.ColorePedina(i), this.Colore) && i - dado1.Valore * 5 > 0)
                {
                    if (!controllo.TriangoloLibero(i - (dado1.Valore * 5)))
                    {
                        if (PossoMangiare(controllo, i - (dado1.Valore * 5)))
                        {
                            risposta = true;
                        }
                        else if (Equals(controllo.ColoreTriangolo(i - dado1.Valore * 5), this.Colore))
                        {
                            risposta = true;
                        }
                    }
                    else if (Equals(controllo.ColoreTriangolo(i - (dado1.Valore * 5)), this.Colore) || Equals(controllo.ColoreTriangolo(i - (dado1.Valore * 5)), "Libero"))
                    {
                        risposta = true;
                    }
                }
                if (i - dado2.Valore * 5 > 0 && Equals(controllo.ColorePedina(i), this.Colore) && dado2.Valore != 0)
                {
                    if (!controllo.TriangoloLibero(i - (dado2.Valore * 5)))
                    {
                        if (PossoMangiare(controllo, i - (dado2.Valore * 5)))
                        {
                            risposta = true;
                        }
                        else if (Equals(controllo.ColoreTriangolo(i - dado2.Valore * 5), this.Colore))
                        {
                            risposta = true;
                        }
                    }
                    else if (Equals(controllo.ColoreTriangolo(i - (dado2.Valore * 5)), this.Colore) || Equals(controllo.ColoreTriangolo(i - (dado2.Valore * 5)), "Libero"))
                    {
                        risposta = true;
                    }
                }
            }
            return risposta;
        }
        public override bool PossoMuovereQuesto(Controllo controllo, int idPedina)
        {
            bool risposta = false;
            if (controllo.TrovaIdTriangolo(idPedina) - controllo.DadoScelto().Valore * 5 >= 0)
            {
                if (!controllo.TriangoloLibero(idPedina - (controllo.DadoScelto().Valore * 5)))
                {
                    if (PossoMangiare(controllo, idPedina - (controllo.DadoScelto().Valore * 5)))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(idPedina - (controllo.DadoScelto().Valore * 5)), this.Colore))
                    {
                        risposta = true;
                    }
                }
                else if (Equals(controllo.ColoreTriangolo(idPedina - (controllo.DadoScelto().Valore * 5)), this.Colore) || Equals(controllo.ColoreTriangolo(idPedina - (controllo.DadoScelto().Valore * 5)), "Libero"))
                {
                    risposta = true;
                }
            }
            return risposta;
        }
        public override void AggiungiPedinaInOut(Controllo controllo)
        {
            this.PedineMangiate = true;
            controllo.PedineInPiù.ModificaElementoLista(controllo.PedineInPiù.LeggiLista[120] + 1, 120);
            if (controllo.PedineInPiù.LeggiLista[120] == 1)
            {
                controllo.CambiaColorePedina(120, this.Colore);
            }

            controllo.AggiornaIndiciPedine();
        }
        public override void TogliPedinaDaOut(Controllo controllo)
        {
            controllo.PedineInPiù.ModificaElementoLista(controllo.PedineInPiù.LeggiLista[120] - 1, 120);
            if (controllo.PedineInPiù.LeggiLista[120] == 0)
            {
                controllo.CambiaColorePedina(120, "Libero");
                this.PedineMangiate = false;
            }
            controllo.AggiornaIndiciPedine();
        }
        protected override int PrimoTriangoloOccupatoBase(Controllo controllo)
        {
            GiocatoreBianco bianco = GiocatoreBianco.Instance();    // giocatore bianco
            int id = 25;
            int i;
            for (i = 25; i >= 0; i -= 5)
            {
                if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), bianco.Colore))
                {
                    id = i - 5;
                }
                else
                {
                    i = 0;
                }
            }
            return id;
        }
    }
}
