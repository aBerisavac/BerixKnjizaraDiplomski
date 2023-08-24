using Application;

namespace Api.Core
{
    public class JwtActor : IApplicationActor
    {
        public string Email { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
