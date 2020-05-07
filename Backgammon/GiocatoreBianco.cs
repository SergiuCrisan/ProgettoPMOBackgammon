namespace Backgammon
{
    class GiocatoreBianco : Giocatore
    {
        // ATTRIBUTI
        // Singleton
        private static GiocatoreBianco instance = null;
        // METODI
        private GiocatoreBianco() { }
        public static GiocatoreBianco Instance()
        {
            if (instance == null)
            {
                instance = new GiocatoreBianco();
            }

            return instance;
        }
        // fine singleton
        public override void MuoviPedina(Controllo controllo, int idPedina)
        {
            if (Equals(controllo.ColorePedina(idPedina), this.Colore))  
            {
                controllo.TogliUtlimaPedinaTriangolo(idPedina);
                if (PossoMangiare(controllo, idPedina + (controllo.DadoScelto().Valore * 5)))
                {
                    MangiaPedina(controllo, controllo.TrovaIdTriangolo(idPedina + (controllo.DadoScelto().Valore * 5)));
                }
                else
                {
                    controllo.AggiungiPedinaSuTriangolo(idPedina + (controllo.DadoScelto().Valore * 5), this.Colore);
                }
            }
        }
        public override void RimettiPedina(Controllo controllo, int idPedina)
        {
            if (PossoMangiare(controllo, controllo.DadoScelto().Valore * 5 - 5))
            {
                MangiaPedina(controllo, controllo.TrovaIdTriangolo(controllo.DadoScelto().Valore * 5 - 5));
                TogliPedinaDaOut(controllo);
            }
            else
            {
                controllo.AggiungiPedinaSuTriangolo(controllo.DadoScelto().Valore * 5 - 5, this.Colore);
                TogliPedinaDaOut(controllo);
            }
        }
        public override string TogliPedina(Controllo controllo)
        {
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            string messaggio = "OK";
            if (Equals(controllo.ColoreTriangolo(120 - (controllo.DadoScelto().Valore * 5)), this.Colore))
            {
                controllo.TogliUtlimaPedinaTriangolo(120 - controllo.DadoScelto().Valore * 5);
            }
            else if ((Equals(controllo.ColoreTriangolo(120 - (controllo.DadoScelto().Valore * 5)), "Libero") || Equals(controllo.ColoreTriangolo(120 - (controllo.DadoScelto().Valore * 5)), nero.Colore)) && (120 - (controllo.DadoScelto().Valore * 5)) <= PrimoTriangoloOccupatoBase(controllo))
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
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            controllo.CambiaColorePedina(idPedina, "Libero");
            controllo.AggiungiPedinaSuTriangolo(idPedina, this.Colore);
            nero.AggiungiPedinaInOut(controllo);
        }
        public override bool PossoMangiare(Controllo controllo, int idPedina)
        {
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            bool risposta = false;
            if (Equals(controllo.ColoreTriangolo(idPedina), nero.Colore) && controllo.ContaPedineSuTriangolo(idPedina) < 2)
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
            if (dado1.Valore != 0 && !controllo.TriangoloLibero(dado1.Valore * 5 - 5))
            {
                if (PossoMangiare(controllo, dado1.Valore * 5 - 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(dado1.Valore * 5 - 5), this.Colore))
                {
                    risposta = true;
                }
            }
            else
            {
                risposta = true;
            }
            if (dado2.Valore != 0 && !controllo.TriangoloLibero(dado2.Valore * 5 - 5))
            {
                if (PossoMangiare(controllo, dado2.Valore * 5 - 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(dado2.Valore * 5 - 5), this.Colore))
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
            if (!controllo.TriangoloLibero(controllo.DadoScelto().Valore * 5 - 5))
            {
                if (PossoMangiare(controllo, controllo.DadoScelto().Valore * 5 - 5))
                {
                    risposta = true;
                }
                else if (Equals(controllo.ColoreTriangolo(controllo.DadoScelto().Valore * 5 - 5), this.Colore))
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
            Dado dado1 = Dado.Instance("dado1");                             // dado di sinistra
            Dado dado2 = Dado.Instance("dado2");                             // dado di destra
            GiocatoreNero nero = GiocatoreNero.Instance();                   // giocatore nero
            bool risposta = false;
            int i;
            int contatorePedine = 0;
            for (i = 90; i < 120; i++)
            {
                if (Equals(controllo.ColorePedina(i), this.Colore))
                {
                    contatorePedine++;
                    if (i % 5 == 4)
                    {
                        contatorePedine += controllo.PedineInPiù.LeggiLista[controllo.TrovaIdTriangolo(i)];
                    }
                }
            }
            if (contatorePedine == controllo.PedineBianche)
            {
                if (dado1.Valore != 0)
                {
                    if (Equals(controllo.ColoreTriangolo(120 - (dado1.Valore * 5)), this.Colore))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(120 - (dado1.Valore * 5)), "Libero") || Equals(controllo.ColoreTriangolo(i), nero.Colore))
                    {
                        for (i = 90; i <= 120 - (dado1.Valore * 5); i += 5)
                        {
                            if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), nero.Colore))
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
                    if (Equals(controllo.ColoreTriangolo(120 - (dado2.Valore * 5)), this.Colore))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(120 - (dado2.Valore * 5)), "Libero") || Equals(controllo.ColoreTriangolo(i), nero.Colore))
                    {
                        for (i = 90; i <= 120 - (dado2.Valore * 5); i += 5)
                        {
                            if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), nero.Colore))
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
            for (i = 0; i < 120; i += 5)
            {
                if (dado1.Valore != 0 && Equals(controllo.ColorePedina(i), this.Colore) && i + dado1.Valore * 5 < 120)
                {
                    if (!controllo.TriangoloLibero(i + (dado1.Valore * 5)))
                    {
                        if (PossoMangiare(controllo, i + (dado1.Valore * 5)))
                        {
                            risposta = true;
                        }
                        else if (Equals(controllo.ColoreTriangolo(i + dado1.Valore * 5), this.Colore))
                        {
                            risposta = true;
                        }
                    }
                    else if (Equals(controllo.ColoreTriangolo(i + (dado1.Valore * 5)), this.Colore) || Equals(controllo.ColoreTriangolo(i + (dado1.Valore * 5)), "Libero"))
                    {
                        risposta = true;
                    }
                }
                if (dado2.Valore != 0 && Equals(controllo.ColorePedina(i), this.Colore) && i + dado2.Valore * 5 < 120)
                {
                    if (!controllo.TriangoloLibero(i + (dado2.Valore * 5)))
                    {
                        if (PossoMangiare(controllo, i + (dado2.Valore * 5)))
                        {
                            risposta = true;
                        }
                        else if (Equals(controllo.ColoreTriangolo(i + dado2.Valore * 5), this.Colore))
                        {
                            risposta = true;
                        }
                    }
                    else if (Equals(controllo.ColoreTriangolo(i + (dado2.Valore * 5)), this.Colore) || Equals(controllo.ColoreTriangolo(i + (dado2.Valore * 5)), "Libero"))
                    {
                        risposta = true;
                    }
                }
            }
            return risposta;
        }
        public override bool PossoMuovereQuesto(Controllo controllo, int idPedina)
        {
            bool risposta;
            if (controllo.TrovaIdTriangolo(idPedina) + controllo.DadoScelto().Valore * 5 < 120)
            {
                if (!controllo.TriangoloLibero(idPedina + (controllo.DadoScelto().Valore * 5)))
                {
                    if (PossoMangiare(controllo, idPedina + (controllo.DadoScelto().Valore * 5)))
                    {
                        risposta = true;
                    }
                    else if (Equals(controllo.ColoreTriangolo(idPedina + (controllo.DadoScelto().Valore * 5)), this.Colore))
                    {
                        risposta = true;
                    }
                    else
                    {
                        risposta = false;
                    }
                }
                else if (Equals(controllo.ColoreTriangolo(idPedina + (controllo.DadoScelto().Valore * 5)), "Libero"))
                {
                    risposta = true;
                }
                else
                {
                    risposta = false;
                }
            }
            else
            {
                risposta = false;
            }
            return risposta;
        }
        public override void AggiungiPedinaInOut(Controllo controllo)
        {
            this.PedineMangiate = true;
            controllo.PedineInPiù.ModificaElementoLista(controllo.PedineInPiù.LeggiLista[121] + 1, 121);
            if (controllo.PedineInPiù.LeggiLista[121] == 1)
            {
                controllo.CambiaColorePedina(121, this.Colore);
            }

            controllo.AggiornaIndiciPedine();
        }
        public override void TogliPedinaDaOut(Controllo controllo)
        {
            controllo.PedineInPiù.ModificaElementoLista(controllo.PedineInPiù.LeggiLista[121] - 1, 121);
            if (controllo.PedineInPiù.LeggiLista[121] == 0)
            {
                controllo.CambiaColorePedina(121, "Libero");
                this.PedineMangiate = false;
            }
            controllo.AggiornaIndiciPedine();
        }
        protected override int PrimoTriangoloOccupatoBase(Controllo controllo)
        {
            GiocatoreNero nero = GiocatoreNero.Instance();          // giocatore nero
            int id = 90;
            int i;
            for (i = 90; i < 120; i += 5)
            {
                if (Equals(controllo.ColoreTriangolo(i), "Libero") || Equals(controllo.ColoreTriangolo(i), nero.Colore))
                {
                    id = i + 5;
                }
                else
                {
                    i = 120;
                }
            }
            return id;
        }
    }
}
