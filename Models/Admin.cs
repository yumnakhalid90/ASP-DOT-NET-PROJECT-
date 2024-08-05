using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prac_demo_enitity_framework.Models
{
    public class Admin
    {

        [Key]
        
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Enter your First Name...")]
        [Column(TypeName = "varchar(100)")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        [Column(TypeName = "varchar(50)")]
        public string AdminEmail { get; set; }

        [Required(ErrorMessage = "Please Enter Your Contact")]
        [Column(TypeName = "varchar(100)")]
        public string AdminContact { get; set; }

        [Required(ErrorMessage = "Please Enter Your Age")]
        [Column(TypeName = "varchar(100)")]
        public int AdminAge { get; set; }
        public int AdminDept { get; set; }
        [NotMapped]
        public IFormFile AdminProfile { get; set; }
        [Required]
        public string AdminImg { get; set; }
    }
}
