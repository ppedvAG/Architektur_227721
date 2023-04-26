namespace HalloBuilder
{
    internal class Schrank
    {
        public int AnzahlTüren { get; private set; }
        public int AnzahlBöden { get; private set; }
        public Schrankoberfläche Schrankoberfläche { get; private set; }
        public string Farbe { get; private set; } = string.Empty;
        public bool Metallschiene { get; private set; }
        public bool Kleiderstange { get; private set; }

        private Schrank()
        { }

        public class Builder
        {
            private Schrank schrank = new Schrank();

            public Builder SetTüren(int anzTüren)
            {
                if (anzTüren < 2 || anzTüren > 7)
                    throw new ArgumentException("Ein Schrank kann nur 2-7 Türen haben.");

                schrank.AnzahlTüren = anzTüren;

                return this;
            }

            public Builder SetBöden(int anzBöden)
            {
                if (anzBöden < 0 || anzBöden >= 6)
                    throw new ArgumentException("Ein Schrank kann nur 0-6 Böden haben.");

                schrank.AnzahlBöden = anzBöden;

                return this;
            }

            public Builder SetFarbe(string farbe)
            {
                if (schrank.Schrankoberfläche != Schrankoberfläche.Lackiert)
                    throw new ArgumentException("Nur lackierte Schränke können eine Farbe haben");


                schrank.Farbe = farbe;

                return this;
            }

            public Builder SetOberfläche(Schrankoberfläche oberfläche)
            {
                schrank.Schrankoberfläche = oberfläche;

                if (oberfläche != Schrankoberfläche.Lackiert)
                    schrank.Farbe = string.Empty;

                return this;
            }

            public Schrank Create()
            {
                //todo validate
                return schrank;
            }
        }

    }
    enum Schrankoberfläche
    {
        Unbehandelt,
        Gewachst,
        Lackiert
    }
}
