using Microsoft.EntityFrameworkCore;

namespace RestAPisUserCore.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Users> users { get; set; }
    }
}
