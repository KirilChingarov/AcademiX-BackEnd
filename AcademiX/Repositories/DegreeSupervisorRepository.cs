using AcademiX.Data;
using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AcademiX.Repositories
{
	public class DegreeSupervisorRepository : IDegreeSupervisorRepository
	{
		private readonly ApplicationDbContext _context;

		public DegreeSupervisorRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{
			_context.DegreeSupervisors.Add(degreeSupervisor);
			_context.SaveChanges();
		}

		public IEnumerable<DegreeSupervisor> GetAllDegreeSupervisors()
		{
			return _context.DegreeSupervisors.ToList();
		}

		public DegreeSupervisor GetDegreeSupervisorById(int id)
		{
			return _context.DegreeSupervisors.Find(id) ?? throw new EntityNotFoundException();
		}

		public DegreeSupervisor GetDegreeSupervisorByUsername(string username)
		{
			return _context.DegreeSupervisors.ToList().Where(degreeSupervisor => degreeSupervisor.Username == username).FirstOrDefault();
		}

		public int DeleteDegreeSupervisor(int id)
		{
			DegreeSupervisor degreeSupervisorToDelete = this.GetDegreeSupervisorById(id);
			_context.DegreeSupervisors.Remove(degreeSupervisorToDelete);
			var success = _context.SaveChanges();
			return success;
		}

		public IEnumerable<DegreeSupervisor> GetDegreeSupervisorsBySpecialtyId(int specialtyId)
		{
			
		}
	}
}
