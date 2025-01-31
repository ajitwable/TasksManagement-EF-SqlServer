using Microsoft.EntityFrameworkCore;
using TasksManagement.Entities;

namespace TasksManagement.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tasks> task { get; set; }
    }
}
