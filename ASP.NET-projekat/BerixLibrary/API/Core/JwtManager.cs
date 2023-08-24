using Application.DTOs;
using Domain;
using EFDataAccess;
using Implementation.Password;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Core
{
    public class JwtManager
    {
        private readonly DBKnjizaraContext _dbContext;

        public JwtManager(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string MakeToken(LoginRequestDTO loginParams)
        {
            var user = _dbContext.Users
                .FirstOrDefault(x => x.Email == loginParams.Email);

            if (user == null)
            {
                return null;
            }

            var userUseCases = _dbContext.Roles.Where(r => user.RoleId == r.Id).Select(x => x.UseCases).FirstOrDefault().ToList();

            if (!PasswordHandler.compareHasedPasswords(loginParams.Password, user.Password))
            {
                return null;
            }
            var actor = new JwtActor
            {
                RoleId = user.RoleId,
                AllowedUseCases = userUseCases.Select(x => x.UseCaseId),
                Email = user.Email,
                UserId = user.Id,
            };

            var issuer = "asp_api";
            var secretKey = "ThisIsMyVerySecretKey";
            var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, "asp_api", ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.UserId.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddHours(24),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
