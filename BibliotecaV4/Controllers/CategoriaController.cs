
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
    [Route("api/categorias")]
    public class CategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public List<Categoria> GetCategorias()
        {
            var categorias = new List<Categoria>();
            categorias = _context.Categorias.ToList();
            return categorias;

        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria Categoria = await _context.Categorias.SingleOrDefaultAsync(m => m.Id == id);


            if (Categoria == null)
            {
                return NotFound();
            }

            return Ok(Categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria([FromRoute] int id, [FromBody] Categoria Categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(Categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        [HttpPost]
        public async Task<IActionResult> PostCategoria([FromBody] Categoria Categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(Categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = Categoria.Id }, Categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Categoria = await _context.Categorias.SingleOrDefaultAsync(m => m.Id == id);
            if (Categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(Categoria);
            await _context.SaveChangesAsync();

            return Ok(Categoria);
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}

