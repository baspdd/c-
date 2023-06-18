using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SignalRAssignment.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly SignalRAssignment.Models.MyStoreContext dbContext;

        public LoginModel(SignalRAssignment.Models.MyStoreContext context)
        {
            dbContext = context;
        }

        public void OnGet()
        {
        }


        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }


        public async Task OnPostAsync()
        {
            try
            {
                Username = Request.Query["Username"];
                Password = Request.Query["Password"];

                var acc = dbContext.Accounts.FirstOrDefault(acc
                    => acc.UserName.Equals(Username) && acc.Password.Equals(Password));

                if (acc != null)
                {

                }




            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
