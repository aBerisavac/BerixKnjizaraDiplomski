using Application;
using Application.Commands.Books;
using Application.Commands.Users;
using Application.DTOs.Books;
using Application.DTOs.Users;
using Application.Queries.Books;
using Application.Queries.Users;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public UserController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetUsersQuery query, [FromQuery] string? UserName = null)
        {
            if(_actor.RoleId != 1)
            {
                return Ok(_executor.ExecuteQuery(query, UserName).Where(x => x.Email == _actor.Email));
            }

            return Ok(_executor.ExecuteQuery(query, UserName));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetUserQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserInsertDTO dto, [FromServices] IAddUserCommand command)
        {
            if (_actor.RoleId == 3)
            {
                dto.RoleId = 2;
            }

            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserUpdateDTO dto, [FromServices] IEditUserCommand command)
        {
            dto.Id = id;
            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteUserCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
