using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet("")]
		public IActionResult GetAllStudents()
		{
			var students = _studentService.GetAllStudents();

			return this.StatusCode(StatusCodes.Status200OK, students);
		}

		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id)
		{
			try
			{
				var Student = _studentService.GetStudentById(id);

				return this.StatusCode(StatusCodes.Status200OK, Student);
			}
			catch (EntityNotFoundException ex)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
			}
		}

		[HttpPost("")]
		public ActionResult<Student> CreateStudent(Student student)
		{
			try
			{
				_studentService.CreateStudent(student);

				return this.StatusCode(StatusCodes.Status201Created, student);
			}

			catch (DuplicateEntityException ex)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
			}
		}

		[HttpPut("")]
		public IActionResult UpdateStudent([FromBody] Student student)
		{
			try
			{
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
			catch (EntityNotFoundException ex)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);

			}
			catch (DuplicateEntityException ex)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
			}
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteStudent([FromRoute] int id)
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

		// GetStudentByThesisId(int thesisId)
	}
}
