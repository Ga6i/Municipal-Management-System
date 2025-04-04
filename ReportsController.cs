using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Municipal_Management_System.Data;
using Municipal_Management_System.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Municipal_Management_System.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reports
        public async Task<IActionResult> Index()
        {
            var reports = await _context.Reports.Include(r => r.Citizen).ToListAsync();
            return View(reports);


        }

        // GET: Reports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        // GET: Reports/ReviewReport/5
        public async Task<IActionResult> ReviewReport(int id)
        {
            var report = await _context.Reports.Include(r => r.Citizen).FirstOrDefaultAsync(r => r.ReportID == id);
            if (report == null)
            {
                return NotFound();
            }
            return View(report);
        }

        // POST: Reports/ReviewReport
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReviewReport(int ReportID, string Status)
        {
            var report = await _context.Reports.FindAsync(ReportID);
            if (report == null)
            {
                return NotFound();
            }

            report.Status = Status;
            _context.Update(report);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Reports/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var report = await _context.Reports.Include(r => r.Citizen).FirstOrDefaultAsync(r => r.ReportID == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }

        // POST: Reports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
