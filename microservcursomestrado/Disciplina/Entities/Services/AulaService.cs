using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public class AulaService : IAulaService
    {
        private RepositoryDbContext _dbContext;

        public AulaService(RepositoryDbContext context)
        {
            this._dbContext = context;
        }

        public Task<Aula> CreateAula()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Aula>> GetAulaAsync()
            => await this._dbContext.Aula.ToListAsync();
    }
}