using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Fixtures
{
    public class DetailsModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DetailsModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        public Fixture Fixture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            // Include the related Player and Sport entities
            var fixture = await _context.Fixtures
                .Include(f => f.Player)
                .Include(f => f.Sport)
                .FirstOrDefaultAsync(m => m.FixtureID == id);

            if (fixture == null)
            {
                return NotFound();
            }
            else
            {
                Fixture = fixture;
            }
            return Page();
        }
    }
}
