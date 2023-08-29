using Application;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Languages;
using Application.DTOs.Languages;
using Application.Commands.Languages;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LanguageController : ControllerBase
  {
    private readonly UseCaseExecutor _executor;
    private readonly IApplicationActor _actor;

    public LanguageController(UseCaseExecutor executor, IApplicationActor actor)
    {
      _executor = executor;
      _actor = actor;
    }


    // GET: api/<LanguageController>
    [HttpGet]
    public IActionResult Get([FromServices] IGetLanguagesQuery query, [FromQuery] string? searchTerm = null)
    {
      return Ok(_executor.ExecuteQuery(query, searchTerm));
    }

    // GET api/<LanguageController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id, [FromServices] IGetLanguageQuery query)
    {
      return Ok(_executor.ExecuteQuery(query, id));
    }

    // POST api/<LanguageController>
    [HttpPost]
    public IActionResult Post([FromBody] LanguageDTO useCase, [FromServices] IAddLanguageCommand command)
    {
      _executor.ExecuteCommand(command, useCase);
      return StatusCode(StatusCodes.Status201Created);
    }

    // PUT api/<LanguageController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] LanguageDTO dto, [FromServices] IEditLanguageCommand command)
    {
      dto.Id = id;
      _executor.ExecuteCommand(command, dto);
      return StatusCode(StatusCodes.Status204NoContent);
    }

    // DELETE api/<LanguageController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromServices] IDeleteLanguageCommand command)
    {
      _executor.ExecuteCommand(command, id);
      return NoContent();
    }
  }
}
