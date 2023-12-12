using AcademiX.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademiX.Controllers
{
    public class DegreeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create Degree
        [HttpPost]
        public ActionResult CreateDegree(DegreeProject degree)
        {
            _context.CreateDegree(degree);
            return CreatedAtAction(nameof(degree), new {id = degree.Id},degree);
        }

        // Assign Degree Supervisor
        [HttpPost]
        public ActionResult AssignDegreeSupervisor(int degreeId, int supervisorId)
        {
            _context.AssignDegreeSupervisor(degreeId, supervisorId);
            return RedirectToAction("Details", new { id = degreeId });
        }

        // Assign Reviewer
        [HttpPost]
        public ActionResult AssignReviewer(int degreeId, int reviewerId)
        {
            _context.AssignReviewer(degreeId, reviewerId);
            return RedirectToAction("Details", new { id = degreeId });
        }

        // Edit Title and Descriptions
        [HttpPost]
        public ActionResult EditDegreeDetails(int degreeId, string title, string description)
        {
            _context.EditDegreeDetails(degreeId, title, description);
            return RedirectToAction("Details", new { id = degreeId });
        }

        // Edit Status
        [HttpPost]
        public ActionResult EditDegreeStatus(int degreeId, DegreeStatus status)
        {
            _context.EditDegreeStatus(degreeId, status);
            return RedirectToAction("Details", new { id = degreeId });
        }

        // Get Degree by Id
        [HttpGet]
        public ActionResult GetDegreeById(int degreeId)
        {
            var degree = _context.GetDegreeById(degreeId);
            return View(degree);
        }

        // Get Degree by Student Id
        [HttpGet]
        public ActionResult GetDegreeByStudentId(int studentId)
        {
            var degrees = _context.GetDegreesByStudentId(studentId);
            return View(degrees);
        }

        // Get Degrees by Degree Supervisor Id
        [HttpGet]
        public ActionResult GetDegreesBySupervisorId(int supervisorId)
        {
            var degrees = _context.GetDegreesBySupervisorId(supervisorId);
            return View(degrees);
        }

        // Get Degrees by Reviewer Id
        [HttpGet]
        public ActionResult GetDegreesByReviewerId(int reviewerId)
        {
            var degrees = _context.GetDegreesByReviewerId(reviewerId);
            return View(degrees);
        }

        // Update Degree
        [HttpPost]
        public ActionResult UpdateDegree(DegreeProject degree)
        {
            _context.UpdateDegree(degree);
            return RedirectToAction("Details", new { id = degree.Id });
        }

        // Delete Degree
        [HttpPost]
        public ActionResult DeleteDegree(int degreeId)
        {
            _context.DeleteDegree(degreeId);
            return RedirectToAction("Index");
        }
    }
}
