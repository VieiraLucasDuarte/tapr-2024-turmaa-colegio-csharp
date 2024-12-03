using microservcursomestrado.Disciplina.Entities;

namespace microservcursomestrado.Disciplina.Builder
{
    public class AulaBuilder
    {
        private Guid _id;
        private string _idAluno;
        private DateTime _data;
        private bool _presenca;

        public AulaBuilder()
        {
            _id = Guid.NewGuid();
            _idAluno = string.Empty;
            _data = DateTime.Now;
            _presenca = false;
        }

        public AulaBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public AulaBuilder ComIdAluno(string idAluno)
        {
            _idAluno = idAluno;
            return this;
        }

        public AulaBuilder ComData(DateTime data)
        {
            _data = data;
            return this;
        }

        public AulaBuilder ComPresenca(bool presenca)
        {
            _presenca = presenca;
            return this;
        }

        public Aula Build()
        {
            return new Aula
            {
                Id = _id,
                IdAluno = _idAluno,
                Data = _data,
                Presenca = _presenca
            };
        }
    }
}