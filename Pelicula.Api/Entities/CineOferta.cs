using Microsoft.EntityFrameworkCore;

namespace Pelicula.Api.Entities
{
    public class CineOferta
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        [Precision(5,2)]
        public decimal PorcentajeDescuento { get; set; }
        public int CineId { get; set; }
    }
}
