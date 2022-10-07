using Microsoft.EntityFrameworkCore;

namespace Pelicula.Api.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //asi se hace una llave primaria en un api fluente
           // modelBuilder.Entity<Genero>().HasKey(x => x.Id);
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actor { get; set; }
    }
}
