using EticketsWebApp.Data.Base;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace EticketsWebApp.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinema>,ICinemaService

    {
        public CinemaService(AppDbContext context):base(context){}
    }
}
