using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities
{
    public class Horario
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string IdDisciplina { get; set; }
        public string Sala { get; set; }
    }
}