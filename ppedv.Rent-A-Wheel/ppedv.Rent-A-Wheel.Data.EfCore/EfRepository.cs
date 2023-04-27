using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.Data.EfCore
{
    public class EfRepository : IRepository
    {
        readonly EfContext context;

        public EfRepository(string conString)
        {
            context = new EfContext(conString);
        }

        public void Add<T>(T entity) where T : Entity
        {
            context.Add(entity);
        }

        public void Delete<T>(int id) where T : Entity
        {
            var loaded = GetById<T>(id);
            if (loaded != null)
                context.Remove(loaded);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return context.Find<T>(id);
        }

        public void SaveAll()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            context.Update<T>(entity);
        }
    }
}
