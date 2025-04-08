using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GenspilApp.Menu
{
    public class BoardgameVariantMenu
    {
       public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (BoardgameVariantSortedByName, "Se brætspil varianter sorteret efter navn")},
                {2, (AddBoardgameVariant, "Opret nyt brætspil variant") },
                {3, (RemoveBoardgameVariant, "Slet brætspil variant") }
            };
        public static void AddBoardgameVariant()
        {

            StringBuilder log = new();
            Console.Clear();

            MenuClass.Log(MenuClass.MenuTitle("Opret nyt brætspil variant"), log);

            MenuClass.Log("Vælg Brætspil: ", log);

            Dictionary<int, string> AddBoardgameVariantMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(AddBoardgameVariantMenuOptions, log, 1);
            MenuClass.Log(boardgame, log, false);

            Console.Clear();
            Console.WriteLine(log);

            MenuClass.Log("Indtast pris: ", log);
            double.TryParse(Console.ReadLine(), out double price);
            MenuClass.Log(price.ToString(), log, false);

            MenuClass.Log("Indtast Sprog: ", log);
            string language = Console.ReadLine();
            MenuClass.Log(language, log, false);

            MenuClass.Log("Vælg tilstand: ", log);
            //Hvordan man får Enum fra string værdi, fandt svar her https://stackoverflow.com/questions/23563960/how-to-get-enum-value-by-string-or-int
            State state = (State)Enum.Parse(typeof(State), MenuClass.MenuItems(Storage.Storage.StateDict, log, 1));
            MenuClass.Log(state.ToString(), log);

            Console.WriteLine("Vælg status: ");
            Status status = (Status)Enum.Parse(typeof(Status), MenuClass.MenuItems(Storage.Storage.StatusDict, log, 1));

            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);

            foundGame.AddBoardgameVariants(new BoardgameVariant(boardgame, price, language, state, status));

            log.Clear();
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
            }

        public static void BoardgameVariantSortedByName()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(MenuClass.MenuTitleWithControls($"Brætspil variant sorteret efter navn"), log);

            Dictionary<int, string> SeeBoardgameVariantMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(SeeBoardgameVariantMenuOptions, log, 1);
            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);

            if(foundGame.BoardgameVariant.Count != 0)
            {
                var SortedBoardgameVariant = foundGame.BoardgameVariant.OrderBy(b => b.Name);

                Console.Clear();

                MenuClass.Log(MenuClass.MenuTitleWithControls($"Brætspil variant sorteret efter navn for spillet {foundGame.Name}"), log);

                foreach (BoardgameVariant boardgameVariant in SortedBoardgameVariant)
                {
                    Console.WriteLine($"Pris: {boardgameVariant.Price}; Sprog: {boardgameVariant.Language}; Status: {boardgameVariant.State}; Tilstand: {boardgameVariant.Status};");
                }
            } else
            {
                Console.WriteLine("Listen er tom.");
            }

            log.Clear();

        }

        public static void RemoveBoardgameVariant()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(MenuClass.MenuTitleWithControls("Slet brætspils variant"), log);


            Dictionary<int, string> chooseBoardgameMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(chooseBoardgameMenuOptions, log, 1);
            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);
            int counter = 1;

            Dictionary<int, (string, int)> removeBoardgameVariantMenuOptions = new();

            foreach (BoardgameVariant game in foundGame.BoardgameVariant)
            {
                removeBoardgameVariantMenuOptions.Add(counter, ($"Sprog: {game.Language}, Pris: {game.Price}", game.Id));
                counter++;
            }

            int? BoardgameVariantId = MenuClass.MenuItems(removeBoardgameVariantMenuOptions, log, 1, "Id");

            BoardgameVariant boardgameVariantToBeRemoved = foundGame.BoardgameVariant.Find(b => b.Id == BoardgameVariantId);

            foundGame.RemoveBoardgameVariants(boardgameVariantToBeRemoved);

            log.Clear();

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
