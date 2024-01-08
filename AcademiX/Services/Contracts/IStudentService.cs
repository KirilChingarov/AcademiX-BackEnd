using AcademiX.Models;

namespace AcademiX.Services.Contracts
{
	public interface IStudentService
	{
		public IEnumerable<Student> GetAllStudents();

		public Student GetStudentById(int id);

		//public Student GetStudentByEmail(string email);

		//public Student GetStudentByThesisId(int thesisId);

		public void CreateStudent(Student student);

		public int UpdateStudent(Student student);

		public int DeleteStudent(int id);
	}
}
