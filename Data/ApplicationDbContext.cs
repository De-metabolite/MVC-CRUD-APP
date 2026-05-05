using Microsoft.EntityFrameworkCore;
using CRUD_APP_MVC.Entities;

namespace CRUD_APP_MVC.Data
{
    public class ApplicationDbContext: DbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> students { get; set; }

    }
}
