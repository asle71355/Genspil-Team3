using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
namespace GenspilApp
{
    //Enum
    public enum Genre
    {
        Action, Strategy, Fantasy,
        FamilyGame, War, Adventure,
        Puzzle, Mystery, ScienceFiction,
        Horror, Cooperative, Party,
        Educational, Trivia, Abstract,
        CardGame, Diplomacy, Roleplaying
    }
    public class Boardgame
    {
        //Felter        
        private string _name;
        private string _players;
        private List<Genre> _genre = new();
        private List<BoardgameVariant> _boardgameVariants = new();

        
        //Konstruktør
        public Boardgame(string name, string players, List<Genre> genre)
        {
            this._name = name;
            this._players = players;
            this._genre = genre;
            if (File.Exists($"{Name}.txt")){
                BoardgameVariant = File.ReadAllLines($"{Name}.txt")
.Select(line => line.Split(";"))
.Select(bV => new BoardgameVariant(
bV[0],
double.Parse(bV[1]),
bV[2],
(Status)Convert.ToInt32(bV[3]),
(State)Convert.ToInt32(bV[4])))
.ToList();
            }
            }
                
        

        
        //Properties
        public string Name
        {
            get { return _name; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("The field cannot be empty, please enter a name..");
                }
            }
        }
        public string Players
        {
            get { return _players; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _players = value;
                }
                else
                {
                    throw new ArgumentException("The number of players must be greater than 0..");
                }

            }
        }
        public List<Genre> Genre
        {
            get { return _genre; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("The game must have at least one genre..");
                }
                _genre = value;
            }
        }
        public List<BoardgameVariant> BoardgameVariant
        {
            get { return _boardgameVariants; }
            set { _boardgameVariants = value; }
        }

        //Metoder
        public void AddBoardgameVariants(BoardgameVariant boardgameVariant)
        {            
            _boardgameVariants.Add(boardgameVariant);
            File.AppendAllText($"{Name}.txt", boardgameVariant.Name + ";" + boardgameVariant.Price + ";" + boardgameVariant.Language + ";" + boardgameVariant.Status + ";" + boardgameVariant.State + "\n");
        }
        public void RemoveBoardgameVariants(BoardgameVariant boardgameVariant)
        {
            _boardgameVariants.Remove(boardgameVariant);
            File.WriteAllText($"{Name}.txt", "");
            foreach(BoardgameVariant game in _boardgameVariants)
            {
                File.AppendAllText($"{Name}.txt", boardgameVariant.Name + ";" + boardgameVariant.Price + ";" + boardgameVariant.Language + ";" + boardgameVariant.Status + ";" + boardgameVariant.State + "\n");
            }

        }
        public void PrintBoardGame()
        {
            foreach (BoardgameVariant variant in BoardgameVariant)
            {
                Console.WriteLine(variant.Print());

            }
        }

    }


}
