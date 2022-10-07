using Microsoft.EntityFrameworkCore;

namespace Pelicula.Api.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(9,2)]//este metedo sirve para ponerle el espacio en digitos que queramos 
       //              que tenga nuestra propiedad con tipo de dato decimal
        public decimal Precio { get; set; }
    }
}
