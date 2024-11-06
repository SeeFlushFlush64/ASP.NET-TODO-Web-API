using Microsoft.EntityFrameworkCore;
using TODOWebAPI.Models.Entities;

namespace TODOWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> Tasks { get; set; }
    }
}
