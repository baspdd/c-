using Refit;
using web.Models;

namespace web.iAPI
{

    public interface IQuestionsAPI
    {
        [Get("/Questions?keyid={keyid}")]
        Task <List<Question>> GetQuestions(string keyid);
    }
}
