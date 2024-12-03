using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Entities.Command;
using Microsoft.EntityFrameworkCore;
using microservcursomestrado.Disciplina.Builder;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public class AulaService : IAulaService
    {
        private RepositoryDbContext _dbContext;

        public AulaService(RepositoryDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<Aula> CreateAula(AulaCommand command)
        {
            var bdAula = BuilderAula(command);
            await _dbContext.Aula.AddAsync(bdAula);
            await _dbContext.SaveChangesAsync();
            return bdAula;
        }

        public async Task<Aula> UpdateAula(AulaCommand command)
        {
            var aulaAntiga =
                await this._dbContext.Aula.Where(x => x.Id.Equals(command.IdAula))
                   .FirstOrDefaultAsync();

            if (aulaAntiga != null)
            {
                var aula = BuilderAula(command);
                await this._dbContext.SaveChangesAsync();
                return aula;
            }
            return null;
        }

        public async Task<Aula> DeleteAula(string id)
        {
            var aulaAntiga =
                await this._dbContext.Aula.Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (aulaAntiga != null)
            {
                this._dbContext.Remove(aulaAntiga);
                await this._dbContext.SaveChangesAsync();
                return aulaAntiga;
            }
            return null;
        }

        public async Task<List<Aula>> GetAulaAsync()
            => await this._dbContext.Aula.ToListAsync();


        private Aula BuilderAula(AulaCommand command)
        {
            return new AulaBuilder()
                .ComId(Guid.NewGuid())
                .ComIdAluno(command.IdAluno)
                .ComData(command.Date)
                .ComPresenca(command.Presenca)
                .Build();
        }
    }
}