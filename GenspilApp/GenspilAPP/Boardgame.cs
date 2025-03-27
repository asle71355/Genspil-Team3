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
        private string name;
        private string players;
        private List<Genre> genre = new();
        private List<BoardgameVariant> boardgameVariants = new();

        
        //Konstruktør
        public Boardgame(string name, string players, List<Genre> genre)
        {
            this.name = name;
            this.players = players;
            this.genre = genre;
        }

        
        //Properties
        public string Name
        {
            get { return name; }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("The field cannot be empty, please enter a name..");
                }
            }
        }
        public string Players
        {
            get { return players; }
            set
            {
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int playerNumbers) && playerNumbers > 0)
                {
                    players = value;
                }
                else
                {
                    throw new ArgumentException("The number of players must be greater than 0..");
                }

            }
        }
        public List<Genre> Genre
        {
            get { return genre; }
            set
            {
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("The game must have at least one genre..");
                }
                genre = value;
            }
        }
        public List<BoardgameVariant> BoardgameVariant
        {
            get { return boardgameVariants; }
        }

        //Metoder
        public void AddBoardgameVariants(BoardgameVariant boardgameVariant)
        {
            boardgameVariants.Add(boardgameVariant);
        }
        public void RemoveBoardgameVariants(BoardgameVariant boardgameVariant)
        {
            boardgameVariants.Remove(boardgameVariant);
        }

    }


}
