using Api.Core;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager jwtManager;

        public TokenController(JwtManager jwtManager)
        {
            this.jwtManager = jwtManager;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequestDTO loginParams)
        {
            var token = jwtManager.MakeToken(loginParams);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }

    }
}
