using microservcursomestrado.Disciplina.Builder;
using microservcursomestrado.Disciplina.Entities.Command;
using Microsoft.EntityFrameworkCore;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public class NotaService : INotaService
    {
        private RepositoryDbContext _dbContext;

        public NotaService(RepositoryDbContext context)
        {
            this._dbContext = context;
        }

        public Task<List<Nota>> GetNotas()
        {
            throw new NotImplementedException();
        }

        public async Task<Nota> CreateNota(NotaCommand nota)
        {
            var bdNota = BuilderNota(nota);
            await _dbContext.Nota.AddAsync(bdNota);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Nota
                .Where(x => x.Id.Equals(bdNota.Id))
                    .FirstOrDefaultAsync();

        }

        public async Task<Nota> UpdateNota(NotaCommand command)
        {
            var notaAntiga =
            await this._dbContext.Nota.Where(x => x.Id.Equals(command.Id))
                   .FirstOrDefaultAsync();

            if (notaAntiga != null)
            {
                var notas = BuilderNota(command);
                await this._dbContext.SaveChangesAsync();
                return notas;
            }

            return null;
        }

        public async Task<Nota> DeleteNota(string id)
        {
            var notaAntiga =
            await this._dbContext.Nota.Where(x => x.Id.Equals(id))
            .FirstOrDefaultAsync();

            if (notaAntiga != null)
            {
                this._dbContext.Remove(notaAntiga);
                await this._dbContext.SaveChangesAsync();
                return notaAntiga;
            }
            return null;
        }

        private Nota BuilderNota(NotaCommand nota)
        {
            return new NotaBuilder()
                .ComId(Guid.NewGuid())
                .ComTipo(nota.Tipo)
                .ComNotaParcial(nota.NotaParcial)
                .ComPeso(nota.Peso)
                .Build();
        }
    }
}