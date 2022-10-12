using System.ComponentModel.DataAnnotations.Schema;

namespace Pelicula.Api.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Biografia { get; set; }
        /*[Column(TypeName ="date")]/*esto es para quitar la horo de la fecha de nacimiento
                                   //haciendo el campo igual al tipo de dato que se maneja en 
                                    SQL*/
        public DateTime FechaNacimiento { get; set; }
        public HashSet<PeliculaActor> PeliculaActor { get; set; }
    }
}
