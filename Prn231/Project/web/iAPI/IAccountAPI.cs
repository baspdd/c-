using Refit;
using web.Models;

namespace web.iAPI
{

    public interface IAccountAPI
    {
        [Get("/Accounts?filter=accountId eq '{accid}' and password eq '{password}'")]
        Task <List<Account>> GetAcc(string accid ,string password);
    }
}
