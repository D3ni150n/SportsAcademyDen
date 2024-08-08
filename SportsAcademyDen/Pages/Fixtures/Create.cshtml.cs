using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Fixtures
{
    public class CreateModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public CreateModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PlayerID"] = new SelectList(_context.Players, "PlayerID", "PlayerID");
        ViewData["SportID"] = new SelectList(_context.Sports, "SportID", "SportID");
            return Page();
        }

        [BindProperty]
        public Fixture Fixture { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fixtures.Add(Fixture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
