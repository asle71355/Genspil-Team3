using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class ReservationMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (() => { }, "Se reservationer") },
                {2, (() => { }, "Opret ny reservationer") },
                { 3, (() => {}, "Slet reservationer") },
            };
    }
}
