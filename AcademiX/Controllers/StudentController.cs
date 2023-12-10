using AcademiX.Data;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
	public class StudentController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StudentController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult<Student> CreateStudent(Student student)
		{

			if (student == null)
			{
				return BadRequest();
			}

			_context.Students.Add(student);
			_context.SaveChanges();

			return CreatedAtAction(nameof(student), new { id = student.Id }, student);
		}

		public ActionResult<Student> GetStudentById(int id)
		{
			var student = _context.Students.Find(id);

			if (student == null)
			{
				return BadRequest();
			}

			return student;
		}

		//Suppose we have Database table Degrees
		public ActionResult<Student> GetStudentByDegreeId(int degreeId)
		{
			var degree = _context.Degrees.Find(degreeId);

			if (degree == null)
			{
				return BadRequest();
			}

			var student = degree.Student;

			return student;
		}

		public ActionResult<IEnumerable<Student>> GetAllStudents()
		{
			return _context.Students.ToList();
		}

		public ActionResult EditEmail(int id, string email)
		{
			var student = GetStudentById(id).Value;

			if (student == null)
			{
				return BadRequest();
			}

			student.Email = email;

			return UpdateStudent(student);
		}

		public ActionResult UpdateStudent(Student student)
		{
			if (student == null)
			{
				return BadRequest();
			}

			_context.Students.Update(student);

			if (_context.SaveChanges() != 0)
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
			ActionResult<Student> student = GetStudentById(id);

			if (student.Value == null)
			{
				return BadRequest();
			}

			_context.Students.Remove(student.Value);

			if (_context.SaveChanges() != 0)
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
