using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Services.Contracts
{
	public interface IDegreeSupervisorService
	{
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
