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
    public class DeleteModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DeleteModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }

            var coach = await _context.Coaches.FirstOrDefaultAsync(m => m.CoachID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coaches == null)
            {
                return NotFound();
            }
            var coach = await _context.Coaches.FindAsync(id);

            if (coach != null)
            {
                Coach = coach;
                _context.Coaches.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
