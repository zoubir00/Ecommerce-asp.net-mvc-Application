using EticketsWebApp.Data.Base;
using EticketsWebApp.Data.ViewModels;
using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Data.Services
{
    public class MovieService:EntityBaseRepository<Movie>,IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Movie> GetMovieBYIdAsync(int id)
        {
            var movieDetail = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movieDetail;
        }

        public async Task<NewMovieDropdownsVM> GetNewMoviesDropdownsVlaues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(p => p.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(c=> c.Name).ToListAsync()
            };
            return response;
        }
    }
}
