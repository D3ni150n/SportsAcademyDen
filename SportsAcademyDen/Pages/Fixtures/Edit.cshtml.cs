using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Fixtures
{
    public class EditModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public EditModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fixture Fixture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fixtures == null)
            {
                return NotFound();
            }

            var fixture =  await _context.Fixtures.FirstOrDefaultAsync(m => m.FixtureID == id);
            if (fixture == null)
            {
                return NotFound();
            }
            Fixture = fixture;
           ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID");
           ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "SportID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Fixture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FixtureExists(Fixture.FixtureID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FixtureExists(int id)
        {
          return _context.Fixtures.Any(e => e.FixtureID == id);
        }
    }
}
