using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp
{
    public enum Status
    {
        InStock, Reserved, UnderReapir, OutOfStock,
        Discontinued, PreOrder
    }
    public enum State
    {
        Bad, Worn, LightlyUsed, Good,
        LikeNew, Unused
    }
    public class BoardgameVariant
    {
        private static int nextId = 1;

        private string _name;
        private int _id;
        private double _price;
        private string _language;
        private State _state;
        private Status _status;

        public BoardgameVariant(string name, double price, string language, State state, Status status)
        {
            this._name = name;
            this._id = nextId++;
            this._price = price;
            this._language = language;
            this._state = state;
            this._status = status;
        }

        public string Name
        {
           get { return _name;  }
           set { _name = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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
        public State Status 
        { get { return _state; } 
          set {  this._state = value; }
        } 

        public Status State
        {
            get { return _status; }
            set { _status = value; }
        }


        public string Print()
        {
            return ("name: " + _name + " price: " + _price + " language: " + _language + " state: " + _state + " status: " + _status);
        }
    }
}
