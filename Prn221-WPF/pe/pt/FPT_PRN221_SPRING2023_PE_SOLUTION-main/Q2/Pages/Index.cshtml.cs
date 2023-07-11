using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Model;

namespace Q2.Pages
{
    public class IndexModel : PageModel
    {
        private PE_PRN221_Trial3Context db = new PE_PRN221_Trial3Context();
        public IList<Model.Movie> Movie { get; set; } = default!;
        public IList<Model.Producer> Producer { get; set; } = default!;
        public void OnGet(int? id)
        {
            Producer = db.Producers.ToList();
            Movie = db.Movies.
                Include(m => m.Stars).
                Include(m => m.Producer).
                Include(m => m.Director).
                ToList();
            if (id!=null)
            {
                Movie = Movie.Where(m=>m.ProducerId==id).ToList();
            }
        }
    }
}
