using System.ComponentModel.DataAnnotations;

namespace Municipal_Management_System.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }  // Primary Key, Auto-increment

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }  // Staff member's full name

        [Required]
        [StringLength(50)]
        public string Position { get; set; }  // Job position (e.g., Manager, Clerk, Engineer)

        [Required]
        [StringLength(100)]
        public string Department { get; set; }  // Department the staff belongs to

        [Required]
        [EmailAddress]
        public string Email { get; set; }  // Unique email address for login and contact

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }  // Contact number of the staff member

        [Required]
        public DateTime HireDate { get; set; }  // Date when the staff was hired
    }
}
