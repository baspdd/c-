using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Models;
using SignalRAssignment.Service;

namespace SignalRAssignment.Pages.Account
{
    public class RegisterModel : PageModel
    {


        AccountDAO accountDAO = new AccountDAO();

        public void OnGet()
        {
            ViewData["newID"] = accountDAO.getLatestAccountID();
        }

        [BindProperty]
        public SignalRAssignment.Models.Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Account == null || accountDAO.checkAccountDuplicate(Account))
            {
                return Page();
            }

            Customer customer = new Customer();

            accountDAO.InsertAccountAsync(Account);

            return RedirectToPage("/Index");
        }

    }
}
