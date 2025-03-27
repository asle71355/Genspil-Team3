using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class ReservationMenu
    {
        public static Dictionary<int, Action> menuOptions = new()
            {
                {1, () => { } },
                {2, () => { } },
                { 3, () => {} },
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
[{(selectedOption == 1 ? "*" : " ")}]  Se reservationer
[{(selectedOption == 2 ? "*" : " ")}]  Opret ny reservationer
[{(selectedOption == 3 ? "*" : " ")}]  Slet reservationer");
        }
    }
}
