using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class MenuClass
    {

        public static void Menu(Dictionary<int, Action> menuOptions, Action<int> DisplayMenu)
        {

            //Holder øje med hvilket menupunkt er valgt
            int selectedOption = 1;

            //Eksevere display menu funktion med menuOptions som parameter
            DisplayMenu(selectedOption);

            //Opretter et ConsoleKey objekt med navn pressedKey
            ConsoleKeyInfo pressedKey;

            do
            {
                pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                if (pressedKey.Key == ConsoleKey.DownArrow && selectedOption < menuOptions.Count)
                {
                    selectedOption++;
                    DisplayMenu(selectedOption);

                }

                if (pressedKey.Key == ConsoleKey.UpArrow && selectedOption > 1)
                {
                    selectedOption--;
                    DisplayMenu(selectedOption);
                }

                if (pressedKey.Key == ConsoleKey.Backspace)
                {
                    MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);
                }

                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    menuOptions[selectedOption].Invoke();
                }

            } while (true);

        }

        }
    
    }