using BibliotecaV4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaV4.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Libro> Libros { get; set; }
    }
}
