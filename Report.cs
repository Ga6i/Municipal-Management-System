using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Municipal_Management_System.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }  // Primary Key, Auto-increment

        [Required]
        [ForeignKey("Citizen")]
        public int CitizenID { get; set; }  // Foreign Key referencing Citizens table

        public Citizen Citizen { get; set; }  // Navigation property for related Citizen data

        [Required]
        [StringLength(100)]
        public string ReportType { get; set; }  // Type of report (e.g., Complaint, Inquiry, Maintenance)

        [Required]
        public string Details { get; set; }  // Detailed description of the report

        public DateTime SubmissionDate { get; set; } = DateTime.Now;  // Default to current date

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Under Review";  // Default status of report
    }
}
