using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Coaches
{
    public class DetailsModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DetailsModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }

            // Include the related Sport entity
            var coach = await _context.Coaches
                .Include(c => c.Sport)
                .FirstOrDefaultAsync(m => m.CoachID == id);

            if (coach == null)
            {
                return NotFound();
            }
            else
            {
                Coach = coach;
            }
            return Page();
        }
    }
}

