// See https://aka.ms/new-console-template for more information
using HalloDecorator;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Hello, World!");


var pizza1 = new Käse(new Käse(new Salami(new Pizza())));

Console.WriteLine($"🍕{pizza1.Name} {pizza1.Preis:c}");

var brot1 = new Käse(new Käse(new Salami(new Brot())));
Console.WriteLine($"🍞{brot1.Name} {brot1.Preis:c}");
