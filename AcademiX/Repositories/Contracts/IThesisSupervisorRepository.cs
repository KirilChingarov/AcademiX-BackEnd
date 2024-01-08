using AcademiX.Models;

namespace AcademiX.Repositories.Contracts
{
	public interface IThesisSupervisorRepository
	{

		//public IEnumerable<DegreeSupervisor> GetDegreeSupervisorsBySpecialtyId(int specialtyId);

		// public IEnumerable<DegreeSupervisor> GetDegreeSupervisorsBySpecialtyName(string specialtyName);

		// Create
		public void CreateThesisSupervisor(ThesisSupervisor thesisSupervisor);

		// GetAll
		public IEnumerable<ThesisSupervisor> GetAllThesisSupervisors();

		// GetById
		public ThesisSupervisor GetThesisSupervisorById(int id);

		public ThesisSupervisor GetThesisSupervisorByUsername(string username);

		// Update 
		//public int UpdateDegreeSupervisor(DegreeSupervisor degreeSupervisorToChange, DegreeSupervisor degreeSupervisor);

		// Delete
		public int DeleteThesisSupervisor(int id);

		// GetBySpecialtyId
		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyId(int specialtyId);

		// GetBySpecialtyName
		public IEnumerable<ThesisSupervisor> GetThesisSupervisorsBySpecialtyName(string specialtyName);

		public int UpdateThesisSupervisor(ThesisSupervisor thesisSupervisorToChange, ThesisSupervisor thesisSupervisor);
		// GetByStudentId
		// GetByDegreeId
		
	}
}
