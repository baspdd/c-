using SignalRAssignment.Models;

namespace SignalRAssignment.Service
{
    public class AccountDAO
    {
        private readonly SignalRAssignment.Models.MyStoreContext dbContext;

        public AccountDAO()
        {
            dbContext = new MyStoreContext();
        }

        public string getLatestAccountID()
        {
            try
            {
                string newId;
                var lastAccount = dbContext.Accounts.OrderBy(a => a.AccountId).LastOrDefault();
                if (lastAccount != null)
                {
                    var currentVal = Int32.Parse(lastAccount.AccountId.Substring(4));
                    var nextVal = currentVal + 1;
                    newId = $"CUST{nextVal:D3}";
                }
                else
                {
                    newId = "CUST001"; // Default value if there are no existing accounts
                }
                return newId;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task InsertAccountAsync(Account account)
        {
            try
            {
                Customer customer = new Customer();
                customer.CustomerId = account.AccountId;
                customer.ContactName = account.FullName;
                dbContext.Customers.Add(customer);
                dbContext.Accounts.Add(account);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool checkAccountDuplicate(Account account)
        {
            try
            {
                return dbContext.Accounts.FirstOrDefault(acc => acc.UserName.Equals(account.UserName)) != null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
