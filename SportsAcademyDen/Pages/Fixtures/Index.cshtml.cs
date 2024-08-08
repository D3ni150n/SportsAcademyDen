using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsAcademyDen.Data;
using SportsAcademyDen.Models;
using Microsoft.Extensions.Configuration;

namespace SportsAcademyDen.Pages.Fixtures
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

        public string TitleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Fixture> Fixture { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Fixture> fixturesIQ = from s in _context.Fixtures
                                             .Include(f => f.Player)
                                             .Include(f => f.Sport)
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                fixturesIQ = fixturesIQ.Where(s => s.FixtureTitle.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    fixturesIQ = fixturesIQ.OrderByDescending(s => s.FixtureTitle);
                    break;
                default:
                    fixturesIQ = fixturesIQ.OrderBy(s => s.FixtureTitle);
                    break;
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            Fixture = await PaginatedList<Fixture>.CreateAsync(
                fixturesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

