using System.Collections.Generic;
using System;
using System.IO;
using System.Text.RegularExpressions;
namespace ConsoleApp1;
public class Program
{
    delegate void d(string s);

    static void Main(string[] args)
    {

        //B obj = new B();
        //obj.Print();
        A obj1 = new B();
        obj1.Print();
        Console.WriteLine();
        Program p = new Program();

        static void P(string s)
        {
            Console.WriteLine(s);
        }
        static void S(string s)
        {
            Console.WriteLine(s);

        }
        d d = new d(P);
        d("c");
        d d1 = new d(S);
        d("net");

        List<int> list = new List<int> { 2, 6,7, 5, 1 };
        var r = list.Where(x => (x & 1) == 1);
        Console.WriteLine(r.Sum());    
    }
}









