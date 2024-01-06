using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
	public class DegreeSupervisor : User
	{
		[EmailAddress]
		public string Email { get; set; }
		public int Cabinet { get; set; }
		public string WorkingTime { get; set; }
		public bool IsReviewer { get; set; }

		public ICollection<SupervisorSpecialty> SupervisorSpecialties { get; set; }
	}
}
