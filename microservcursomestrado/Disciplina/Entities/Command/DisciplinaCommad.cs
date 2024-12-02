
namespace microservcursomestrado.Disciplina.Entities.Command
{
    public class DisciplinaCommad
    {
        public string Id { get; set; }
        public string IdCurso { get; set; }
        public string Name { get; set; }
        public HorarioCommand HorarioCommand { get; set; }
    }
}