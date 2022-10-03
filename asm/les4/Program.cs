using les4;

List<Player> listP = new List<Player>();
List<Coach> listC = new List<Coach>();
listP.Add(new Player("1", "pham duc a", "FPT", 1, "GK", 20.1));
listP.Add(new Player("2", "pham duc b", "FPT", 2, "DF", 20.2));
listP.Add(new Player("3", "pham duc c", "FPT", 3, "DF", 20.3));
listP.Add(new Player("4", "pham duc d", "FPT", 4, "MD", 20.4));
listP.Add(new Player("5", "pham duc e", "FPT", 32, "MD", 20.5));
listP.Add(new Player("6", "pham duc f", "FPT", 6, "MD", 20.6));
listP.Add(new Player("7", "pham duc g", "FPT", 11, "ST", 20.7));
listP.Add(new Player("8", "pham duc h", "FPT", 10, "ST", 20.8));

listC.Add(new Coach("1", "nguyen duc a", "HN", "ST", 10.1, 1));
listC.Add(new Coach("2", "nguyen duc b", "HN", "GK", 10.2, 2));
listC.Add(new Coach("3", "nguyen duc c", "HN", "MD", 20.3, 3));
listC.Add(new Coach("4", "nguyen duc d", "HN", "MD", 80.4, 3));
listC.Add(new Coach("5", "nguyen duc e", "HN", "MD", 40.5, 3));
listC.Add(new Coach("6", "nguyen duc f", "HN", "DF", 10.6, 3));
listC.Add(new Coach("7", "nguyen duc g", "HN", "DF", 10.6, 4));



iManager manage = new Manage(listP, listC);
while (true)
{
    Console.WriteLine("1.Add Player");
    Console.WriteLine("2.Add Coach");
    Console.WriteLine("3.Show List Player");
    Console.WriteLine("4.Show List Coach");
    Console.WriteLine("5.Update Player");
    Console.WriteLine("6.Dashboard");
    Console.WriteLine("7.List Players by shirt number ASC");
    Console.WriteLine("8.List Coaches by salary ASC year of = 3");

    Console.WriteLine("0.Exit");
    int option = Int32.Parse(Console.ReadLine());
    switch (option)
    {
        case 0:
            {
                return;
            }
        case 1:
            {
                manage.addPlayer();
                break;
            }
        case 2:
            {
                manage.addCoach();
                break;
            }
        case 3:
            {
                manage.listPlayer();
                break;
            }
        case 4:
            {
                manage.listCoach();
                break;
            }
        case 5:
            {
                manage.updatePlayer();
                break;
            }
        case 6:
            {
                manage.dashBoard();
                break;
            }
        case 7:
            {
                manage.asc();
                break;
            }
        case 8:
            {
                manage.asc2();
                break;
            }
        default:
            break;
    }
}