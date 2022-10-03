using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

List<String> list = new List<string>
    { "pham duc       duy        ",
        "ta dinh       tien",
        "      nguyen duc hoa",
        "vu       manh hung",
        "vu       mai    van       hung",
        "     vu van van hung",
        "nguu           mai yen"
};
int a = 0, b = 0, c = 0;
foreach (var item in list)
{
    String name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToLower());
    String[] s = name.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (s[s.Length - 1].Equals("Yen"))
    {
        a++;
    }
    for (int i = 1; i < s.Length-1; i++)
    {
        if (s[i].Equals("Van"))
        {
            b++;
            break;
        }
    }
    if (s[0].Substring(0,1).Equals("N"))
    {
        c++;
    }
    name = String.Join(" ", s);
    Console.WriteLine(name);
}
Console.WriteLine("Students that first name is Yen: " + a);
Console.WriteLine("have the Van padding: " + b);
Console.WriteLine("students that  their lastnames starting with the letter N : " + c);