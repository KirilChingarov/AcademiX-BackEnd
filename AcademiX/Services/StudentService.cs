using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Xml.Linq;

namespace AcademiX.Services
{
	public class StudentService : IStudentService
	{

		private readonly IStudentRepository _repository;

		public StudentService(IStudentRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<Student> GetAllStudents()
		{
			return _repository.GetAllStudents();
		}

		public Student GetStudentById(int id)
		{
			try
			{
				return _repository.GetStudentById(id);
			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Student with this id was not found.");

			}
		}

		/*public Student GetStudentByEmail(string email)
		{
			return _repository.GetStudentByEmail(email);
		}*/

		/*public Student GetStudentByThesisId(int thesisId)
		{
			try
			{
				return _repository.GetStudentByThesisId(thesisId);
			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Student with this thesis id was not found.");
			}
		}*/

		public void CreateStudent(Student student)
		{
			try
			{
				var id = _repository.GetAllStudents()
					.OrderByDescending(sp => sp.Id)
					.Select(sp => sp.Id)
					.FirstOrDefault();

				student.Id = ++id;

				_repository.CreateStudent(student);
			}
			catch (Exception)
			{
				throw new Exception();
			}
		}

		public int UpdateStudent(Student student)
		{
			try
			{
				var studentToChange = _repository.GetStudentById(student.Id);

				return _repository.UpdateStudent(studentToChange, student);

			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Student with this id was not found.");

			}
		}

		public int DeleteStudent(int id)
		{
			try
			{
				_repository.GetStudentById(id);

				return _repository.DeleteStudent(id);
			}

			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException();
			}
		}
	}
}
