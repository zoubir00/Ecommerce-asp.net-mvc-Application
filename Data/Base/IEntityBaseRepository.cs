using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T Entity);
        Task Updateasync(int id, T NewEntity);
        Task Delete(int id);
    }
}
