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
    public class DetailsModel : PageModel
    {
        private readonly HaberBursa.Data.ApplicationDbContext _context;

        public DetailsModel(HaberBursa.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public HaberBursa.Models.News News { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            News = await _context.News.FirstOrDefaultAsync(m => m.ID == id);

            if (News == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
