using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Boardgame myGame = new Boardgame("Risk", "2-8", new List<Genre> { Genre.Action, Genre.Strategy });
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

            //MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);


            Console.ReadLine();
        }
    }
}
