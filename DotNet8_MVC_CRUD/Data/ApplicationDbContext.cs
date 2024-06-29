using DotNet8_MVC_CRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNet8_MVC_CRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
