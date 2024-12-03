namespace microservcursomestrado.Disciplina.Entities.Command
{
    public class NotaCommand
    {
        public string Id { get; set; }
        public int Tipo { get; set; }
        public float NotaParcial { get; set; }
        public float Peso { get; set; }
    }
}