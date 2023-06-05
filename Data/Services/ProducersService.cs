using EticketsWebApp.Data.Base;
using EticketsWebApp.Models;

namespace EticketsWebApp.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>,IProducersService
    {
        public ProducersService(AppDbContext context):base(context)
        {
            
        }
    }
}
