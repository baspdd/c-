using les4;

internal class Coach : Clone
{
    private int year_of;

    public Coach()
    {

    }

    public Coach(string code, string name, string address, string position, double salary, int year_of) : base(code,name,address,position,salary)
    {

        this.Year_of = year_of;
    }


    public int Year_of { get => year_of; set => year_of = value; }

    public override string? ToString()
    {
        return base.ToString() + "\t" + year_of;
    }
}