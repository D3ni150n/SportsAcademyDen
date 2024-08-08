using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;

namespace SportsAcademyDen.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly SportsAcademyDen.Data.SportContext _context;

        public DetailsModel(SportsAcademyDen.Data.SportContext context)
        {
            _context = context;
        }

      public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            Player = await _context.Players
            .Include(s => s.Fixtures)
                .ThenInclude(e => e.Sport)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.PlayerID == id);

            if (Player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = Player;
            }
            return Page();
        }
    }
}
