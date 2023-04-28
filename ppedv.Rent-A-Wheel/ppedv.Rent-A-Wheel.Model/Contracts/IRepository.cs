using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Model.Contracts
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Rent> RentRepository { get; }


        void SaveAll();
    }
}
