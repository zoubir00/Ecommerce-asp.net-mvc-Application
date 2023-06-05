using EticketsWebApp.Data.Base;
using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        //private readonly AppDbContext _context;

        //public ActorsService(AppDbContext context)
        //{
        //    _context = context;
        //}

        
        
            public ActorsService(AppDbContext context) : base(context) { }
        
        //public void Add(Actor actor)
        //{
        //    _context.Actors.Add(actor);
        //    _context.SaveChanges();
        //}

        //public async Task Delete(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(a => a.ActorId == id);
        //    _context.Actors.Remove(result);
        //    await _context.SaveChangesAsync();
        //}

        //// get all the actors
        //public async Task<IEnumerable<Actor>> GetAll()
        //    => await _context.Actors.ToListAsync();

        //public async Task<Actor> GetById(int id)
        //{
        //    var result = await _context.Actors.FirstOrDefaultAsync(a => a.ActorId == id);
        //    return result;
        //}

        //public async Task Updateasync(int id, Actor Newactor)
        //{
        //    Newactor.ActorId = id;
        //    _context.Update(Newactor);
        //    await _context.SaveChangesAsync();
        //}
    }
}
