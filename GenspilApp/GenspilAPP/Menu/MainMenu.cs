using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{

    //public static void Menu(Dictionary<int, (Action, string)> menuOptions, int selectedOption)
    //{1, (() => BoardgameSortedByName(), "Se brætspil sorteret efter navn") }
    public class MainMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new ()
            {
                {1, (() => MenuClass.Menu(BoardgameMenu.menuOptions, "Brætspil", 1), "Brætspil")},
                {2, (() => MenuClass.Menu(BoardgameVariantMenu.menuOptions, "Brætspil Variant", 1), "Brætspil Variant")},
                {3, (() => MenuClass.Menu(CustomerMenu.menuOptions, "Kunde", 1), "Kunde")},
                {4, (() => MenuClass.Menu(ReservationMenu.menuOptions, "Reservation", 1), "Reservation")}
            };
    }
}
