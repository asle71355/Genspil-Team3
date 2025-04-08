using System;
using System.Collections.Generic;
using System.Data;
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
                {2, (BoardgameSortedByGenre, "Se brætspil efter genre") },
                {3, (AddBoardgame, "Opret nyt brætspil") },
                {4, (RemoveBoardgame, "Slet brætspil") }
            };

        public static void AddBoardgame()
        {
            //Skaber en StringBuilder, som log til tekst, så jeg kan skabe en illusion til menu.
            StringBuilder log = new();
            //Jeg fjerner alt tekst
            Console.Clear();
            //Skriver ny menu + tilføjer til log variable
            MenuClass.Log(MenuClass.MenuTitle("Opret nyt brætspil"), log);
            MenuClass.Log("Title på brætspil", log);
            string name = Console.ReadLine();
            //Tilføjer brugerinput til log + sat til false, så den ikke laver "ekko"
            MenuClass.Log(name, log, false);

            MenuClass.Log("Antal spillere: ", log);
            string players = Console.ReadLine();
            MenuClass.Log(players, log, false);

            //Ny dictionary til Genre med unik "id"
            Dictionary<int, string> AddGenreMenuOptions = new();
            int counter = 1;

            //Fandt løsning her https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum
            //Tilføjer alle Genre til genre dictionary og counter id + 1
            foreach (Genre genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                AddGenreMenuOptions.Add(counter, genre.ToString());
                counter++;
            }

            //Liste af stringe af Genre som er valgt af bruger via MenuMultipleItems funktionen
            List<string> genreName = MenuClass.MenuMultipleItems(AddGenreMenuOptions, new List<string>(), "genre", log, 1);

            //Laver en ny liste af genre
            List<Genre> genres = new();

            //Hvis genreName indeholder Genre værdi i stringform så Tilføj til liste af Genre.
            //Der er nok nemmere måde at gøre det på, men havde ikke tid til at optimere.
            foreach (Genre genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                if (genreName.Contains(genre.ToString()))
                    genres.Add(genre);
            }

            //Tilføj Boardgame til fil via AddBoardgameToFile metode
            Boardgame.AddBoardgameToFile(new Boardgame(name, players, genres));

            //Opdatere min liste af boardgames fra fil, så listen er opdateret med den nyeste boardgame
            Storage.Storage.LoadBoardgameFile();

            log.Clear();


            //Går tilbage til main menuen
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
        }

        public static void BoardgameSortedByName()
        {
            Console.Clear();

            Console.WriteLine(MenuClass.MenuTitleWithControls("Brætspil sorteret efter navn"));

            if  (Storage.Storage.boardgames != null && Storage.Storage.boardgames.Count != 0)
            {
                var SortedBoardgame = Storage.Storage.boardgames.OrderBy(b => b.Name);

                foreach (Boardgame boardgame in SortedBoardgame)
                {
                    Console.WriteLine(@$"-------------
Title: {boardgame.Name}
Antal spillere: {boardgame.Players}
Genrer: {string.Join(", ", boardgame.Genre)}");
                }
            }

            else
            {
                Console.WriteLine("Listen er tom.");
            }

        }

        public static void BoardgameSortedByGenre()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(MenuClass.MenuTitleWithControls($"Brætspil efter genre"), log);

            Dictionary<int, string> SeeBoardgameGenreMenuOptions = Storage.Storage.GenreDict;

            string chosenGenreName = MenuClass.MenuItems(SeeBoardgameGenreMenuOptions, log, 1);

            Genre? foundGenre = null;

            foreach (Genre genre in (Genre[])Enum.GetValues(typeof(Genre)))
            {
                if (genre.ToString() == chosenGenreName)
                    foundGenre = genre;
            }

            if (Storage.Storage.boardgames != null && Storage.Storage.boardgames.Where(b => b.Genre.Contains((Genre)foundGenre)).Count() != 0)
            {

                var boardgameWithGenre = Storage.Storage.boardgames.Where(b => b.Genre.Contains((Genre)foundGenre));
                Console.Clear();

                MenuClass.Log(MenuClass.MenuTitleWithControls($"Brætspil efter genre {foundGenre}"), log);

                foreach (Boardgame boardgame in boardgameWithGenre)
                {
                    Console.WriteLine(@$"-------------
Title: {boardgame.Name}
Antal spillere: {boardgame.Players}
Genrer: {string.Join(", ", boardgame.Genre)}");
                }
                log.Clear();
            }
            else
            {
                Console.WriteLine("Listen er tom.");
                log.Clear();
            }

            log.Clear();
        }

        public static void RemoveBoardgame()
        {
            StringBuilder log = new();
            Dictionary<int, string> removeBoardgameMenuOptions = Storage.Storage.boardgamesDict;
            int counter = 1;

            Console.Clear();
            MenuClass.Log(MenuClass.MenuTitleWithControlsAndArrows("Slet brætspil"), log);
            MenuClass.Log("Vælg et brætspil der skal sletters.", log);

            string boardgameName = MenuClass.MenuItems(removeBoardgameMenuOptions, log, 1);

            Boardgame boardgameToBeRemoved = Storage.Storage.boardgames.Find(b => b.Name == boardgameName);

            Storage.Storage.Removeboardgame(boardgameToBeRemoved);

            if(File.Exists($"{boardgameName}.txt"))
                File.Delete($"{boardgameName}.txt");

            log.Clear();
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
