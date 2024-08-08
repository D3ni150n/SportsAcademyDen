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

namespace SportsAcademyDen.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public EditModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FindAsync(id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var playerToUpdate = await _context.Players.FindAsync(id);

            if (playerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Player>(
                playerToUpdate,
                "player",
                s => s.FirstMidName, s => s.LastName, s => s.FixtureDate, s => s.DateOfBirth, s => s.ContactNumber))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PlayerExists(int id)
        {
          return _context.Players.Any(e => e.PlayerID == id);
        }
    }
}
