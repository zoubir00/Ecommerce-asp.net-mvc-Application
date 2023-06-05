using EticketsWebApp.Data.Base;
using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public class MovieService:EntityBaseRepository<Movie>,IMovieService
    {
        public MovieService(AppDbContext context):base(context){}
    }
}
