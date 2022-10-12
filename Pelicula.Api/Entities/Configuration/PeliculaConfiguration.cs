using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Pelicula.Api.Entities.Configuration
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            builder.Property(pro => pro.PostelrURL).HasMaxLength(500)
               .IsUnicode(false);
        }
    }
}
