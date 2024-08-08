using System;
using System.ComponentModel.DataAnnotations;

namespace SportsAcademyDen.Models.AcademyViewModels
{
    public class FixtureDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? FixtureDate { get; set; }

        public int PlayerCount { get; set; }
    }
}
