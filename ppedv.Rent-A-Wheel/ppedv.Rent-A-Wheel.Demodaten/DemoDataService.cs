using Bogus;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Demodaten
{
    public class DemoDataService : IDemoDatenService
    {
        public void CreateAndStoreDemoData(IUnitOfWork unitOfWork, int amount = 10)
        {
            for (int i = 0; i < amount; i++)
            {
                var rent = CreateDemoRent();
                unitOfWork.RentRepository.Add(rent);
            }
            unitOfWork.SaveAll();
        }

        public Car CreateDemoCar()
        {
            var faker = new Faker<Car>()
                .RuleFor(x => x.Manufacturer, x => x.Vehicle.Manufacturer())
                .RuleFor(x => x.Model, x => x.Vehicle.Model())
                .RuleFor(x => x.KW, x => x.Random.Int(20, 500))
                .RuleFor(x => x.Seats, x => x.Random.Int(2, 9))
                .RuleFor(x => x.Color, x => x.Commerce.Color())
                .RuleFor(x => x.ManufacturingDate, x => x.Date.Past(10));

            return faker.Generate();
        }

        public Customer CreateDemoCustomer()
        {
            var faker = new Faker<Customer>("de")
                .RuleFor(x => x.BirthDate, x => x.Date.Past(70))
                .RuleFor(x => x.Name, x => x.Name.FullName());

            return faker.Generate();
        }

        public Rent CreateDemoRent()
        {
            var faker = new Faker<Rent>()
                         .RuleFor(x => x.OrderDate, x => x.Date.Recent(10))
                          .RuleFor(x => x.StartDate, x => x.Date.Soon(5))
                          .RuleFor(x => x.EndDate, x => x.Date.Soon(10))
                          .RuleFor(x => x.StartLocation, x => x.Address.FullAddress())
                          .RuleFor(x => x.EndLocation, x => x.Address.FullAddress())
                          .RuleFor(x => x.Customer, CreateDemoCustomer())
                          .RuleFor(x => x.Car, CreateDemoCar());

            return faker.Generate();
        }
    }
}