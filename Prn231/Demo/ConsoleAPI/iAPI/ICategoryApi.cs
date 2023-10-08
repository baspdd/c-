using ConsoleAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace ConsoleAPI.iAPI
{
    public interface ICategoryApi
    {
        [Get("")]
        Task<List<Category>> GetCategories();

        [Get("/id?id={id}")]
        Task<Category> GetCategoryById(int id);

        [Post("")]
        Task<HttpResponseMessage> AddCategory(Category category);
    }
}
