using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HaberBursa.Data;
using HaberBursa.Models;

namespace HaberBursa.Pages.Writer.News
{
    public class IndexModel : PageModel
    {
        private readonly HaberBursa.Data.ApplicationDbContext _context;

        public IndexModel(HaberBursa.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<HaberBursa.Models.News> News { get;set; }

        public async Task OnGetAsync()
        {
            News = await _context.News.ToListAsync();
        }
    }
}
