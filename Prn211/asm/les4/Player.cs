using les4;

internal class Player : Clone
{
    
    private int shirt_number;
    public Player()
    {

    }

    public Player(string code, string name, string address, int shirt_number, string position, double salary) : base(code, name, address, position, salary)
    {
        this.shirt_number = shirt_number;
    }

   
    public int Shirt_number { get => shirt_number; set => shirt_number = value; }

    public override string? ToString()
    {
        return base.ToString() +"\t" + shirt_number;
    }
}