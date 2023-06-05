using EticketsWebApp.Models;
using System.Linq.Expressions;

namespace EticketsWebApp.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetById(int id);
        Task Add(T Entity);
        Task Updateasync(int id, T NewEntity);
        Task Delete(int id);
    }
}
