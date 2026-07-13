using Microsoft.EntityFrameworkCore;
using StudentApi.Models;
namespace StudentApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students => Set<Student>();
    }
}
