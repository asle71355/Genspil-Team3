using System;
using System.Xml.Linq;

namespace GenspilApp
{
    public class Reservation
    {
        private static int nextId = 1;

        private string comment;
        private int Id;
        private List<Boardgame> boardgames = new List<Boardgame>();

        public Reservation(string comment, List<Boardgame> boardgames)
        {
            this.comment = comment;
            this.Id = nextId++;
            this.boardgames = boardgames;
        }

        public string GetComment()
        {
            return comment;
        }

        public void SetComment(string comment)
        {
            this.comment = comment;
        }

        public int GetId()
        {
            return Id;
        }

        public List<Boardgame> GetBoardgames()
        {
            return boardgames;
        }

        public void AddBoardgame(Boardgame boardgame)
        {
            boardgames.Add(boardgame);
        }

        public void RemoveBoardgame(Boardgame boardgame)
        {
            boardgames.Remove(boardgame);
        }
    }
}
