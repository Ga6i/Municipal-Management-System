using Microsoft.AspNetCore.Mvc;
using Municipal_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Municipal_Management_System.Data;

namespace Municipal_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(string userType, string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Message = "Please enter both email and password.";
                return View();
            }

            if (userType == "Citizen")
            {
                // Ensure Citizens collection is not null and query properly
                var citizen = await _context.Citizens
                                            .FirstOrDefaultAsync(c => c.Email == email);

                if (citizen == null)
                {
                    ViewBag.Message = "No citizen found with that email address.";
                    return View();
                }

                if (citizen != null && password == "user123")  // Compare with actual stored password
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid password for the citizen.";
                    return View();
                }
            }
            else if (userType == "Staff")
            {
                // Ensure Staff collection is not null and query properly
                var staffMember = await _context.Staff
                                                .FirstOrDefaultAsync(s => s.Email == email);

                if (staffMember == null)
                {
                    ViewBag.Message = "No staff member found with that email address.";
                    return View();
                }

                if (staffMember != null && password == "password123")  // Compare with actual stored password
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Message = "Invalid password for the staff.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Invalid user type selected.";
                return View();
            }
        }


        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        public async Task<IActionResult> Register(string userType, string fullName, string email, string phoneNumber, string address, DateTime? dateOfBirth, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match!";
                return View();
            }

            // Check if email already exists in the database
            var existingCitizen = await _context.Citizens.FirstOrDefaultAsync(c => c.Email == email);
            if (existingCitizen != null)
            {
                ViewBag.Message = "Email is already registered. Please use a different email.";
                return View();
            }

            // Create new Citizen object
            var citizen = new Citizen
            {
                FullName = fullName,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address,
                DateOfBirth = dateOfBirth,
                RegistrationDate = DateTime.Now
            };

            // Save Citizen to the database
            _context.Citizens.Add(citizen);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Registration successful! You can now log in.";
            return View();
        }
    }
}
