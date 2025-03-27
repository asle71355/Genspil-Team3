using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp
{
    public enum state
    {
        InStock, Reserved, UnderReapir, OutOfStock,
        Discontinued, PreOrder
    }
    public enum status
    {
        Bad, Worn, LightlyUsed, Good,
        LikeNew, Unused
    }
    public class BoardgameVariant
    {
        private string _name;
        private double _price;
        private string _language;
        private status _Status;
        private state _State;

        public BoardgameVariant(string name, double price, string language, status status, state state)
        {
            this._name = name;
            this._price = price;
            this._language = language;
            this._Status = status;
            this._State = state;
        }
    }
    

}
