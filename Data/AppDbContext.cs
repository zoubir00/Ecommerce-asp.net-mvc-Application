using EticketsWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EticketsWebApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.Actorid,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie)
                .WithMany(am => am.Actors_Movies)
                .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<Actor_Movie>().HasOne(a => a.Actor)
                 .WithMany(am => am.Actors_Movies)
                 .HasForeignKey(a => a.Actorid);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
