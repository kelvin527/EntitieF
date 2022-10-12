using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pelicula.Api.Entities.Configuration
{
    public class SalaDeCineConfiguration : IEntityTypeConfiguration<SalaDeCine>
    {
        public void Configure(EntityTypeBuilder<SalaDeCine> builder)
        {
           builder.Property(pro => pro.TipoSalaDeCine)
                .HasDefaultValue(TipoSalaDeCine.DosDimensiones);
        }
    }
}
