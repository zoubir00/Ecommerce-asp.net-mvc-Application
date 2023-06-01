using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();

        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor Newactor);
        void Delete(Actor actor);
    }
}
