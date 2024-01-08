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
		public DbSet<ThesisSupervisor> ThesisSupervisors { get; set; }
		public DbSet<Specialty> Specialties { get; set; }
		public DbSet<ThesisSupervisorsSpecialties> ThesisSupervisorsSpecialties { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ThesisSupervisorsSpecialties>()
				.HasKey(ss => new { ss.ThesisSupervisorId, ss.SpecialtyId });

			modelBuilder.Entity<ThesisSupervisorsSpecialties>()
				.HasOne(ss => ss.ThesisSupervisor)
				.WithMany(s => s.ThesisSupervisorsSpecialties)
				.HasForeignKey(ss => ss.ThesisSupervisorId);

			modelBuilder.Entity<ThesisSupervisorsSpecialties>()
				.HasOne(ss => ss.Specialty)
				.WithMany(s => s.ThesisSupervisorsSpecialties)
				.HasForeignKey(ss => ss.SpecialtyId);
		}
	}
}