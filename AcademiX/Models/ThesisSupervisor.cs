using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
	public class ThesisSupervisor : User
	{
		[EmailAddress]
		public string Email { get; set; }
		public int Cabinet { get; set; }
		public string WorkingTime { get; set; }
		public bool IsReviewer { get; set; }

		[Required]
		[ForeignKey("User")]
		public int UserId { get; set; }

		public ICollection<ThesisSupervisorsSpecialties> ThesisSupervisorsSpecialties { get; set; }
	}
}
