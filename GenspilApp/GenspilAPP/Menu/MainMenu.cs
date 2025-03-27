using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class MainMenu
    {
        public static Dictionary<int, Action> menuOptions = new ()
            {
                {1, () => MenuClass.Menu(BoardgameMenu.menuOptions, BoardgameMenu.DisplayMenu)},
                {2, () => MenuClass.Menu(BoardgameVariantMenu.menuOptions, BoardgameVariantMenu.DisplayMenu)},
                { 3, () => MenuClass.Menu(CustomerMenu.menuOptions, CustomerMenu.DisplayMenu)},
                { 4, () => MenuClass.Menu(ReservationMenu.menuOptions, ReservationMenu.DisplayMenu)}
            };

public static void DisplayMenu(int selectedOption)
        {
            Console.Clear();
            Console.WriteLine($@"---Genspil---
Menu
Brug piletasterne og Enter til at vælge et menupunkt.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.

Vælg et menupunkt.
[{(selectedOption == 1 ? "*" : " ")}]  Brætspil
[{(selectedOption == 2 ? "*" : " ")}]  Brætspilvariant
[{(selectedOption == 3 ? "*" : " ")}]  Kunde
[{(selectedOption == 4 ? "*" : " ")}]  Reservation");
        }
    }
}
