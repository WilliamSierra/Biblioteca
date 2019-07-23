 
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
    [Route("api/libros")]
    public class LibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/Libros
        //[HttpGet("[action]")]
        //public IEnumerable<Libro> GetLibros()
        //{
        //    return new List<Libro>()
        //    {
        //    new Libro() { Id = 1, IdAutor = 1, IdCategoria = 2, ISBN = 3, Nombre = "df" },
        //    new Libro() { Id = 12, IdAutor = 12, IdCategoria = 22, ISBN = 3, Nombre = "ffff" }

        //    };

        //}

        // GET: api/Libros
        [HttpGet]
        public List<Libro> GetLibros()
        {
            var libros = new List<Libro>();
            libros = _context.Libros.ToList();
            return libros;

        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Libro Libro = await _context.Libros.SingleOrDefaultAsync(m => m.Id == id);

          
            if (Libro == null)
            {
                return NotFound();
            }

            return Ok(Libro);
        }

        // PUT: api/Libros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro([FromRoute] int id, [FromBody] Libro Libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(Libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id)) {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
           
            return NoContent();
        }

        // POST: api/Libros
        [HttpPost]
        public async Task<IActionResult> PostLibro([FromBody] Libro Libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Libros.Add(Libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = Libro.Id }, Libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Libro = await _context.Libros.SingleOrDefaultAsync(m => m.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(Libro);
            await _context.SaveChangesAsync();

            return Ok(Libro);
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}

