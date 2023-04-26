using HalloBuilder;

Console.WriteLine("Hello, World!");

var schrank1 = new Schrank.Builder()
                          .SetTüren(3)
                          .SetBöden(5)
                          .Create();

var schrank2 = new Schrank.Builder()
                          .SetTüren(3)
                          .SetBöden(5)
                          .SetOberfläche(Schrankoberfläche.Lackiert)
                          .SetFarbe("blau")
                          .Create();