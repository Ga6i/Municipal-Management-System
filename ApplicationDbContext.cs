using Microsoft.EntityFrameworkCore;
using Municipal_Management_System.Models;

namespace Municipal_Management_System.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Staff> Staff { get; set; }  // Singular form of 'Staffs'
        public DbSet<Report> Reports { get; set; }
    }
}
