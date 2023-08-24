namespace Application
{
        public interface IApplicationActor
        {
            string Email { get; }
            int UserId { get; }
            int RoleId { get; }
            IEnumerable<int> AllowedUseCases { get; }
        }
}