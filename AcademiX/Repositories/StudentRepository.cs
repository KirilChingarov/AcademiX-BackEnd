using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AcademiX.Repositories
{
	public class StudentRepository : IStudentRepository
	{
		private readonly ApplicationDbContext _context;

		public StudentRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Student> GetAllStudents()
		{
			return _context.Students.ToList();
		}

		public Student GetStudentById(int id)
		{
			return _context.Students.Find(id) ?? throw new EntityNotFoundException();
		}

		public Student GetStudentByUsername(string username)
		{
			return _context.Students.ToList().Where(student => student.Username == username).FirstOrDefault();
		}

		// GetStudentsByDegreeId
		/*public Student GetStudentByDegreeId(int degreeId)
		{
			return _context.Degrees.ToList()
				.Where(degree => degree.Id == degreeId)
				.Select(degree => degree.Student)
				.FirstOrDefault();
		}*/

		public void CreateStudent(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
		}

		public int UpdateStudent(Student studentToChange, Student student)
		{
			_context.Entry(studentToChange).CurrentValues.SetValues(student);
			var success = _context.SaveChanges();
			return success;
		}

		public int DeleteStudent(int id)
		{
			Student studentToDelete = this.GetStudentById(id);
			_context.Students.Remove(studentToDelete);
			var success = _context.SaveChanges();
			return success;
		}
	}
}
