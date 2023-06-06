using EticketsWebApp.Data.Base;
using EticketsWebApp.Data.ViewModels;
using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EticketsWebApp.Data.Services
{
    public class MovieService:EntityBaseRepository<Movie>,IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task CreateMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
           await _context.SaveChangesAsync();
            // add movie actors
            foreach(var actorId in data.ActorIds)
            {
                var NewmovieActors = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    Id = actorId
                };
                await _context.Actors_Movies.AddAsync(NewmovieActors);
               await _context.SaveChangesAsync();
            }
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
