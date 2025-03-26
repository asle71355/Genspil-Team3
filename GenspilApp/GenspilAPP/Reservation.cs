using System;
using System.Xml.Linq;

namespace GenspilApp
{
    class Reservation
    {
        private string comment;
        //private List<Boardgame> boardgames = new List<Boardgame>();

        //public Reservation(string comment, List<Boardgame> boardgames)
        //{
        //    this.comment = comment;
        //    this.boardgames = boardgames;
        //}

        public string GetComment()
        {
            return comment;
        }

        public void SetComment(string comment)
        {
            this.comment = comment;
        }

        //public List<Boardgame> GetBoardgames()
        //{
        //    return boardgames;
        //}

        //public void AddBoardgame(Boardgame boardgame)
        //{

        //}

        //public void RemoveBoardgame()
        //{

        //}
    }
}
