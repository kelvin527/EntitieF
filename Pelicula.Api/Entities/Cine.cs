using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Pelicula.Api.Entities
{
    public class Cine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(9,2)]//este metedo sirve para ponerle el espacio en digitos que queramos 
       //              que tenga nuestra propiedad con tipo de dato decimal
        
        public Point Ubicacion { get; set; }
        public CineOferta CineOferta { get; set; }
        public HashSet<SalaDeCine> SalaDeCines { get; set; }/*HashSet<> es mas rapido que 
                                                             List y ICollection pero no ordena como las demas*/
    }
}
