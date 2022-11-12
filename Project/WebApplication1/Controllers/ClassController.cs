using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClassController : Controller
    {
        List<Question> questions = new List<Question>();
        public void set()
        {
            questions.Add(new Question(1, "Are you oke", "of course", "oke", "no", "not", 3));
            questions.Add(new Question(2, "cau2", "of course", "sa", "no", "not", 2));
            questions.Add(new Question(3, "cau3", "of course", "ohehke", "cgeh", "not", 4));
        }
        List<int> ans = new List<int>();
        public IActionResult Index(int index, int selection)
        {
            set();
            Question ret = questions.ElementAt(0);
            ans.Add(selection);
            if (index != null)
            {
                ret = questions.ElementAt(index);
            }
            else
            {
                index = 1;
            }
            if (index + 1 < questions.Count())
            {
                ViewBag.Index = ret.index;
            }

            ViewBag.quest = ret;
            return View();
        }

        public IActionResult submit()
        {
            int ret = 0;
            foreach (Question item in questions)
            {
                if (item.correct == ans.ElementAt(item.index - 1))
                {
                    ret++;
                }
            }
            ViewBag.quest = ret;
            return View();
        }
    }
}
