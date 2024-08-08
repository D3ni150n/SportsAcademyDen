using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Sports
{
    public class DeleteModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DeleteModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sport Sport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }

            var sport = await _context.Sports.FirstOrDefaultAsync(m => m.SportID == id);

            if (sport == null)
            {
                return NotFound();
            }
            else 
            {
                Sport = sport;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sports == null)
            {
                return NotFound();
            }
            var sport = await _context.Sports.FindAsync(id);

            if (sport != null)
            {
                Sport = sport;
                _context.Sports.Remove(Sport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
