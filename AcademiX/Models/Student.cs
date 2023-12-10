using System.ComponentModel.DataAnnotations;

namespace AcademiX.Models
{
	public class Student : User
	{
		[EmailAddress]
		public string Email { get; set; }
	}

	// public virtual ICollection<Degree> Degrees { get; set; }
	// public virtual ICollection<Request> Requests { get; set; }
}
