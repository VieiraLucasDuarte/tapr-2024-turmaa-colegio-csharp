using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Builder;
using microservcursomestrado.Disciplina.Entities.Command;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public interface IDisciplinaService
    {
        Task<List<Disciplina>> GetAllAsync();
        Task<Disciplina> CreateDisciplina(DisciplinaCommad disciplina);
        Task<Horario> UpdateHorario(HorarioCommand command);
        Task<Horario> DeleteHorario(string idHorario);
        Task<Disciplina> UpdateDisciplina(DisciplinaCommad command);
        Task<Disciplina> DeleteDisciplina(string id);
    }
}