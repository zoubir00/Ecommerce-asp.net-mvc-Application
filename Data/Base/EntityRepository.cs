namespace EticketsWebApp.Data.Base
{
    public class EntityRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public void Add(T Entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Updateasync(int id, T NewEntity)
        {
            throw new NotImplementedException();
        }
    }
}
