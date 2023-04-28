using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Logic
{
    public class CarStatService : ICarStatService
    {
        private readonly IUnitOfWork unitOfWork;

        public CarStatService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
        }

        public Car? GetCarThatWasRentedTheMostDays()
        {
            return unitOfWork.CarRepository.GetAll()
                             .OrderByDescending(x => x.Rents.Sum(y => (y.EndDate - y.StartDate).TotalDays))
                             .FirstOrDefault();
        }
    }
}