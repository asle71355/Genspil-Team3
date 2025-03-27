using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenspilApp.Menu
{
    public class BoardgameMenu
    {
        public static Dictionary<int, Action> menuOptions = new()
            {
                {1, () => BoardgameSortedByName() },
                {2, () => { }},
                {3, () => AddBoardGame() },
                {4, () => { } },
                {5, () => { } },
            };



        public static void DisplayMenu(int selectedOption)
        {
            Console.Clear();
            Console.WriteLine($@"---Genspil---
Menu
Brug piletasterne og Enter til at vælge et menupunkt.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.

Vælg et menupunkt.
[{(selectedOption == 1 ? "*" : " ")}]  Se brætspil sorteret efter navn
[{(selectedOption == 2 ? "*" : " ")}]  Se brætspil sorteret efter genre
[{(selectedOption == 3 ? "*" : " ")}]  Opret nyt brætspil
[{(selectedOption == 4 ? "*" : " ")}]  Slet brætspil
[{(selectedOption == 5 ? "*" : " ")}]  Udskriv liste af brætspil");
        }

        public static void AddBoardGame()
        {
            Console.Clear();
            Console.WriteLine($@"---Genspil---
Opret nyt brætspil");
            Console.Write("Title på brætspil: ");
            string name = Console.ReadLine();

            Console.Write("Antal spillere: ");
            string players = Console.ReadLine();

            string userInputGenre = null;

            List<Genre> genres = new();

            while (userInputGenre != "")
            {
                Console.Write("Genre på brætspil: ");
                userInputGenre = Console.ReadLine();

                if (Enum.TryParse<Genre>(userInputGenre, out Genre genre))
                    genres.Add(genre);
                    
                else if (userInputGenre == "")
                {
                    Boardgame newGame = new Boardgame(name, players, genres);
                    newGame.AddBoardgameToFile();
                    
                    MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);
                }
                else
                    Console.WriteLine("Genre findes ikke.");
            }
        }

        public static void BoardgameSortedByName()
        {
            Console.Clear();
            List<Boardgame> boardgames = null;
            if (File.Exists($"Boardgame.txt"))
            {
                boardgames = File.ReadAllLines($"Boardgame.txt")
                .Select(line => line.Split(";"))
                .Select(bV => new Boardgame(
                bV[0],
                bV[1],
                bV[2]
                .Split(",")
                .Select(g => Enum.Parse<Genre>(g))
                .ToList()
                ))
                .ToList();
            }


        Console.WriteLine($@"---Genspil---
 Brætspil sorteret efter navn

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.
            ");
            foreach(Boardgame boardgame in boardgames)
            {
                Console.WriteLine($"Title: {boardgame.Name}; Antal spillere: {boardgame.Players}; Genrer: {string.Join(", ", boardgame.Genre)}");
            }
        }
    }
}
