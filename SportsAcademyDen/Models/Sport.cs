using System.ComponentModel.DataAnnotations;

namespace SportsAcademyDen.Models
{
    public class Sport
    {
        public int SportID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Sport Name")]
        public string SportName { get; set; }
    }
}
