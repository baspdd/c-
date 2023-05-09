using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace les4
{
    internal class Manage : iManager
    {
        private List<Player> listP;
        private List<Coach> listC;
        public Manage()
        {

        }

        public Manage(List<Player> listP, List<Coach> listC)
        {
            this.ListP = listP;
            this.ListC = listC;
        }

        public List<Player> ListP { get => listP; set => listP = value; }
        public List<Coach> ListC { get => listC; set => listC = value; }

        static String NAME_VALID = "^[A-Za-z]+[A-Za-z ]+";
        static String ADRESS_VALID = "^[A-Za-z]+[A-Za-z0-9, ]+";
        static String[] POSITION_VALID = { "ST", "MD", "DF", "GK" };
        public void addPlayer()
        {
            String code = Input.getCode();
            while (searchP(code) != null)
            {
                Console.Write("re input code :");
                code = Input.getCode();
            }
            String name = Input.getString("Name :", NAME_VALID);
            String address = Input.getString("Adress :", ADRESS_VALID);
            int shirt_number = Input.getInt("Shirt number :", 1, int.MaxValue);
            while (checkShirt(shirt_number))
            {
                Console.Write("re input shirt number :");
                shirt_number = Input.getInt("Shirt number :", 1, int.MaxValue);
            }
            String position = Input.getPos();
            Double salary = Input.getDouble("Salary :", 0, double.MaxValue);
            listP.Add(new Player(code, name, address, shirt_number, position, salary));
            Console.WriteLine("Add successfully");
        }
        private Player searchP(string code)
        {
            foreach (var item in listP)
            {
                if (item.Code.Equals(code))
                {
                    return item;
                }
            }
            return null;

        }
        private bool checkShirt(int shirt)
        {
            foreach (var item in ListP)
            {
                if (item.Shirt_number == shirt)
                {
                    return true;
                }
            }
            return false;
        }

        public void addCoach()
        {
            String code = Input.getCode();
            while (searchC(code) != null)
            {
                Console.Write("re input code :");
                code = Input.getCode();
            }

            String name = Input.getString("Name :", NAME_VALID);
            String address = Input.getString("Adress :", ADRESS_VALID);
            String position = Input.getPos();
            Double salary = Input.getDouble("Salary :", 0, double.MaxValue);
            int year_of = Input.getInt("Year of :", 1, int.MaxValue);
            listC.Add(new Coach(code, name, address, position, salary, year_of));
            Console.WriteLine("Add successfully");
        }

        private Coach searchC(string code)
        {
            foreach (var item in listC)
            {
                if (item.Code.Equals(code))
                {
                    return item;
                }
            }
            return null;

        }


        public void listCoach()
        {
            Console.WriteLine("code" + "\t" + "name" + "\t" + "address" + "\t" + "position" + "\t" + "salary" + "\t" + "year of");
            foreach (var item in listC)
            {
                Console.WriteLine(item);
            }
        }

        public void listPlayer()
        {
            Console.WriteLine("code" + "\t" + "name" + "\t" + "address" + "\t" + "position" + "\t" + "salary"+ "\t" + "shirt number");
            foreach (var item in ListP)
            {
                Console.WriteLine(item);
            }
        }

        public void updatePlayer()
        {
            String code = Input.getCode();
            while (searchP(code) == null)
            {
                Console.Write("re input code :");
                code = Input.getCode();
            }
            int opt = Input.getInt("Input option 1 or 0 : ", 0, 1);
            changePlayer(code, opt);
        }

        private void changePlayer(string code, int opt)
        {
            Player p = searchP(code);
            if (opt == 0)
            {
                int shirt_number = Input.getInt("Shirt number :", 1, int.MaxValue);
                while (checkShirt(shirt_number))
                {
                    Console.Write("re input shirt number :");
                    shirt_number = Input.getInt("Shirt number :", 1, int.MaxValue);
                }
                p.Shirt_number = shirt_number;
            }
            else
            {
                Double salary = Input.getDouble("Salary :", 0, double.MaxValue);
                p.Salary = salary;
            }
            Console.WriteLine("Change successfully");
        }

        public void dashBoard()
        {
            int count = 0;
            double sum = 0;
            foreach (var item in listC)
            {
                if (item.Year_of >= 3)
                {
                    count++;
                }
            }
            foreach (var item in listP)
            {
                if (item.Position.Equals("ST"))
                {
                    sum += item.Salary;
                }
            }
            Console.WriteLine("Coaches have year of experience >= 3 : " + count);
            showMaxLuong();
            Console.WriteLine("Sum of the salary the players that are striker : " + sum);

        }

        private void showMaxLuong()
        {
            ListP.Sort(delegate (Player x, Player y)
            {
                return y.Salary.CompareTo(x.Salary);
            });
            listC.Sort(delegate (Coach x, Coach y)
            {
                return y.Salary.CompareTo(x.Salary);
            });
            Console.WriteLine("have the max salary ");
            Console.WriteLine((listP[0].Salary > listC[0].Salary) ? listP[0] : listC[0]);
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
    }
}
