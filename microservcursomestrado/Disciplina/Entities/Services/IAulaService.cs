using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Entities.Command;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public interface IAulaService
    {
        Task<List<Aula>> GetAulaAsync();
        Task<Aula> CreateAula(AulaCommand command);
        Task<Aula> UpdateAula(AulaCommand command);
        Task<Aula> DeleteAula(string id);
    }
}