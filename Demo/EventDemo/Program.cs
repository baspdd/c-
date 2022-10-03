using static System.Net.Mime.MediaTypeNames;

namespace EventDemo;

public class Program
{
    static int n;
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number text :");
        n = Convert.ToInt32(Console.ReadLine());
        // mô phỏng sự kiện nhấn nút
        Console.WriteLine("Press the Create button to create text !");
        Console.ReadKey();

        //tạo nút
        Button btnCreate = new Button("Create");

        //gán sự kiện cho nút
        btnCreate.onClick += BtnCreate_onClick;

        //nhấn nút
        btnCreate.click();

        Console.WriteLine("Press the Add button to add Checkbox");
        Console.ReadKey();
        Button btnAdd = new Button("Add");
        btnAdd.onClick += BtnAdd_onClick;
        btnAdd.click();

        while (true)
        {
            Console.WriteLine("Enter a checkbox to change ");
            int c = Convert.ToInt32(Console.ReadLine());
            if (c > n + 1)
            {
                break;
            }
            Console.WriteLine("0.check");
            Console.WriteLine("1.uncheck");
            int opt = Convert.ToInt32(Console.ReadLine());
            if (opt == 0)
            {
                listChechBox[c - 1].check = true;
            }
            else { listChechBox[c - 1].check = false; }
        }
        while (true)
        {
            Console.WriteLine("Enter a num to change ");
            int c = Convert.ToInt32(Console.ReadLine());
            if (c > n + 1)
            {
                break;
            }
            Console.WriteLine("New text ");
            String s = Console.ReadLine();
            listText[c - 1].Text = s;
        }
        foreach (var item in listText)
        {
            Console.WriteLine(item.Text);
        }
    }

    static List<CheckBox> listChechBox = new List<CheckBox>();
    private static void BtnAdd_onClick()
    {
        Console.WriteLine();
        // viết code xử lý việc xảy ra khi nhấn nút
        for (int i = 0; i < n; i++)
        {
            CheckBox box = new CheckBox();
            box.CheckChange += Box_CheckChange;
            box.text = listText[i].Text;
            listChechBox.Add(box);
            Console.WriteLine("- Check " + (i + 1) + ": " + box.text);
        }
    }

    private static void Box_CheckChange(string text, bool check)
    {
        Console.WriteLine("Check " + text + " " + ((check) ? "Checked " : " Unchecked "));
    }



    static List<TextBox> listText = new List<TextBox>();
    private static void BtnCreate_onClick()
    {
        Console.WriteLine();
        // viết code xử lý việc xảy ra khi nhấn nút
        for (int i = 0; i < n; i++)
        {
            TextBox t = new TextBox();
            Console.WriteLine("Enter text " + (i + 1) + ":");
            t.textChange += T_textChange;
            t.Text = Console.ReadLine();
            listText.Add(t);
        }
        Console.WriteLine("List text :");
        foreach (var item in listText)
        {
            Console.WriteLine("Text :" + item.Text);
        }
    }

    private static void T_textChange()
    {
        Console.WriteLine("Checked");
    }
}