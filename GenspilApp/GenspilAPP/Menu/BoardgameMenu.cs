using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenspilApp.Menu
{
    public class BoardgameMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (BoardgameSortedByName, "Se brætspil sorteret efter navn") },
                {2, (AddBoardgame, "Opret nyt brætspil") },
                {3, (RemoveBoardgame, "Slet brætspil") }
            };

        public static void AddBoardgame()
        {

            StringBuilder log = new();
            Console.Clear();
            MenuClass.Log(log, @"---Genspil----
Opret nyt brætspil
Title på brætspil: ");
            string name = Console.ReadLine();
            MenuClass.Log(log, name, false);

            MenuClass.Log(log, "Antal spillere: ");
            string players = Console.ReadLine();
            MenuClass.Log(log, players, false);

            Dictionary<int, string> AddGenreMenuOptions = new();
            int counter = 1;

            //Fandt løsning her https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum
            foreach (Genre genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                AddGenreMenuOptions.Add(counter, genre.ToString());
                counter++;
            }

            List<string> genreName = MenuClass.MenuMultipleItems(AddGenreMenuOptions, new List<string>(), "genre", log, 1);

            List<Genre> genres = new();

            foreach (Genre genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                if (genreName.Contains(genre.ToString()))
                    genres.Add(genre);
            }

            Boardgame.AddBoardgameToFile(new Boardgame(name, players, genres));
            Storage.Storage.LoadBoardgameFile();
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
        }

        public static void BoardgameSortedByName()
        {
            Console.Clear();

            Console.WriteLine($@"---Genspil---
Brætspil sorteret efter navn

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            if (Storage.Storage.boardgames.Count != 0)
            {
                var SortedBoardgame = Storage.Storage.boardgames.OrderBy(b => b.Name);

                foreach (Boardgame boardgame in SortedBoardgame)
                {
                    Console.WriteLine($"Title: {boardgame.Name}; Antal spillere: {boardgame.Players}; Genrer: {string.Join(", ", boardgame.Genre)}");
                }
            }

            else
            {
                Console.WriteLine("Listen er tom.");
            }

        }

        public static void RemoveBoardgame()
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
