using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();

        Task<Actor> GetById(int id);
        void Add(Actor actor);
        Task Updateasync(int id, Actor Newactor);
        Task Delete(int id);
    }
}
