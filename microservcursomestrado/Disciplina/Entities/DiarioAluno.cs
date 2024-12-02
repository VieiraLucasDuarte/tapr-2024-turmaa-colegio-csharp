using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities
{
    public class DiarioAluno
    {
        public Guid ID { get; set; }
        public string IdAluno { get; set; }
        public string IdAula { get; set; }
        public string IdDisciplina { get; set; }
        public int Faltas { get; set; }
    }
}