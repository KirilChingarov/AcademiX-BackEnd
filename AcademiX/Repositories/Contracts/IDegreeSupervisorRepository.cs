using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
	public interface IDegreeSupervisorRepository
	{

		//public IEnumerable<DegreeSupervisor> GetDegreeSupervisorsBySpecialtyId(int specialtyId);

		// public IEnumerable<DegreeSupervisor> GetDegreeSupervisorsBySpecialtyName(string specialtyName);

		// Create
		public void CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor);

		// GetAll
		public IEnumerable<DegreeSupervisor> GetAllDegreeSupervisors();

		// GetById
		public DegreeSupervisor GetDegreeSupervisorById(int id);

		public DegreeSupervisor GetDegreeSupervisorByUsername(string username);

		// Update 
		//public int UpdateDegreeSupervisor(DegreeSupervisor degreeSupervisorToChange, DegreeSupervisor degreeSupervisor);

		// Delete
		public int DeleteDegreeSupervisor(int id);

		
		
		// GetByStudentId
		// GetByDegreeId
		// GetBySpecialtyId
		// GetBySpecialtyName
	}
}
