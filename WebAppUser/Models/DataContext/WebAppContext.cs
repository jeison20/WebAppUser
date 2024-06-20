using Microsoft.EntityFrameworkCore;

namespace WebAppUser.Models.DataContext
{
    public class WebAppContext : DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
