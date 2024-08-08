using System.ComponentModel.DataAnnotations;

namespace SportsAcademyDen.Models
{
    public class Fixture
    {
        public int FixtureID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fixture Title")]
        public string FixtureTitle { get; set; }
        public int PlayerID { get; set; }
        public int SportID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fixture Location")]
        public string FixtureLocation { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Fixture Status")]
        public string FixtureStatus { get; set; }

        public Player Player { get; set; }
        public Sport Sport { get; set; }
    }
}
