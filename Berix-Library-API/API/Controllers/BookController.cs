using Application;
using Application.Commands.Authors;
using Application.Commands.Books;
using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.Queries.Authors;
using Application.Queries.Books;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public BookController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }


        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetBooksQuery query, [FromQuery] string? searchTerm = null)
        {
            return Ok(_executor.ExecuteQuery(query, searchTerm));
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetBookQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] BookInsertDTO useCase, [FromServices] IAddBookCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookUpdateDTO dto, [FromServices] IEditBookCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteBookCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
