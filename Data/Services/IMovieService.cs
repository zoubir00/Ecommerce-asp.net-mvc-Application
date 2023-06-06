using EticketsWebApp.Data.Base;
using EticketsWebApp.Data.ViewModels;
using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public interface IMovieService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieBYIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMoviesDropdownsVlaues();
        Task CreateMovieAsync(NewMovieVM data);
    }
}
