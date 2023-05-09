// See https://aka.ms/new-console-template for more information
using System.Collections.Immutable;
using System.Globalization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");
while (true)
{
    Console.WriteLine("menu");
    Console.WriteLine("1.basic");
    Console.WriteLine("2.arr");
    Console.WriteLine("3.String");
    Console.WriteLine("4.List");
    Console.WriteLine("0.exit");
    Console.WriteLine("chose");

    int option;
    do
    {
        try
        {
            option = Convert.ToInt32(Console.ReadLine());
            if (option >= 0 && option <= 4)
            {
                break;
            }
        }
        catch (Exception)
        {
            Console.WriteLine("invalid");
        }

    } while (true);


    switch (option)
    {
        case 0: { return; }
        case 1: { basic(); break; }
        case 2: { arrDemo(); break; }
        case 3: { strDemo(); break; }
        case 4: { listDemo(); break; }
        default:
            break;
    }
}

void listDemo()
{
    List<String> list = new List<string>
    { "pham duc duy",
        "ta dinh tien",
        "nguyen duc hoa",
        "vu manh hung",
        "vu mai hung" };
    for (int i = 0; i < list.Count; i++)
    {
        list[i] = rewriteString(list[i]);
    }
    List<String> list2 = new List<string>();
  
    foreach (String s in list)
    {
        Console.WriteLine(s);
    }
}

string rewriteString(string item)
{
    item = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToLower());
    String[] s = item.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    String mssv = s[s.Length - 1];
    for (int i = 0; i < s.Length - 1; i++)
    {
        mssv += s[i].Substring(0, 1);
    }
    return mssv;
}

void strDemo()
{
    Console.WriteLine("name :");
    String name = Console.ReadLine().ToLower();
    name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower());//viet hoa chu cai dau
    String[] s = name.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);// slit khoang rong 

    Console.WriteLine(s[0]);
    Console.WriteLine(s[s.Length - 1]);
    String st = "";
    for (int i = 1; i < s.Length - 1; i++)
    {
        st += s[i] + " ";
    }
    Console.WriteLine(st);
    Console.WriteLine(String.Concat(s));
    Console.WriteLine(String.Join(" ",s));

    String mssv = s[s.Length - 1];
    for (int i = 0; i < s.Length-1; i++)
    {
        mssv += s[i].Substring(0, 1);
    }
    Console.WriteLine(mssv);
}

void basic()
{
    Console.WriteLine("input");
    int n = Convert.ToInt32(Console.ReadLine());
    int hh = n / 3600;
    int mm = (n / 60) % 60;
    int ss = n % 60;
    Console.WriteLine(hh + "-" + mm + "-" + ss);
    Console.WriteLine(String.Format("{0}-{1}-{2}", hh, mm, ss));

}
void arrDemo()
{
    int[] a = { 1, 2, 3, 4, 5, 6, };
    Console.WriteLine("mang so nguyen ");
    int min = 15, count = 0;
    foreach (int i in a)
    {
        if (!isPrime(i) && i > 2)
        {
            Console.WriteLine(i + " ");
        }
        if (min > i && (Math.Sqrt(i) == (int)Math.Sqrt(i)))
        {
            min = i;
        }
    }
    Console.WriteLine(min);

}

bool isPrime(int n)
{
    Boolean ret = true;
    if (n < 2) { ret = false; }
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
        {
            ret = false;
        }
    }
    return ret;
}




