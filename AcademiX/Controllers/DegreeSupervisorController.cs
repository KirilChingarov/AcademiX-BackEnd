using AcademiX.Data;
using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
	public class DegreeSupervisorController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DegreeSupervisorController(ApplicationDbContext context)
		{
			_context = context;
		}

		public ActionResult<DegreeSupervisor> CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			_context.DegreeSupervisors.Add(degreeSupervisor);
			_context.SaveChanges();

			return CreatedAtAction(nameof(degreeSupervisor), new { id = degreeSupervisor.Id }, degreeSupervisor);
		}

		public ActionResult<IEnumerable<DegreeSupervisor>> GetAllDegreeSupervisors()
		{
			return _context.DegreeSupervisors.ToList();
		}

		public ActionResult<DegreeSupervisor> GetDegreeSupervisorById(int id)
		{
			var degreeSupervisor = _context.DegreeSupervisors.Find(id);

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			return degreeSupervisor;
		}

		public ActionResult EditEmail(int id, string email)
		{
			var degreeSupervisor = GetDegreeSupervisorById(id).Value;

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			degreeSupervisor.Email = email;

			return UpdateDegreeSupervisor(degreeSupervisor);
		}

		public ActionResult EditCabinet(int id, int cabinet)
		{
			var degreeSupervisor = GetDegreeSupervisorById(id).Value;

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			degreeSupervisor.Cabinet = cabinet;

			return UpdateDegreeSupervisor(degreeSupervisor);
		}

		public ActionResult EditWorkingTime(int id, string workingTime)
		{
			var degreeSupervisor = GetDegreeSupervisorById(id).Value;

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			degreeSupervisor.WorkingTime = workingTime;

			return UpdateDegreeSupervisor(degreeSupervisor);
		}

		public ActionResult SetIsReviewer(int id)
		{
			var degreeSupervisor = GetDegreeSupervisorById(id).Value;

			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			degreeSupervisor.IsReviewer = !degreeSupervisor.IsReviewer;
			return UpdateDegreeSupervisor(degreeSupervisor);
		}

		public ActionResult UpdateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{
			if (degreeSupervisor == null)
			{
				return BadRequest();
			}

			_context.DegreeSupervisors.Update(degreeSupervisor);

			if (_context.SaveChanges() != 0)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		public ActionResult DeleteDegreeSupervisor(int id)
		{
			ActionResult<DegreeSupervisor> degreeSupervisor = GetDegreeSupervisorById(id);

			if (degreeSupervisor.Value == null)
			{
				return BadRequest();
			}

			_context.DegreeSupervisors.Remove(degreeSupervisor.Value);

			if (_context.SaveChanges() != 0)
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
