using Microsoft.EntityFrameworkCore;
using UserManagementSystem.Models;
using UserManagementSystem.Models.Entites;

namespace UserManagementSystem.data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>option):base(option)
        {

        }
        public DbSet<User> User { get; set; }

    }
}
