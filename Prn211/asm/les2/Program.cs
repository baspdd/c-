List<Int32> a = new List<Int32> { 15, 37, 16, 84, 25, 127, 100, 125, 0, 7 };

f1(a);
f2(a);

void f2(List<int> a)
{
    List<Int32> b = new List<int>();
    foreach (var item in a)
    {
        if (isSquare(item))
        {
            b.Add(item);
        }
    }

    if (!b.Any())
    {
        Console.WriteLine("not found");
        return;
    }
    b.Sort();
    b.Reverse();
    Console.Write("list square numbers :");
    foreach (var item in b)
    {
        Console.Write(item + " ");
    }
}

void f1(List<int> a)
{
    Console.Write("All prime numbers : ");
    String ret = "";
    int x = 0, y = 0;
    foreach (var item in a)
    {
        if (isPrime(item))
        {
            ret += item + " ";
            x++;
        }
        else if (item > 2)
        {
            y++;
        }
    }
    print(ret);
    Console.WriteLine("prime numbers : " + x);
    Console.WriteLine("composite numbers : " + y);
}

bool isSquare(int item)
{
    if (item < 4)
    {
        return false;

    }
    if (Math.Sqrt(item) == (int)Math.Sqrt(item))
    {
        return true;
    }
    return false;
}

void print(string ret)
{
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
