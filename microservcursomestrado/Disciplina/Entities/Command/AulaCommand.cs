using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities.Command
{
    public class AulaCommand
    {
        public string IdAula { get; set; }
        public string IdAluno { get; set; }
        public string IdDiario { get; set; }
        public DateTime Date { get; set; }
        public Boolean Presenca { get; set; }
    }
}