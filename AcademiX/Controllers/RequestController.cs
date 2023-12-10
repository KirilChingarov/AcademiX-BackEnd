using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademiX.Models;
using AcademiX.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AcademiX.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Create
        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            _context.CreateRequest(request);
            return RedirectToAction("Index");
        }

        //Send
        [HttpPost]
        public ActionResult Send(int id)
        {
            var request = _context.GetRequestById(id);
            if (request == null)
            {
                return BadRequest();
            }

            _context.SendRequest(id);
            return RedirectToAction("Index");
        }

        //Request by Id
        [HttpGet]
        public ActionResult Details(int id)
        {
            var request = _context.GetRequestById(id);
            if (request == null)
            {
                return BadRequest();
            }

            return View(request);
        }

        //Requests by Student
        public ActionResult RequestsByStudent(int studentId)
        {
            var requests = _context.GetRequestsByStudentId(studentId);
            return View(requests);
        }

        //Requests by Supervisor
        [HttpGet]
        public ActionResult RequestsBySupervisor(int supervisorId)
        {
            var requests = _context.GetRequestsByDegreeSupervisorId(supervisorId);
            return View(requests);
        }

        //Request Accept
        [HttpPost]
        public ActionResult Accept(int id)
        {
            var request = _context.GetRequestById(id);
            if (request == null)
            {
                return BadRequest();
            }

            _context.AcceptRequest(id);
            return RedirectToAction("Index");
        }

        //Request Deny
        [HttpPost]
        public ActionResult Deny(int id)
        {
            var request = _context.GetRequestById(id);
            if (request == null)
            {
                return BadRequest();
            }

            _context.DenyRequest(id);
            return RedirectToAction("Index");
        }

        //Request Update
        [HttpPost]
        public ActionResult Update(Request request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            _context.UpdateRequest(request);
            return RedirectToAction("Index");
        }

        //Request Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _context.DeleteRequest(id);
            return RedirectToAction("Index");
        }
    }
}
