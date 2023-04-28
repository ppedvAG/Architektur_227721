using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        readonly EfContext context;
        public EfUnitOfWork(string conString)
        {
            context = new EfContext(conString);
        }

        public ICarRepository CarRepository => new EfCarRepository(context); //todo: Lazy + cache 

        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(context);

        public IRepository<Rent> RentRepository => new EfRepository<Rent>(context);

        public void SaveAll()
        {
            context.SaveChanges();
        }
    }
}
