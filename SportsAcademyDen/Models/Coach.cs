using System.ComponentModel.DataAnnotations;

namespace SportsAcademyDen.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Coach Address")]
        public string CoachAddress { get; set; }
        public int SportID { get; set; }

        public Sport Sport { get; set; }
    }
}
