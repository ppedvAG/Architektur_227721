using HalloBuilder;

Console.WriteLine("Hello, World!");

var schrank1 = new Schrank.Builder()
                          .SetTüren(3)
                          .SetBöden(5)
                          .Create();
