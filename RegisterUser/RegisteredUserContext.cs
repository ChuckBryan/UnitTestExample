namespace RegisterUser
{
    using System.Data.Entity;

    public class RegisteredUserContext : DbContext
    {
        public RegisteredUserContext() : this("DefaultConnection")
        {
            
        }
        public RegisteredUserContext(string connection) : base(connection)
        {
            
        }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    }
}