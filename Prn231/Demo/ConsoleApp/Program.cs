using ConsoleApp.Manager;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoryManager manage = new CategoryManager();

            while (true)
            {
                Console.WriteLine("1.Show list Category ");
                Console.WriteLine("2.Search by Id       ");
                Console.WriteLine("3.Search by Name     ");
                Console.WriteLine("4.Add Category       ");
                Console.WriteLine("5.Update Category    ");
                Console.WriteLine("6.Delete Category    ");
                Console.WriteLine("0.Exit               ");
                Console.WriteLine("=====================");
                Console.WriteLine("Choose an option !");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0: Console.WriteLine("bye"); return;
                    case 1: manage.ShowListAsync();             Console.ReadKey(); break;
                    case 2: manage.SearchCategoryAsync();       Console.ReadKey(); break;
                    case 3: manage.SearchCategoryByNameAsync(); Console.ReadKey(); break;
                    case 4: manage.AddCategoryAsync();          Console.ReadKey(); break;
                    case 5: manage.UpdateCategoryAsync();       Console.ReadKey(); break;
                    case 6: manage.DeleteCategoryAsync();       Console.ReadKey(); break;
                }

            }
        }
    }
}