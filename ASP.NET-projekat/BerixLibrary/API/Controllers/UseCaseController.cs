using Application;
using Application.Commands.UseCases;
using Application.DTOs.UseCases;
using Application.Queries.UseCases;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UseCaseController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public UseCaseController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<UseCaseController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetUseCasesQuery query, [FromQuery] string? UseCaseName = null)
        {
            return Ok(_executor.ExecuteQuery(query, UseCaseName));
        }

        // GET api/<UseCaseController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUseCaseQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<UseCaseController>
        [HttpPost]
        public IActionResult Post([FromBody] UseCaseDTO useCase, [FromServices] IAddUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UseCaseController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UseCaseDTO dto, [FromServices] IEditUseCaseCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<UseCaseController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUseCaseCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
