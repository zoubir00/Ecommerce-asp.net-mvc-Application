using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void Delete(Actor actor)
        {
            throw new NotImplementedException();
        }

        // get all the actors
        public async  Task<IEnumerable<Actor>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public Actor GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Actor Update(int id, Actor Newactor)
        {
            throw new NotImplementedException();
        }
    }
}
