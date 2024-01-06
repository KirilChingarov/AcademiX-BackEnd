using AcademiX.Data;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;
using AcademiX.Services.Contracts;
using AcademiX.Services;

namespace AcademiX.Controllers
{
	public class DegreeSupervisorController : Controller
	{
		private readonly IDegreeSupervisorService _degreeSupervisorService;

		public DegreeSupervisorController(IDegreeSupervisorService degreeSupervisorService)
		{
			_degreeSupervisorService = degreeSupervisorService;
		}

		public ActionResult<IEnumerable<DegreeSupervisor>> GetAllDegreeSupervisors()
		{
			var degreeSupervisor = _degreeSupervisorService.GetAllDegreeSupervisors();

			return View(degreeSupervisor);
		}

		public ActionResult<DegreeSupervisor> GetDegreeSupervisorById(int id)
		{
			var degreeSupervisor = _degreeSupervisorService.GetDegreeSupervisorById(id);

			if (degreeSupervisor == null)
			{
				return NotFound();
			}

			return degreeSupervisor;
		}

		public ActionResult<DegreeSupervisor> CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{
			_degreeSupervisorService.CreateDegreeSupervisor(degreeSupervisor);

			return CreatedAtAction(nameof(degreeSupervisor), new { id = degreeSupervisor.Id }, degreeSupervisor);
		}

		public ActionResult DeleteDegreeSupervisor(int id)
		{
			var success = _degreeSupervisorService.DeleteDegreeSupervisor(id);

			if (success != 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
