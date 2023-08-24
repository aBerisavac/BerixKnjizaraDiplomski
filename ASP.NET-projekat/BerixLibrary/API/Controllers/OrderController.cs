using Application.Commands.Users;
using Application.DTOs.Users;
using Application.Queries.Users;
using Application;
using Microsoft.AspNetCore.Mvc;
using Application.Queries.Orders;
using Application.DTOs.Orders;
using Application.Commands.Orders;
using EFDataAccess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        private readonly DBKnjizaraContext _dbKnjizaraContext;

        public OrderController(UseCaseExecutor executor, IApplicationActor actor, DBKnjizaraContext dBKnjizaraContext)
        {
            _executor = executor;
            _actor = actor;
            _dbKnjizaraContext = dBKnjizaraContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetOrdersQuery query, [FromQuery] string? UserName = null)
        {
            if (_actor.RoleId != 1)
            {
                return Ok(_executor.ExecuteQuery(query, UserName).Where(x => x.Customer.Email == _actor.Email));
            }

            return Ok(_executor.ExecuteQuery(query, UserName));
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOrderQuery query)
        {
            if (_actor.RoleId != 1)
            {
                var order = _executor.ExecuteQuery(query, id);
                if (order.Customer.Email == _actor.Email)
                {
                    return Ok(order);
                }
                else
                {
                    return StatusCode(403);
                }
            }

            return Ok(_executor.ExecuteQuery(query, id));
        }


        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderInsertDTO dto, [FromServices] IAddOrderCommand command)
        {
            if (_actor.RoleId != 1)
            {
                dto.CustomerId = _actor.UserId;
            }

            _executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            if(_actor.RoleId!=1 && _dbKnjizaraContext.Orders.Find(id)!=null && _dbKnjizaraContext.Orders.Find(id).CustomerId!= _actor.UserId)
            {
                return StatusCode(403);
            }
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
