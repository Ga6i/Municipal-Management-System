using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Municipal_Management_System.Models;

namespace Municipal_Management_System.Controllers
{
    public class ServiceRequestController : Controller
    {
        private static List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

        // GET: ServiceRequest
        public IActionResult Index()
        {
            return View(serviceRequests);
        }

        // GET: ServiceRequest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceRequest/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceRequest request)
        {
            if (ModelState.IsValid)
            {
                request.RequestID = serviceRequests.Count + 1;
                request.RequestDate = DateTime.Now;
                request.Status = "Pending";
                serviceRequests.Add(request);

                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        // GET: ServiceRequest/Details/1
        public IActionResult Details(int id)
        {
            var request = serviceRequests.FirstOrDefault(r => r.RequestID == id);
            if (request == null) return NotFound();
            return View(request);
        }

        // GET: ServiceRequest/UpdateStatus/1
        public IActionResult UpdateStatus(int id)
        {
            var request = serviceRequests.FirstOrDefault(r => r.RequestID == id);
            if (request == null) return NotFound();
            return View(request);
        }

        // POST: ServiceRequest/UpdateStatus/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var request = serviceRequests.FirstOrDefault(r => r.RequestID == id);
            if (request == null) return NotFound();

            request.Status = status;
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceRequest/Delete/1
        public IActionResult Delete(int id)
        {
            var request = serviceRequests.FirstOrDefault(r => r.RequestID == id);
            if (request == null) return NotFound();
            return View(request);
        }

        // POST: ServiceRequest/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var request = serviceRequests.FirstOrDefault(r => r.RequestID == id);
            if (request == null) return NotFound();

            serviceRequests.Remove(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
