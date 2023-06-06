using EticketsWebApp.Data.Base;
using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IMovieService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieBYIdAsync(int id);
    }
}
