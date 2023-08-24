using Application;
using Application.Queries.Logs;
using Application.Queries.Orders;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public LogController(UseCaseExecutor executor, IApplicationActor actor)
        {
            _executor = executor;
            _actor = actor;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetLogsQuery query, [FromQuery] string? UseCaseName = null)
        {
            return Ok(_executor.ExecuteQuery(query, UseCaseName));
        }
    }
}
