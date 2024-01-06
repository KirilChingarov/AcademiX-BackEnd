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

		public Student GetStudentByUsername(string username)
		{
			return _repository.GetStudentByUsername(username);
		}

		/*public Student GetStudentByDegreeId(int degreeId)
		{
			try
			{
				return _repository.GetStudentByDegreeId(degreeId);
			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Student with this degree id was not found.");
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

				if (_repository.GetStudentByUsername(student.Username) != null)
				{
					throw new DuplicateEntityException();
				}

				_repository.CreateStudent(student);
			}
			catch (DuplicateEntityException)
			{
				throw new DuplicateEntityException("Student with this username is already created.");
			}
		}

		public int UpdateStudent(Student student)
		{
			try
			{

				var studentToChange = _repository.GetStudentById(student.Id);

				if (_repository.GetStudentByUsername(student.Username) != null)
				{
					throw new DuplicateEntityException();
				}

				return _repository.UpdateStudent(studentToChange, student);

			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Student with this id was not found.");

			}
			catch (DuplicateEntityException)
			{
				throw new DuplicateEntityException("Student with this username is already created.");
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

		public Student GetStudentByDegreeId(int degreeId)
		{
			throw new NotImplementedException();
		}
	}
}
