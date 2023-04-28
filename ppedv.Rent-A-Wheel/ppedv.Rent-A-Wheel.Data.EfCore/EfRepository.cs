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

        public IRepository<Car> CarRepository => new EfRepository<Car>(context); //todo: Lazy + cache 

        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(context);

        public IRepository<Rent> RentRepository => new EfRepository<Rent>(context);

        public void SaveAll()
        {
            context.SaveChanges();
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext context;

        public EfRepository(EfContext context)
        {
            this.context = context;
        }

        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Delete(int id)
        {
            var loaded = GetById(id);
            if (loaded != null)
                context.Remove(loaded);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T? GetById(int id)
        {
            return context.Find<T>(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
