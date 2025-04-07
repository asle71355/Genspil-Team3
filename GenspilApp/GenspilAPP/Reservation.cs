using System;
using System.Xml.Linq;

namespace GenspilApp
{
    public class Reservation
    {
        private string comment;
        private List<Boardgame> boardgames = new List<Boardgame>();

        public Reservation(string comment, List<Boardgame> boardgames)
        {
            this.comment = comment;
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

        public List<Boardgame> GetReservations()
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
