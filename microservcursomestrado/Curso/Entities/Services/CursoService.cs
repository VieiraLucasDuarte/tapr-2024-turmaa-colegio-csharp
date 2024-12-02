using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace microservcursomestrado.Curso.Entities.Services
{
    public class CursoService : ICursoService
    {
        private RepositoryDbContext _dbContext;
        public CursoService(RepositoryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            var listaCurso = await this._dbContext.Cursos.ToListAsync();
            return listaCurso;
        }

        public async Task<Curso> SaveAsync(Curso curso)
        {
            await this._dbContext.Cursos.AddAsync(curso);
            await this._dbContext.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso> UpdateAsync(string id, Curso curso)
        {
            var cursoAntigo = 
                await this._dbContext.Cursos.Where(x => x.Id.Equals(id))
                    .FirstOrDefaultAsync();

            if(cursoAntigo != null)
            {
                cursoAntigo.Name = curso.Name;
                await this._dbContext.SaveChangesAsync();
                return cursoAntigo;
            }
            return null;
        }

        
        public async Task<Curso> DeleteAsync(string id)
        {
            var cursoAntigo = 
                await this._dbContext.Cursos.Where(x => x.Id.Equals(id))
                    .FirstOrDefaultAsync();
            if(cursoAntigo != null)
            {
                this._dbContext.Remove(cursoAntigo);
                await this._dbContext.SaveChangesAsync();
                return cursoAntigo;
            }
            return null;
        }
    }
}