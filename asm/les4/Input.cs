using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace les4
{
    internal class Input
    {
        public static String getCode()
        {
            while (true)
            {
                Console.Write("code :");
                String ret = Console.ReadLine().ToLower();
                if (String.IsNullOrEmpty(ret))
                {
                    Console.WriteLine("input can not be empty");
                }
                else if (Regex.Match(ret, "[A-Za-z0-9]+").Success)
                {
                    return ret;
                }
                else
                {
                    Console.WriteLine("Invalid!");
                }

            }
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

        public static string getPos()
        {
            while (true)
            {
                String ret = getString("Input position :", "[a-zA-Z]+").ToUpper();
                switch (ret)
                {
                    case "ST": return "ST";
                    case "MD": return "MD";
                    case "DF": return "DF";
                    case "GK": return "GK";
                    default: Console.WriteLine("Position can be ST ,MD ,DF ,GK"); break;
                }
            }
        }
    }
}
