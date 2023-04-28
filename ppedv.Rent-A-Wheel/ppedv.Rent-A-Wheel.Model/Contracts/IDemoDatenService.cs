using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Model.Contracts
{
    public interface IDemoDatenService
    {
        Car GetDemoCar();
        Customer GetDemoCustomer();
        Rent GetDemoRent();

        void CreateDemoData(IUnitOfWork unitOfWork, int amount = 10);
    }
}
