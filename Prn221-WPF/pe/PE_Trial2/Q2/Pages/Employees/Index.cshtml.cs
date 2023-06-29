using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;
namespace Q2.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Trial2Context context;
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public IndexModel(PRN221_Trial2Context context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Employees = context.Employees.Include(e => e.Department).ToList();
        }
        public void OnPost(int employeeId)
        {
            var foundEmployee = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (foundEmployee != null)
            {
                var order = context.Orders.Include(o => o.OrderDetails).Where(o => o.EmployeeId == foundEmployee.EmployeeId).ToList();
                foreach (var a in order)
                {
                    context.OrderDetails.RemoveRange(a.OrderDetails);
                }
                context.Orders.RemoveRange(order);
                context.Employees.Remove(foundEmployee);
                context.SaveChanges();
                Employees = context.Employees.Include(e => e.Department).ToList();
            }
            else
            {
                Employees = context.Employees.Include(e => e.Department).ToList();
            }
        }
    }
}