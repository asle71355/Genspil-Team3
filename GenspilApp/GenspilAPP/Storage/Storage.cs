using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenspilApp.Storage
{
    public class Storage
    {

        public static List<Boardgame> boardgames { get; set; } = new();
        public static Dictionary<int, string> boardgamesDict { get; set; } = new();

        public static Dictionary<int, string> GenreDict { get; set; } = new();
        public static Dictionary<int, string> StatusDict { get; set; } = new();
        public static Dictionary<int, string> StateDict { get; set; } = new();

        public static void LoadBoardgameFile()
        {
            boardgames = null;
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
                CreateBoardgamesDictionary();
            }
            
        }

        public static void CreateBoardgamesDictionary()
        {
            boardgamesDict = new Dictionary<int, string>();
            int counter = 1;
            foreach (Boardgame game in boardgames)
            {
                boardgamesDict.Add(counter, game.Name);
                counter++;
            }
        }

        public static void Removeboardgame(Boardgame boardgameToRemove)
        {
            boardgames.Remove(boardgameToRemove);

            File.WriteAllText($"Boardgame.txt", "");
            foreach (Boardgame game in boardgames)
            {
                File.AppendAllText("Boardgame.txt", game.Name + ";" + game.Players + ";" + string.Join(",", game.Genre.Select(g => ((int)g))) + "\n");
            }
            LoadBoardgameFile();
        }

        public static void CreateEnumDictionary<TEnum>(Dictionary<int, string> enumDict) where TEnum : Enum
        {
            //Fandt løsning her https://stackoverflow.com/questions/105372/how-to-enumerate-an-enum og brugte chatgpt til generisk type
            int counter = 1;
            foreach (TEnum singleEnum in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                enumDict.Add(counter, singleEnum.ToString());
                counter++;
            }
        }
    }
}
