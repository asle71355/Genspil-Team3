using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp
{
    public enum State
    {
        InStock, Reserved, UnderReapir, OutOfStock,
        Discontinued, PreOrder
    }
    public enum Status
    {
        Bad, Worn, LightlyUsed, Good,
        LikeNew, Unused
    }
    public class BoardgameVariant
    {
        private string _name;
        private double _price;
        private string _language;
        private Status _Status;
        private State _State;

        public BoardgameVariant(string name, double price, string language, Status status, State state)
        {
            this._name = name;
            this._price = price;
            this._language = language;
            this._Status = status;
            this._State = state;
        }

        public string Name
        {
           get { return _name;  }
           set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        public Status Status 
        { get { return _Status; } 
          set {  this._Status = value; }
        } 

        public State State
        {
            get { return _State; }
            set { _State = value; }
        }


        public string Print()
        {
            return ("name: " + _name + " price: " + _price + " language: " + _language + " status: " + _Status + " state: " + _State);
        }
    }
}
