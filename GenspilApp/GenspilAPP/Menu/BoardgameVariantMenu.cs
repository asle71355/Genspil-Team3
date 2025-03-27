using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class BoardgameVariantMenu
    {
       public static Dictionary<int, Action> menuOptions = new()
            {
                {1, () => { } },
                {2, () => { }},
                {3, () => { } },
                {4, () => { } },
                {5, () => { } },
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
[{(selectedOption == 1 ? "*" : " ")}]  Se brætspil varianter sorteret efter navn
[{(selectedOption == 2 ? "*" : " ")}]  Se brætspil varianter sorteret efter genre
[{(selectedOption == 3 ? "*" : " ")}]  Opret nyt brætspil variant
[{(selectedOption == 4 ? "*" : " ")}]  Slet brætspil variant
[{(selectedOption == 5 ? "*" : " ")}]  Udskriv liste af brætspil variant");
        }
    }

    private void
}
