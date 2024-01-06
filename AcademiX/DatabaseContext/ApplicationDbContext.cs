using AcademiX.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        /* Add other Database tables as models are made*/ 
        public DbSet<User> Users { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Specialty> Specialties { get; set; }

		//public DbSet<Degree> Degrees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.HasOne(s => s.User)
				.WithMany()
				.HasForeignKey(s => s.Id)
				.OnDelete(DeleteBehavior.Cascade); 

			base.OnModelCreating(modelBuilder);
		}
	}
}