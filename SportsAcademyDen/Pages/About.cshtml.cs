using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAcademyDen.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SportContext _context;

        public AboutModel(SportContext context)
        {
            _context = context;
        }

        public IList<Sport> Sports { get; set; }

        public async Task OnGetAsync()
        {
            Sports = await _context.Sports.ToListAsync();
        }
    }
}
