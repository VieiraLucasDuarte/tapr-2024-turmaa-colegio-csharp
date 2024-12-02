using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace microservcursomestrado.Disciplina.Entities.Services
{
    public interface IAulaService
    {
        Task<List<Aula>> GetAulaAsync();
        Task<Aula> CreateAula();

    }
}