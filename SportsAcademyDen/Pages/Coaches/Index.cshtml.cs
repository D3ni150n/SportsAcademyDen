using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;
using Microsoft.Extensions.Configuration;

namespace SportsAcademyDen.Pages.Coaches
{
    public class IndexModel : PageModel
    {
        private readonly SportContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(SportContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Coach> Coach { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Coach> coachesIQ = from c in _context.Coaches
                                          .Include(c => c.Sport)
                                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                coachesIQ = coachesIQ.Where(c => c.FirstName.Contains(searchString)
                                               || c.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    coachesIQ = coachesIQ.OrderByDescending(c => c.LastName);
                    break;
                default:
                    coachesIQ = coachesIQ.OrderBy(c => c.LastName);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            Coach = await PaginatedList<Coach>.CreateAsync(
                coachesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

