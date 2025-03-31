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
                {1, (() => BoardgameVariantSortedByName(), "Se brætspil varianter sorteret efter navn")},
                {2, (() => AddBoardgameVariant(), "Opret nyt brætspil variant") },
                {3, (() => RemoveBoardgameVariant(), "Slet brætspil variant") },
                {4, (() => { }, "Udskriv liste af brætspil variant") }
            };
        public static void AddBoardgameVariant()
        {

            StringBuilder log = new();
            Console.Clear();
            MenuClass.Log(log, @"---Genspil----
Opret nyt brætspil variant
Vælg Brætspil: ");

            Dictionary<int, string> AddBoardgameVariantMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(AddBoardgameVariantMenuOptions, log, 1);
            MenuClass.Log(log, boardgame, false);

            Console.Clear();
            Console.WriteLine(log);

            MenuClass.Log(log, "Indtast pris: ");
            double.TryParse(Console.ReadLine(), out double price);
            MenuClass.Log(log, price.ToString());

            MenuClass.Log(log, "Indtast Sprog: ");
            string language = Console.ReadLine();
            MenuClass.Log(log, language, false);

            //Hvordan man får Enum fra string værdi, fandt svar her https://stackoverflow.com/questions/23563960/how-to-get-enum-value-by-string-or-int
            Status status = (Status)Enum.Parse(typeof(Status), MenuClass.MenuItems(Storage.Storage.StatusDict, log, 1));

            State state = (State)Enum.Parse(typeof(State), MenuClass.MenuItems(Storage.Storage.StateDict, log, 1));

            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);

            foundGame.AddBoardgameVariants(new BoardgameVariant(boardgame, price, language, status, state));

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
            }

        public static void BoardgameVariantSortedByName()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(log, $@"---Genspil---
Brætspil variant sorteret efter navn

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            Dictionary<int, string> SeeBoardgameVariantMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(SeeBoardgameVariantMenuOptions, log, 1);
            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);

            var SortedBoardgameVariant = foundGame.BoardgameVariant.OrderBy(b => b.Name);

            Console.Clear();

            MenuClass.Log(log, $@"---Genspil---
Brætspil variant sorteret efter navn for spillet {foundGame.Name}

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            foreach (BoardgameVariant boardgameVariant in SortedBoardgameVariant)
            {
                Console.WriteLine($"Pris: {boardgameVariant.Price}; Sprog: {boardgameVariant.Language}; Stand: {boardgameVariant.State}; Status: {boardgameVariant.Status};");
            }
        }

        public static void RemoveBoardgameVariant()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(log, $@"---Genspil---
Slet brætspils variant

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            Dictionary<int, string> SeeBoardgameVariantMenuOptions = Storage.Storage.boardgamesDict;

            string boardgame = MenuClass.MenuItems(SeeBoardgameVariantMenuOptions, log, 1);
            Boardgame foundGame = Storage.Storage.boardgames.FirstOrDefault(bg => bg.Name == boardgame);
            int counter = 1;

            Dictionary<int, string> removeBoardgameVariantMenuOptions = new();

            foreach (BoardgameVariant game in foundGame.BoardgameVariant)
            {
                removeBoardgameVariantMenuOptions.Add(counter, game.Name);
                counter++;
            }

            string name = MenuClass.MenuItems(removeBoardgameVariantMenuOptions, log, 1);

            BoardgameVariant boardgameVariantToBeRemoved = foundGame.BoardgameVariant.Find(b => b.Name == name);

            foundGame.RemoveBoardgameVariants(boardgameVariantToBeRemoved);

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
