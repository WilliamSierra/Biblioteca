using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaV4.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
        public int ISBN { get; set; }
    }

}
