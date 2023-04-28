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
//builder.RegisterType<EfRepository>().AsImplementedInterfaces();
//builder.RegisterType<EfRepository>().As<IRepository>().WithParameter("conString", conString);
//builder.Register(x => new EfRepository(conString)).As<IRepository>();
builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>().WithParameter(new TypedParameter(typeof(string), conString));
//builder.RegisterType<EfRepository>().As<IRepository>().WithParameter(new TypedParameter(typeof(string), conString));
var container = builder.Build();
var uow = container.Resolve<IUnitOfWork>();

//Dependency Injection manuall by Hand
//var repo = new ppedv.Rent_A_Wheel.Data.EfCore.EfRepository(conString);


var carStatService = new CarStatService(uow);
Console.WriteLine($"Most rented: {carStatService.GetCarThatWasRentedTheMostDays().Model}");
