using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Entities;

namespace microservcursomestrado.Disciplina.Builder
{
    public class DisciplinaBuilder
    {
        private Guid _id = Guid.NewGuid();
        private int _idCurso;
        private string _nome;
        private Horario _horario = new Horario();

        public DisciplinaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public DisciplinaBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public Disciplina Build()
        {
            return new Disciplina
            {
                Id = _id,
                IdCurso = _idCurso,
                Nome = _nome,
                Horario = _horario
            };
        }
    }

}
