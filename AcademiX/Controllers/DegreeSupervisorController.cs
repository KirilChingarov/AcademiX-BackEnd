using AcademiX.Data;
using AcademiX.Helpers;
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

        public IActionResult Index()
        {
            //var objDegreeSupervisors = _context.DegreeSupervisors.ToList();
            IEnumerable<DegreeSupervisor> objDegreeSupervisors = _context.DegreeSupervisors;
            return View(objDegreeSupervisors);
        }

        public IActionResult Detail(int id)
        {
            DegreeSupervisor degreeSupervisor = _context.DegreeSupervisors.FirstOrDefault(x => x.Id == id);
            return View(degreeSupervisor);
        }

        /*public IActionResult DegreeSuperviserInfo(int userId)
        {
            var degreeSupervisor = _degreeSupervisorService.GetDegreeSupervisorById(userId);

            if (degreeSupervisor == null)
            {
                return NotFound(); // Handle the case where no DegreeSupervisor is found
            }

            return View(degreeSupervisor);
        }*/

        /*public DegreeSupervisor GetDegreeSupervisorById(int userId)
        {
            return _context.DegreeSupervisors.Find(userId);
        }*/
    }
}
