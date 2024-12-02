using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities
{
    public class Aula
    {
        public Guid Id { get; set; }
        public string IdAluno { get; set; }
        public DateTime Data { get; set; } 
        public Boolean Presenca { get; set; } 
    }
}