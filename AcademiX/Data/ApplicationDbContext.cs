using AcademiX.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }


        //public DbSet<User> User { get; set; }

        public DbSet<DegreeSupervisor> DegreeSupervisors { get; set; }

    }
}
