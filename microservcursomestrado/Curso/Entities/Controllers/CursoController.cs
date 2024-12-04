using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using microservcursomestrado.Curso.Entities.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Template;


namespace microservcursomestrado.Curso.Entities.Controllers
{
    [ApiController]
    [Route("/api/v1/curso")]
    public class CursoController : ControllerBase
    {
        private ICursoService _service;
        public CursoController(ICursoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            var listaAlunos = await _service.GetAllAsync();
            return Results.Ok(listaAlunos);
        }

        [HttpPost("/create")]
        public async Task<IResult> Post(Curso curso)
        {
            if (curso == null)
                return Results.BadRequest();

            var cursoSalvo = await _service.SaveAsync(curso);
            return Results.Ok(cursoSalvo);
        }

        [HttpPut("{id}")]
        public async Task<IResult> Put(string id, [FromBody] Curso curso)
        {
            if (curso == null || id.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            curso = await _service.UpdateAsync(id, curso);
            if (curso == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(curso);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(string id)
        {
            if (id.Equals(string.Empty))
            {
                return Results.BadRequest();
            }
            var curso = await this._service.DeleteAsync(id);
            if (curso == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(curso);
        }
    }
}