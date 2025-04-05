using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class CustomerMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (() => CustomerSortedByName(), "Se kunder")},
                {2, (() => AddCustomer(), "Opret ny kunde")},
                { 3, (() => RemoveCustomer(), "Slet kunde") },
            };

        public static void AddCustomer()
        {

            StringBuilder log = new();
            Console.Clear();
            MenuClass.Log(log, @"---Genspil----
Opret ny kunde
Kundens navn: ");
            string name = Console.ReadLine();
            MenuClass.Log(log, name, false);

            MenuClass.Log(log, "Kundens telefon nummer: ");
            string telNum = Console.ReadLine();
            MenuClass.Log(log, telNum, false);

        }

        public static void CustomerSortedByName()
        {
            Console.Clear();

            Console.WriteLine($@"---Genspil---
Kunder sorteret efter navn

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            var SortedBoardgame = Storage.Storage.boardgames.OrderBy(b => b.Name);

            foreach (Boardgame boardgame in SortedBoardgame)
            {
                Console.WriteLine($"Title: {boardgame.Name}; Antal spillere: {boardgame.Players}; Genrer: {string.Join(", ", boardgame.Genre)}");
            }
        }

        public static void RemoveCustomer()
        {
            StringBuilder log = new();
            Dictionary<int, string> removeBoardgameMenuOptions = Storage.Storage.boardgamesDict;
            int counter = 1;

            Console.Clear();
            MenuClass.Log(log, $@"---Genspil---
Slet brætspil
Brug piletasterne og Enter til at vælge et menupunkt.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.

Vælg et brætspil der skal sletters.
");

            string name = MenuClass.MenuItems(removeBoardgameMenuOptions, log, 1);

            Boardgame boardgameToBeRemoved = Storage.Storage.boardgames.Find(b => b.Name == name);

            Storage.Storage.Removeboardgame(boardgameToBeRemoved);

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
