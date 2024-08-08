using SportsAcademyDen.Data;
using SportsAcademyDen.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SportsAcademyDen.Pages.Sports
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;

        public IndexModel(SportContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Sport> Sports { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                currentFilter = searchString;
            }

            CurrentFilter = currentFilter;

            IQueryable<Sport> sportsIQ = from s in _context.Sports
                                         select s;

            if (!String.IsNullOrEmpty(CurrentFilter))
            {
                sportsIQ = sportsIQ.Where(s => s.SportName.Contains(CurrentFilter));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    sportsIQ = sportsIQ.OrderByDescending(s => s.SportName);
                    break;
                default:
                    sportsIQ = sportsIQ.OrderBy(s => s.SportName);
                    break;
            }

            Sports = await sportsIQ.AsNoTracking().ToListAsync();
        }
    }
}
