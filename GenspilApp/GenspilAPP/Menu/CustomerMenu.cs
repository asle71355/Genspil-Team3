using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class CustomerMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (() => {}, "Se kunder")},
                {2, (() => {}, "Opret ny kunde")},
                { 3, (() => {}, "Slet kunde") },
            };
    }
}
