using System;
using System.Dynamic;

namespace DelegateLamba;
public class Program
{
    //khai bao delegate
    delegate void MyDelegate1(int a, int b);
    delegate bool MyDelegate2(int a);

    static void Main(string[] args)
    {
        Console.WriteLine("Heelooosadksa");
        Console.WriteLine();
        // khi chua su dung delegate
        Tong(4, 6);
        ucln(24, 16);
        so(4, 6);
        // sử dụng delegate
        Console.WriteLine("using delegate");
        MyDelegate1 my = new MyDelegate1(Tong);
        my += ucln;
        my += so;
        my(4, 6);

        my -= ucln;
        my(24, 16);

        // cách tạo delegate số 2
        MyDelegate2 my2 = delegate (int n)
        {
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }

            }
            return true;
        };
        if (my2(7))
        {
            Console.WriteLine("true");
        }
        // c2 thành biểu thức lambda
        MyDelegate2 my3 = n =>
        {
            int count = 0;
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    count++;
                }

            }
            return count == 1;
        };
        Console.WriteLine(my3(7));
    }
    static void Tong(int a, int b)
    {
        Console.WriteLine("a+b = " + (a + b));
    }
    static void ucln(int a, int b)
    {
        while (a != b)
        {
            if (a > b) a = a - b;
            else b = b - a;
        }
        Console.WriteLine("ucln " + b);
    }
    static void so(int a, int b)
    {
        if (a == b) Console.WriteLine("==");
        if (a > b) Console.WriteLine(">");
        if (a < b) Console.WriteLine("<");


    }
}