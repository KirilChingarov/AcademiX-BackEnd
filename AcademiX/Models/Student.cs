using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademiX.Models
{
	public class Student
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[ForeignKey("User")]
		public int UserId { get; set; }
	}
}
