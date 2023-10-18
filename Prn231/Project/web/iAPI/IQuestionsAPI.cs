using Microsoft.AspNetCore.Components;
using Refit;
using web.Models;

namespace web.iAPI
{
    public interface IQuestionsAPI
    {
        [Get("/Questions/key?key={keyid}")]
        Task<bool> CheckKey(string keyid);


        [Get("/Questions?filter=keyId eq '{keyid}'")]
        Task <List<Question>> GetQuestions(string keyid);


    }
}
