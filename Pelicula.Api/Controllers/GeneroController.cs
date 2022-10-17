using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pelicula.Api.Entities;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Pelicula.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly Context context;
        public GeneroController(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IEnumerable<Genero>> Get()
        {
            //AsNoTracking se usa para que los Get respondan mas rapido y se puede inyectar junto al DBCONTEXT
            //AsTraking esto sobre escribe el AsNotraking inyectado y esto sirve para darle seguimiento a los cambios en la Bd(Buscar mejor explicacion)

            return await context.Generos.OrderBy(x => x.Nombre).ToListAsync();//ordenado alfabeticamente por el nombre
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genero>> GetId(int id)
        {
            var comprobar = await context.Generos.FirstOrDefaultAsync(x => x.Id == id);
            if (comprobar is null)
            {
                return NotFound("El id no esta registrado");
            }
            return Ok(comprobar);
        }
        [HttpGet("primera letra")]
        public async Task<ActionResult<Genero>> Getletra()
        {
            //  StartsWith sirve para encontrar nombre que concidan con una letra
            var comprobar = await context.Generos.FirstOrDefaultAsync(g => g.Nombre.StartsWith("g"));
            if (comprobar is null) { return NotFound("No existe nombre con esa letra"); }
            return Ok(comprobar);
        }
        [HttpGet("nombre")]
        public async Task<IEnumerable<Genero>> Filtrar()
        {
            //usando condicion logica y where para hacer un filtro
            return await context.Generos.Where(g => g.Nombre.StartsWith("a") ||
            g.Nombre.StartsWith("b")).ToListAsync();
        }

        [HttpGet("paginacion")]
        public async Task<ActionResult<IEnumerable<Genero>>> GetPaginacion(int pagina = 1)
        {
            //esta logica muestra dos registro por el id del parametro
            var cantidadRegistrosPorPagina = 2;
            var generos = await context.Generos
             .Skip((pagina - 1) * cantidadRegistrosPorPagina)//skip sirve para saltar un registro
            .Take(cantidadRegistrosPorPagina)//take nos sirve para mostrar una x cantida de registro EN UNA PAGINA
            .ToListAsync();
            return generos;

        }

    }
}
