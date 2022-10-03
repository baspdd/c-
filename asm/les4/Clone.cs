using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les4
{
    internal class Clone
    {
        private String code, name, address, position;
        private double salary;

        public Clone()
        {
        }

        public Clone(string code, string name, string address, string position, double salary)
        {
            this.Code = code;
            this.Name = name;
            this.Address = address;
            this.Position = position;
            this.Salary = salary;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Position { get => position; set => position = value; }
        public double Salary { get => salary; set => salary = value; }
        public override string? ToString()
        {
            return code + "\t" + name + "\t" + address + "\t" + position + "\t" + salary;
        }
    }

}
