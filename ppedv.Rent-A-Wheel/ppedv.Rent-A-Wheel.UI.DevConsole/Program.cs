using Autofac;
using ppedv.Rent_A_Wheel.Data.EfCore;
using ppedv.Rent_A_Wheel.Logic;
using ppedv.Rent_A_Wheel.Model.Contracts;
using System.Reflection;

Console.WriteLine("*** Rent-A-Wheel v0.1 ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;";


//DI per Reflection
//var filePath = @"C:\Users\ar2\source\repos\ppedvAG\Architektur_227721\ppedv.Rent-A-Wheel\ppedv.Rent-A-Wheel.Data.EfCore\bin\Debug\net7.0\ppedv.Rent-A-Wheel.Data.EfCore.dll";
//var ass = Assembly.LoadFrom(filePath);
//var typeWithRepo = ass.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IRepository))).FirstOrDefault();
//var repo = (IRepository)Activator.CreateInstance(typeWithRepo, conString);

//Di per AutoFac
var builder = new ContainerBuilder();

builder.RegisterType<CarStatService>().AsImplementedInterfaces();
builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().WithParameter(new TypedParameter(typeof(string), conString));
var container = builder.Build();
var uow = container.Resolve<IUnitOfWork>();

//Dependency Injection manuall by Hand
//var repo = new ppedv.Rent_A_Wheel.Data.EfCore.EfRepository(conString);


var carStatService = container.Resolve<ICarStatService>();
Console.WriteLine($"Most rented: {carStatService?.GetCarThatWasRentedTheMostDays()?.Model}");

var today = DateTime.Now;   
var openRents = uow.RentRepository.Query()
                   .Where(r => r.StartDate <= today && r.EndDate >= today)
                   .ToList();
foreach (var rent in openRents)
{
    Console.WriteLine($"{rent?.Car?.Model}");
}

