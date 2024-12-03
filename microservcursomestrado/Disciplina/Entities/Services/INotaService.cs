using microservcursomestrado.Disciplina.Entities.Command;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public interface INotaService
    {
        Task<List<Nota>> GetNotas();
        Task<Nota> CreateNota(NotaCommand nota);
        Task<Nota> UpdateNota(NotaCommand command);
        Task<Nota> DeleteNota(string id);
    }
}