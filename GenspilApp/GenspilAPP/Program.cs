using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hvad er dit boardgame navn");
            string boardgameNavn = Console.ReadLine();
            Console.WriteLine("Hvor mange spillere kan der være");
            string spillerAntal = Console.ReadLine();
            Boardgame myGame = new Boardgame(boardgameNavn, spillerAntal, new List<Genre> { Genre.Action, Genre.Strategy });
            Console.Write("Vælg navn");
            string navn = Console.ReadLine();
            if(navn == "x")
            {
                foreach(BoardgameVariant variant in myGame.BoardgameVariant)
                {
                    Console.WriteLine(variant.Print());
                    
                }
            }
            Console.WriteLine("Hvad er prisen");
            double pris = Convert.ToDouble(Console.ReadLine());
            
            myGame.AddBoardgameVariants(new BoardgameVariant(navn, pris, "Dansk", State.Good, Status.InStock));
            */


            Storage.Storage.LoadBoardgameFile();
            Storage.Storage.CreateBoardgamesDictionary();
            Storage.Storage.LoadCustomerFile();
            Storage.Storage.CreateCustomersDictionary();
            Storage.Storage.CreateEnumDictionary<Genre>(Storage.Storage.GenreDict);
            Storage.Storage.CreateEnumDictionary<State>(Storage.Storage.StatusDict);
            Storage.Storage.CreateEnumDictionary<Status>(Storage.Storage.StateDict);
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

            //Customer
            //Customer customer = new Customer("Name", 12345678, "Address");

            //Console.Write("Indtast kundens navn: ");
            //string name = Console.ReadLine();
            //customer.SetName(name);

            //Console.Write("Indtast telefonnummer: ");
            //int telephoneNum = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Indtast kundens addresse: ");
            //string address = Console.ReadLine();


            Console.ReadLine();
        }
    }
}
