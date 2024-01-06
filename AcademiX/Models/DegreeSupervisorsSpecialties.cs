namespace AcademiX.Models
{
	public class DegreeSupervisorsSpecialties
	{
		public int SupervisorId { get; set; }
		public Supervisor Supervisor { get; set; }

		public int SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }
	}
}
