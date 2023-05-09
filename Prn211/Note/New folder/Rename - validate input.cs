
foreach (var item in list)
{
    String name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToLower());
    String[] s = name.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    name = String.Join(" ", s);
}

public static string getString(string v, string nAME_VALID)
        {
            while (true)
            {
                Console.Write(v);
                String ret = Console.ReadLine();
                if (String.IsNullOrEmpty(ret))
                {
                    Console.WriteLine("input can not be empty");
                }
                else if (Regex.Match(ret, nAME_VALID).Success)
                {
                    return ret;
                }
                else
                {
                    Console.WriteLine("Invalid!");
                }
            }
        }

public static double getDouble(string v1, double minValue, double maxValue)
        {
            while (true)
            {
                Console.Write(v1);
                try
                {
                    String input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("input can not be empty");
                    }
                    else
                    {
                        double ret = Double.Parse(input);
                        if (ret > minValue && ret <= maxValue)
                        {
                            return ret;
                        }
                        else
                        {
                            Console.WriteLine("Input must in range (" + minValue + "," + maxValue + "]");
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Input double");
                }

            }
        }

public static int getInt(string v1, int minValue, int maxValue)
        {
            while (true)
            {
                Console.Write(v1);
                try
                {
                    String input = Console.ReadLine();
                    if (String.IsNullOrEmpty(input))
                    {
                        Console.WriteLine("input can not be empty");
                    }
                    else
                    {
                        int ret = int.Parse(input);
                        if (ret >= minValue && ret <= maxValue)
                        {
                            return ret;
                        }
                        else
                        {
                            Console.WriteLine("Input must in range [" + minValue + "," + maxValue + "]");
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Input integer");
                }
            }
        }

public void asc()
        {
            ListP.Sort(delegate (Player x, Player y)
            {
                return x.Shirt_number - y.Shirt_number;
            });
            Console.WriteLine("Sort succesfully");
        }

public void asc2()
        {
            listC.Sort(delegate (Coach x, Coach y)
            {
                if (x.Year_of == 3 && y.Year_of == 3)
                {
                    return y.Salary.CompareTo(x.Salary);
                }
                else
                {
                    return -1;
                }
            });
            ListC.Reverse();
            Console.WriteLine("Sort succesfully");

        }
