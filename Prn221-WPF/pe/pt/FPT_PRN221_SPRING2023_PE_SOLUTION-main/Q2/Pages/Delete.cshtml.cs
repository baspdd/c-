using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Model;

namespace Q2.Pages
{
    public class DeleteModel : PageModel
    {
        private PE_PRN221_Trial3Context context = new PE_PRN221_Trial3Context();
        public IActionResult OnGet(int id)
        {
            var movie = context.Movies
                .Include(m => m.Genres)
                .Include(m=>m.Stars)
                .FirstOrDefault(x => x.Id == id);
            movie.Genres.Clear();
			movie.Stars.Clear();
            context.Movies.Remove(movie);
            context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
