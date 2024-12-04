using microservcursomestrado.Disciplina.Entities.Command;
using microservcursomestrado.Disciplina.Entities.Services;
using Microsoft.AspNetCore.Mvc;

namespace microservcursomestrado.Disciplina.Entities.Controllers
{
    [ApiController]
    [Route("/api/v1/nota")]
    public class NotaController : ControllerBase
    {
        private INotaService _service;

        public NotaController(INotaService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> GetNota()
        {
            var nota = await _service.GetNotas();
            return Results.Ok(nota);
        }

        [HttpPost("create")]
        public async Task<IResult> CreateNota([FromBody] NotaCommand command)
        {
            var result = _service.CreateNota(command);
            return Results.Ok(result);
        }

        [HttpPost("update/nota")]
        public async Task<IResult> UpdateNota([FromBody] NotaCommand command)
        {
            if (command == null || command.Id.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            var nota = await _service.UpdateNota(command);
            if (nota == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(nota);
        }

        [HttpDelete("delete/nota/{id}")]
        public async Task<IResult> DeleteNota(string id)
        {
            if (id.Equals(id))
            {
                return Results.BadRequest();
            }
            var aula = this._service.DeleteNota(id);
            if (aula == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(aula);
        }
    }
}