using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities
{
    public class Disciplina
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Horario Horario { get; set; } = new Horario();
    }
}