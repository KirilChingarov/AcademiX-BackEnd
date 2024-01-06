using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Repositories;
using AcademiX.Repositories.Contracts;
using AcademiX.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace AcademiX.Services
{
	public class DegreeSupervisorService : IDegreeSupervisorService
	{
		private readonly IDegreeSupervisorRepository _repository;

		public DegreeSupervisorService(IDegreeSupervisorRepository repository)
		{
			_repository = repository;
		}

		public IEnumerable<DegreeSupervisor> GetAllDegreeSupervisors()
		{
			return _repository.GetAllDegreeSupervisors();
		}

		public DegreeSupervisor GetDegreeSupervisorByUsername(string username)
		{
			return _repository.GetDegreeSupervisorByUsername(username);
		}

		public void CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{
			try
			{
				var id = _repository.GetAllDegreeSupervisors()
					.OrderByDescending(sp => sp.Id)
					.Select(sp => sp.Id)
					.FirstOrDefault();

				degreeSupervisor.Id = ++id;

				if (_repository.GetDegreeSupervisorByUsername(degreeSupervisor.Username) != null)
				{
					throw new DuplicateEntityException();
				}

				_repository.CreateDegreeSupervisor(degreeSupervisor);
			}
			catch (DuplicateEntityException)
			{
				throw new DuplicateEntityException("DegreeSupervisor with this username is already created.");
			}
		}

		public DegreeSupervisor GetDegreeSupervisorById(int id)
		{
			try
			{
				return _repository.GetDegreeSupervisorById(id);
			}
			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException("Degree supervisor with this id was not found.");

			}
		}

		public int DeleteDegreeSupervisor(int id)
		{
			try
			{
				_repository.GetDegreeSupervisorById(id);

				return _repository.DeleteDegreeSupervisor(id);
			}

			catch (EntityNotFoundException)
			{
				throw new EntityNotFoundException();
			}
		}


		// Update
		// GetByStudentId
		// GetByDegreeId
		// GetBySpecialtyId
		// GetBySpecialtyName
	}
}
