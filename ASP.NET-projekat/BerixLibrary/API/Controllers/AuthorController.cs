using Application;
using Application.Commands.Authors;
using Application.DTOs.Authors;
using Application.Queries.Authors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public AuthorController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }


        // GET: api/<AuthorController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetAuthorsQuery query, [FromQuery] string? searchTerm = null)
        {
            return Ok(_executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetAuthorQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] AuthorDTO useCase, [FromServices] IAddAuthorCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuthorDTO dto, [FromServices] IEditAuthorCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteAuthorCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
