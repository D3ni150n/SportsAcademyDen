using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Players
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
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPlayer = new Player();

            if (await TryUpdateModelAsync<Player>(
                emptyPlayer,
                "player",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.FixtureDate, s => s.DateOfBirth, s => s.ContactNumber))
            {
                _context.Players.Add(emptyPlayer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
