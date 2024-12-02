using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities.Command
{
    public class HorarioCommand
    {
        public string Id { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        public string IdDisciplina { get; set; }
        public string Sala { get; set; } 
    }
}