using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pelicula.Api.Entities.Configuration
{
    public class PeliculaActorConfiguration : IEntityTypeConfiguration<PeliculaActor>
    {
        public void Configure(EntityTypeBuilder<PeliculaActor> builder)
        {
            builder.HasKey(prop => new { prop.PeliculaId, prop.ActorId });
        }
    }
}
