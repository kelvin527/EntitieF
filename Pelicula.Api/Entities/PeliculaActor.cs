using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicula.Api.Entities
{
    public class PeliculaActor
    {
        public int PeliculaId { get; set; }
        public int ActorId { get; set; }
        //[Column(TypeName ="varchar(100)")]
        public string Personaje { get; set; }
        public int Orden { get; set; }
        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }

    }
}
