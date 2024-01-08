using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
	public interface IStudentRepository
	{
		public IEnumerable<Student> GetAllStudents();

		public Student GetStudentById(int id);

		//public Student GetStudentByEmail(string email);

		// GetStudentsByDegreeId !
		//public Student GetStudentByThesisId(int id);

		public void CreateStudent(Student student);

		public int UpdateStudent(Student studentToChange, Student student);

		public int DeleteStudent(int id);
	}
}
