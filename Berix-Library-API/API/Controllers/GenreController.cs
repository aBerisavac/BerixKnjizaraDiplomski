using Application;
using Application.Commands.Genres;
using Application.DTOs.Genres;
using Application.Queries.Genres;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public GenreController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }


        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetGenresQuery query, [FromQuery] string? searchTerm = null)
        {
            return Ok(_executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetGenreQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreDTO useCase, [FromServices] IAddGenreCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreDTO dto, [FromServices] IEditGenreCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGenreCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
