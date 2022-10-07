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
            /*asi se hace una llave primaria en un api fluente
           // modelBuilder.Entity<Genero>().HasKey(x => x.Id);*/
         /* modelBuilder.Entity<Cine>().Property(pro=> pro.Precio).HasPrecision(9,2);
          dandole preci*/
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cine> Cines { get; set; }
    }
}
