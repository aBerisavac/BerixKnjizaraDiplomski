using Application;
using Application.Commands.Roles;
using Application.DTOs.Roles;
using Application.Queries.Roles;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public RoleController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetRolesQuery query, [FromQuery] string? RoleName = null)
        {
            return Ok(_executor.ExecuteQuery(query, RoleName));
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRoleQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<RoleController>
        [HttpPost]
        public IActionResult Post([FromBody] RoleDTO useCase, [FromServices] IAddRoleCommand command)
        {
            _executor.ExecuteCommand(command, useCase);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDTO dto, [FromServices] IEditRoleCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRoleCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
