using Application;
using Application.Commands.ShippingMethods;
using Application.DTOs.ShippingMethods;
using Application.Queries.ShippingMethods;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingMethodController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public ShippingMethodController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<ShippingMethodController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetShippingMethodsQuery query, [FromQuery] string? ShippingMethodName = null)
        {
            return Ok(_executor.ExecuteQuery(query, ShippingMethodName));
        }

        // GET api/<ShippingMethodController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetShippingMethodQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<ShippingMethodController>
        [HttpPost]
        public IActionResult Post([FromBody] ShippingMethodDTO useCase, [FromServices] IAddShippingMethodCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<ShippingMethodController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShippingMethodDTO dto, [FromServices] IEditShippingMethodCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<ShippingMethodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteShippingMethodCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
