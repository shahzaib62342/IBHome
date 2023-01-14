using IBHome.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IBHome.API.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
