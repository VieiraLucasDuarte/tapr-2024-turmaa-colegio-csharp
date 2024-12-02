using microservcursomestrado.Disciplina.Entities;

namespace microservcursomestrado.Disciplina.Builder
{
    public class HorarioBuilder
    {
        private Guid _id = Guid.NewGuid(); // Gera um GUID único por padrão
        private DateTime _dataInicio = DateTime.MinValue;
        private DateTime _dataFim = DateTime.MinValue;
        private string _idDisciplina;
        private string _sala;

        public HorarioBuilder ComId(Guid id)
        {
            _id = id;
            return this;
        }

        public HorarioBuilder ComDataInicio(DateTime dataInicio)
        {
            _dataInicio = dataInicio;
            return this;
        }

        public HorarioBuilder ComDataFim(DateTime dataFim)
        {
            _dataFim = dataFim;
            return this;
        }

        public HorarioBuilder ComIdDisciplina(string idDisciplina)
        {
            _idDisciplina = idDisciplina;
            return this;
        }

        public HorarioBuilder ComSala(string sala)
        {
            _sala = sala;
            return this;
        }

        public Horario Build()
        {
            return new Horario
            {
                Id = _id,
                DataInicio = _dataInicio,
                DataFim = _dataFim,
                IdDisciplina = _idDisciplina,
                Sala = _sala
            };
        }
    }
}
