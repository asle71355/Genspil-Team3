using System;
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
        }

        //Metoder
        public void AddBoardgameVariants(BoardgameVariant boardgameVariant)
        {
            _boardgameVariants.Add(boardgameVariant);
            File.AppendAllText($"{Name}.txt", boardgameVariant.Print());
        }
        public void RemoveBoardgameVariants(BoardgameVariant boardgameVariant)
        {
            _boardgameVariants.Remove(boardgameVariant);
        }

    }


}
