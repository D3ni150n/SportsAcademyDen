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
    public class DeleteModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DeleteModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fixture Fixture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            var fixture = await _context.Fixtures.FirstOrDefaultAsync(m => m.FixtureID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }
            var fixture = await _context.Fixtures.FindAsync(id);

            if (fixture != null)
            {
                Fixture = fixture;
                _context.Fixtures.Remove(Fixture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
