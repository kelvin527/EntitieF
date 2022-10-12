using Microsoft.EntityFrameworkCore;

namespace Pelicula.Api.Entities
{
    public class SalaDeCine
    {
        public int Id { get; set; }
        public TipoSalaDeCine TipoSalaDeCine { get; set; }
        [Precision(5,2)]
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
        public HashSet<Pelicula> Peliculas { get; set; }

    }
}
