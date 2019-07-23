
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using BibliotecaV4.Model;
using BibliotecaV4.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaV4.Controllers
{
    [Produces("application/json")]
    [Route("api/autores")]
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/Autores
        //[HttpGet("[action]")]
        //public IEnumerable<Autor> GetLibros()
        //{
        //    return new List<Autor>()
        //    {
        //    new Autor() { Id = 1, IdAutor = 1, IdCategoria = 2, ISBN = 3, Nombre = "df" },
        //    new Autor() { Id = 12, IdAutor = 12, IdCategoria = 22, ISBN = 3, Nombre = "ffff" }

        //    };

        //}

        // GET: api/Autores
        [HttpGet]
        public List<Autor> GetAutores()
        {
            var autores = new List<Autor>();
            autores = _context.Autores.ToList();
            return autores;

        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Autor Autor = await _context.Autores.SingleOrDefaultAsync(m => m.IdAutor == id);


            if (Autor == null)
            {
                return NotFound();
            }

            return Ok(Autor);
        }

        // PUT: api/Autores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor([FromRoute] int id, [FromBody] Autor Autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Autor.IdAutor)
            {
                return BadRequest();
            }

            _context.Entry(Autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autores
        [HttpPost]
        public async Task<IActionResult> PostAutor([FromBody] Autor Autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Autores.Add(Autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = Autor.IdAutor }, Autor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Autor = await _context.Autores.SingleOrDefaultAsync(m => m.IdAutor == id);
            if (Autor == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(Autor);
            await _context.SaveChangesAsync();

            return Ok(Autor);
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.IdAutor == id);
        }
    }
}

