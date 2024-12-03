
using microservcursomestrado.Disciplina.Entities.Command;
using microservcursomestrado.Disciplina.Entities.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservcursomestrado.Disciplina.Entities.Controllers
{
    [ApiController]
    [Route("/api/v1/aula")]
    public class AulaController : ControllerBase
    {
        private IAulaService _service;

        public AulaController(IAulaService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> GetAula()
        {
            var aula = await _service.GetAulaAsync();
            return Results.Ok(aula);
        }

        [HttpPost("create/aula")]
        public async Task<IResult> CreateNota([FromBody] AulaCommand command)
        {
            var result = _service.CreateAula(command);
            return Results.Ok(result);
        }


        [HttpPost("update/aula")]
        public async Task<IResult> UpdateAula([FromBody] AulaCommand command)
        {
            if (command == null || command.IdAula.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            var aula = await _service.UpdateAula(command);
            if (aula == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(aula);
        }

        [HttpDelete("delete/aula/{id}")]
        public async Task<IResult> DeleteAula(string id)
        {
            if (id.Equals(id))
            {
                return Results.BadRequest();
            }

            var aula = this._service.DeleteAula(id);
            if(aula == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(aula);
        }
    }
}