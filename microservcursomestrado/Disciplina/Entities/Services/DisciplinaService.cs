using microservcursomestrado.Disciplina.Builder;
using microservcursomestrado.Disciplina.Entities.Command;
using Microsoft.EntityFrameworkCore;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private RepositoryDbContext _dbContext;

        public DisciplinaService(RepositoryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<Disciplina>> GetAllAsync()
            => await this._dbContext.Disciplina.ToListAsync();

        public async Task<Disciplina> CreateDisciplina(DisciplinaCommad disciplina)
        {
            var bdDisciplina = BuilderDisciplina(disciplina);
            await _dbContext.Disciplina.AddAsync(bdDisciplina);
            await _dbContext.SaveChangesAsync();
            disciplina.Id = bdDisciplina.Id.ToString();
            return await CreateHorario(disciplina);
        }

        private async Task<Disciplina> CreateHorario(DisciplinaCommad disciplina)
        {
            var bdHorario = BuilderHorario(disciplina.HorarioCommand);
            await _dbContext.Horario.AddAsync(bdHorario);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Disciplina
                .Where(x => x.Id.Equals(disciplina.Id))
                    .FirstOrDefaultAsync();
        }

        public async Task<Disciplina> UpdateDisciplina(DisciplinaCommad command)
        {
            var disciAntiga =
                await this._dbContext.Disciplina.Where(x => x.Id.Equals(command.Id))
                               .FirstOrDefaultAsync();

            if (disciAntiga != null)
            {
                var disciplina = BuilderDisciplina(command);
                await this._dbContext.SaveChangesAsync();
                return disciplina;
            }
            return null;
        }

        public async Task<Disciplina> DeleteDisciplina(string id)
        {
            var disciplinaAntiga =
                await this._dbContext.Disciplina.Where(x => x.Id.Equals(id))
                .FirstOrDefaultAsync();

            if (disciplinaAntiga != null)
            {
                this._dbContext.Remove(disciplinaAntiga);
                await this._dbContext.SaveChangesAsync();
                return disciplinaAntiga;
            }
            return null;
        }

        public async Task<Horario> UpdateHorario(HorarioCommand command)
        {
            var horAntiga =
                await this._dbContext.Horario.Where(x => x.Id.Equals(command.Id))
                    .FirstOrDefaultAsync();

            if (horAntiga != null)
            {
                var horario = BuilderHorario(command);
                await this._dbContext.SaveChangesAsync();
                return horAntiga;
            }
            return null;
        }

        public async Task<Horario> DeleteHorario(string idHorario)
        {
            var horarioAntigo =
                await this._dbContext.Horario.Where(x => x.Id.Equals(idHorario))
                    .FirstOrDefaultAsync();

            if (horarioAntigo != null)
            {
                this._dbContext.Remove(horarioAntigo);
                await this._dbContext.SaveChangesAsync();
                return horarioAntigo;
            }
            return null;
        }

        private Disciplina BuilderDisciplina(DisciplinaCommad command)
        {
            return new DisciplinaBuilder()
            .ComId(Guid.NewGuid())
            .ComNome(command.Name)
            .Build();
        }

        private Horario BuilderHorario(HorarioCommand command)
        {
            return new HorarioBuilder()
                .ComId(Guid.NewGuid())
                .ComDataInicio(command.DtInicio)
                .ComDataFim(command.DtFim)
                .ComIdDisciplina(command.IdDisciplina)
                .ComSala(command.Sala)
                .Build();
        }
    }
}
