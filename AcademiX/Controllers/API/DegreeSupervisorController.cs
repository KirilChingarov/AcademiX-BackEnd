using AcademiX.Exceptions;
using AcademiX.Models;
using AcademiX.Services;
using AcademiX.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class DegreeSupervisorController : ControllerBase
	{
		private readonly IDegreeSupervisorService _degreeSupervisorService;

		public DegreeSupervisorController(IDegreeSupervisorService degreeSupervisorService)
		{
			_degreeSupervisorService = degreeSupervisorService;
		}

		[HttpGet("")]
		public IActionResult GetAllDegreeSupervisors()
		{
			var degreeSupervisors = _degreeSupervisorService.GetAllDegreeSupervisors();

			return this.StatusCode(StatusCodes.Status200OK, degreeSupervisors);
		}

		[HttpGet("{id}")]
		public IActionResult GetDegreeSupervisorById(int id)
		{
			try
			{
				var degreeSupervisor = _degreeSupervisorService.GetDegreeSupervisorById(id);

				return this.StatusCode(StatusCodes.Status200OK, degreeSupervisor);
			}
			catch (EntityNotFoundException ex)
			{
				return this.StatusCode(StatusCodes.Status404NotFound, ex.Message);
			}
		}


		[HttpPost("")]
		public ActionResult<DegreeSupervisor> CreateDegreeSupervisor(DegreeSupervisor degreeSupervisor)
		{
			try
			{
				_degreeSupervisorService.CreateDegreeSupervisor(degreeSupervisor);

				return this.StatusCode(StatusCodes.Status201Created, degreeSupervisor);
			}

			catch (DuplicateEntityException ex)
			{
				return this.StatusCode(StatusCodes.Status409Conflict, ex.Message);
			}
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteDegreeSupervisor([FromRoute] int id)
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
	}
}
