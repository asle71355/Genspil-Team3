using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Boardgame myGame = new Boardgame("Risk", "2-8", new List<Genre> { Genre.Action, Genre.Strategy });
            //myGame.AddBoardgameVariants(new BoardgameVariant("risk classic", 500, "Dansk", Status.Good, State.InStock));

            //MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);

            //Customer
            Customer customer = new Customer("Name", 12345678, "Address");

            Console.Write("Indtast kundens navn: ");
            string name = Console.ReadLine();
            customer.SetName(name);

            Console.Write("Indtast telefonnummer: ");
            int telephoneNum = Convert.ToInt32(Console.ReadLine());

            Console.Write("Indtast kundens addresse: ");
            string address = Console.ReadLine();


            Console.ReadLine();
        }
    }
}
