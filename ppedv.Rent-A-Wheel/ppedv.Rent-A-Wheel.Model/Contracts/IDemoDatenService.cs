using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Model.Contracts
{
    public interface IDemoDatenService
    {
        Car CreateDemoCar();
        Customer CreateDemoCustomer();
        Rent CreateDemoRent();

        void CreateAndStoreDemoData(IUnitOfWork unitOfWork, int amount = 10);
    }
}
