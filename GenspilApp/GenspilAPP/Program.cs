using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Boardgame myGame = new Boardgame("Risk", "2-8", new List<Genre> { Genre.Action, Genre.Strategy });
            myGame.AddBoardgameVariants(new BoardgameVariant("risk classic", 500, "Dansk", Status.Good, State.InStock));

            //MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);


            Console.ReadLine();
        }
    }
}
