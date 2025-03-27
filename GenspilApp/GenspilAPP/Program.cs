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
            
            myGame.AddBoardgameVariants(new BoardgameVariant(navn, pris, "Dansk", Status.Good, State.InStock));
            */

            MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);


            Console.ReadLine();
        }
    }
}
