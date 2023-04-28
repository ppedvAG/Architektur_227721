using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Model.Contracts
{
    public interface ICarStatService
    {
        Car? GetCarThatWasRentedTheMostDays();
    }
}