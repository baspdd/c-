int n;

do
{
    try
    {
        Console.Write("Enter a number:");

        n = Convert.ToInt32(Console.ReadLine());
        break;
    }
    catch (Exception)
    {
        Console.WriteLine("Invalid");
    }
} while (true);

fun1(n);
fun2(n);
fun3(n);
fun4(n);
fun5(n);

void fun1(int n)
{
    String ret = "";
    Console.Write("Odd composite number: ");
    for (int i = 4; i < n; i++)
    {
        if (i % 2 != 0 && !isPrime(i))
        {
            ret += i + " ";
        }
    }
    if (String.IsNullOrEmpty(ret))
    {
        Console.WriteLine("not found");
        return;
    }
    Console.WriteLine(ret);
}
bool isPrime(int n)
{
    if (n < 2)
    {
        return false;
    }
    for (int i = 2; i <= Math.Sqrt(n); i++)
    {
        if (n % i == 0)
        {
            return false;
        }
    }
    return true;
}

void fun2(int n)
{
    Console.Write("n second prime number: ");
    int x = 2;
    int count = 0;
    while (true)
    {
        if (count == 2 * n)
        {
            break;
        }
        if (isPrime(x))
        {
            count++;
            if (count > n)
            {
                Console.Write(x + " ");
            }
        }
        x++;
    }
    Console.WriteLine();
}
void fun3(int n)
{
    int x = 0, y = 0, z = 0;
    for (int i = 1; i <= n; i++)
    {
        if (i % 3 == 0)
        {
            x++;
        }
        if (i % 4 == 1)
        {
            y++;
        }
        if (i % 10 == 6)
        {
            z++;
        }
    }
    if (true)
    {

    }
    Console.WriteLine("Divide by 3 :" + x);
    Console.WriteLine("Divide 4 with the remainder 1 :" + y);
    Console.WriteLine("The end digit is “6” :" + z);
}
void fun4(int n)
{
    Console.Write(n + " --> ");
    String ret = "";
    int st =(int) n/2;
    while (n > 1)
    {
        if (isPrime(st) && n % st == 0)
        {
            n = n / st;
            ret += st + ".";
        }
        else
        {
            st--;
        }
    }
    ret=ret.Substring(0,ret.Length-1);
    Console.WriteLine(ret);

}
void fun5(int n)
{
    Console.Write(n + " --> ");
    String ret = "";
    int st = 2;
    while (n > 1)
    {
        if (isPrime(st) && n % st == 0)
        {
            n = n / st;
            ret += st + ".";
        }
        else
        {
            st++;
        }
    }
    ret = ret.Substring(0, ret.Length - 1);
    Console.WriteLine(ret);

}


