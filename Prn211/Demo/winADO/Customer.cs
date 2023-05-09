namespace winADO
{
    internal class Customer
    {
        public Customer(int code, string? name, string? dob, bool gen, string? address)
        {
            this.code = code;
            this.name = name;
            this.dob = dob;
            this.gen = gen;
            this.address = address;
        }

        public int code { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public bool gen { get; set; }
        public string address { get; set; }
    }
}