using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRAssignment.Service;
using System.Text.Json;

namespace SignalRAssignment.Pages.Account
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }

        private AccountDAO accountDAO = new AccountDAO();

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                //Username = Request.Query["Username"].ToString();
                //Password = Request.Query["Password"].ToString();

                var acc = accountDAO.checkAccountLogin(Username, Password);

                if (acc == null)
                {
                    return Page();
                }
                var sessionStr = acc.Type ? "staff" : "customer";
                //var accJson = JsonSerializer.Serialize<Models.Account>(acc);

                HttpContext.Session.SetString(sessionStr, acc.AccountId);

                return RedirectToPage("/Products/Index");


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
