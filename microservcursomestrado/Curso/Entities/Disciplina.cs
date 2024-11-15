using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Curso.Entities
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public int IdCurso  { get; set; }
        public string Nome {get; set; }
    }
}