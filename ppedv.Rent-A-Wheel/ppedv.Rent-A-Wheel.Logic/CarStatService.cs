using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Logic
{
    public class CarStatService
    {
        private readonly IRepository repository;

        public CarStatService(IRepository repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            this.repository = repository;
        }

        public Car? GetCarThatWasRentedTheMostDays()
        {
            return repository.GetAll<Car>()
                             .OrderByDescending(x => x.Rents.Sum(y => (y.EndDate - y.StartDate).TotalDays))
                             .FirstOrDefault();
        }
    }
}