using microservcursomestrado.Disciplina.Entities.Enum;

namespace microservcursomestrado.Disciplina.Entities
{
    public class Nota
    {
        public Guid Id { get; set; }
        public TipoNota Tipo { get; set; }
        public float NotaParcial { get; set; }
        public float Peso { get; set; }
    }
}