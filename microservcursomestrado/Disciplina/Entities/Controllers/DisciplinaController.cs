using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Disciplina.Entities.Command;
using microservcursomestrado.Disciplina.Entities.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservcursomestrado.Disciplina.Entities.Controllers
{
    [ApiController]
    [Route("/api/v1/disciplina")]
    public class DisciplinaController : ControllerBase
    {
        //Controler Criado para manipular a disciplina e horarios
        private IDisciplinaService _service;

        public DisciplinaController(IDisciplinaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var disciplina = await _service.GetAllAsync();
            return Results.Ok(disciplina);
        }

        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] DisciplinaCommad command)
        {
            var result = _service.CreateDisciplina(command);
            return Results.Ok(result);
        }

        [HttpPut("update")]
        public async Task<IResult> UpdateDisciplina([FromBody] DisciplinaCommad command)
        {
            if (command == null || command.Id.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            var disciplina = await _service.UpdateDisciplina(command);
            if(disciplina == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(disciplina);
        }

        [HttpPut("update/horario")]
        public async Task<IResult> UpdateHorario([FromBody] HorarioCommand command)
        {
            if (command == null || command.Id.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            var horario = await _service.UpdateHorario(command);
            if(horario == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(horario);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IResult> DeleteDisciplina(string id)
        {
            if (id.Equals(id))
            {
                return Results.BadRequest();
            }
            var disciplina = this._service.DeleteDisciplina(id);
            if(disciplina == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(disciplina);
        }

        [HttpDelete("delete/horario/{id}")]
        public async Task<IResult> DeleteHorario(string id)
        {
            if (id.Equals(id))
            {
                return Results.BadRequest();
            }
            var horario = this._service.DeleteHorario(id);
            if(horario == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(horario);
        }
    }
}