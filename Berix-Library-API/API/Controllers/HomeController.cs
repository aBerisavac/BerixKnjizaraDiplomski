using Application.Commands.Genres;
using Application.DTOs.Genres;
using Application.Queries.Genres;
using Application;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.HomeParagraphs;
using Application.Commands.HomeParagraphs;
using Application.DTOs.HomeParagraphs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HomeController : ControllerBase
  {
    private readonly UseCaseExecutor _executor;
    private readonly IApplicationActor _actor;

    public HomeController(UseCaseExecutor executor, IApplicationActor actor)
    {
      _executor = executor;
      _actor = actor;
    }


    // GET: api/<HomeController>
    [HttpGet]
    public IActionResult Get([FromServices] IGetHomeParagraphsQuery query, [FromQuery] string? searchTerm = null)
    {
      return Ok(_executor.ExecuteQuery(query, searchTerm));
    }

    // GET api/<HomeController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IGetHomeParagraphQuery query)
    {
      return Ok(_executor.ExecuteQuery(query, id));
    }

    // POST api/<HomeController>
    [HttpPost]
    public IActionResult Post([FromBody] HomeParagraphDTO useCase, [FromServices] IAddHomeParagraphCommand command)
    {
      _executor.ExecuteCommand(command, useCase);
      return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<HomeController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] HomeParagraphDTO dto, [FromServices] IEditHomeParagraphCommand command)
    {
      dto.Id = id;
      _executor.ExecuteCommand(command, dto);
      return StatusCode(StatusCodes.Status204NoContent);
    }

    // DELETE api/<HomeController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteHomeParagraphCommand command)
    {
      _executor.ExecuteCommand(command, id);
      return NoContent();
    }
  }
}
