using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Municipal_Management_System.Models;

namespace Municipal_Management_System.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Staff Dashboard
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
