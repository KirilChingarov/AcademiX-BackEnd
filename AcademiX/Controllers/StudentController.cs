using AcademiX.Data;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;
using AcademiX.Services.Contracts;
using AcademiX.Services;

namespace AcademiX.Controllers
{
	public class StudentController : Controller
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		public ActionResult<IEnumerable<Student>> GetAllStudents()
		{
			var student = _studentService.GetAllStudents();

			return View(student);
		}

		public ActionResult<Student> GetStudentById(int id)
		{
			var student = _studentService.GetStudentById(id);

			if (student == null)
			{
				return NotFound();
			}

			return student;
		}

		/*public ActionResult<Student> GetStudentByDegreeId(int degreeId)
		{
			var students = _studentService.GetStudentByDegreeId(degreeId);

			if (students == null)
			{
				return NotFound();
			}

			return students;
		}*/
		
		public ActionResult<Student> CreateStudent(Student student)
		{
			_studentService.CreateStudent(student);

			return CreatedAtAction(nameof(student), new { id = student.Id }, student);
		}

		/*public ActionResult EditEmail(int id, string email)
		{
			var student = GetStudentById(id).Value;

			if (student == null)
			{
				return BadRequest();
			}

			student.Email = email;

			return UpdateStudent(student);
		}*/

		public ActionResult UpdateStudent(Student student)
		{
			if (student == null)
			{
				return BadRequest();
			}

			var success = _studentService.UpdateStudent(student);

			if (success != 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		public ActionResult DeleteStudent(int id)
		{
			var success = _studentService.DeleteStudent(id);

			if (success != 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
