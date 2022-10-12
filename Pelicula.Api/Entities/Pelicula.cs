using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicula.Api.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
       // [Column(TypeName ="varchar(100)")]
        public string Titulo { get; set; }
        public bool EnCartelera { get; set; }
       // [Column(TypeName ="date")]
        public DateTime FechaEstreno { get; set; }
        //[Unicode(false)] para tomar todos los carecteres de una URL
        public string PostelrURL { get; set; }
        public HashSet<Genero> Generos { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get; set; }//relacionando las tablas de la manera muchos a muchos automatico
        public HashSet<PeliculaActor> PeliculaActor { get; set; }


    }
}
