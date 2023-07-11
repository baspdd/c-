using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Model;

namespace Q2.Pages
{
    public class DeleteModel : PageModel
    {
        private PE_PRN221_Trial3Context context = new PE_PRN221_Trial3Context();
        public void OnGet(int id)
        {
            var movie = context.Movies.FirstOrDefault(x => x.Id == id);
            context.Movies.Remove(movie);
            context.SaveChanges();
        }
    }
}
