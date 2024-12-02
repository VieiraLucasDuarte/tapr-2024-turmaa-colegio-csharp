namespace microservcursomestrado.Curso.Entities.Services
{
    public interface ICursoService
    {
        Task<List<Curso>> GetAllAsync();
        Task<Curso> SaveAsync(Curso curso);
        Task<Curso> UpdateAsync(string id, Curso curso);
        Task<Curso> DeleteAsync(string id);
    }
}