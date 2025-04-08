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

        public static void Menu(Dictionary<int, (Action, string)> menuOptions, string title, int selectedOption)
        {
            //Sletter alt tekst
            Console.Clear();

            //Udskriver menu tekst
            Console.WriteLine(MenuTitleWithControlsAndArrows(title));
            Console.WriteLine("Vælg et menupunkt.");

            //Skaber menu fra dictionary menuOptions
            foreach (var item in menuOptions)
            {
                Console.WriteLine($"[{(selectedOption == item.Key ? ">" : " ")}] {item.Value.Item2}");
            }

            //Opretter et ConsoleKey objekt med navn pressedKey
            ConsoleKeyInfo pressedKey;

            do
            {
                //Læser bruger input
                pressedKey = Console.ReadKey();

                if (pressedKey.Key == ConsoleKey.Escape)
                {
                    //Quiter console
                    Environment.Exit(0);
                }

                if (pressedKey.Key == ConsoleKey.DownArrow && selectedOption < menuOptions.Count)
                {
                    //Kører menu funktionen men hvor selectedOption er en mere
                    Menu(menuOptions, title, ++selectedOption);
                }

                if (pressedKey.Key == ConsoleKey.UpArrow && selectedOption > 1)
                {
                    //Kører menu funktionen men hvor selectedOption er en mindre
                    Menu(menuOptions, title, --selectedOption);
                }

                if (pressedKey.Key == ConsoleKey.Backspace)
                {
                    //Kører menu funktion med mainMenu dictionary
                    MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
                }

                if (pressedKey.Key == ConsoleKey.Enter)
                {
                    //Hvis der bliver trykket enter invokes Action fra menuOptions dictionary
                    menuOptions[selectedOption].Item1.Invoke();
                }

            } while (true);

        }

        public static string MenuItems(Dictionary<int, string> menuItemsOptions, StringBuilder log, int selectedOption)
        {
            //Eksevere display menu funktion med menuOptions som parameter
            Console.Clear();
            Console.WriteLine(log);

            foreach (var item in menuItemsOptions)
            {
                Console.WriteLine($"[{(selectedOption == item.Key ? ">" : " ")}] {item.Value}");
            }

            //Opretter et ConsoleKey objekt med navn pressedKey
            ConsoleKeyInfo pressedKey;

            pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (pressedKey.Key == ConsoleKey.DownArrow && selectedOption < menuItemsOptions.Count)
            {
                return MenuItems(menuItemsOptions, log, ++selectedOption);

            }

            if (pressedKey.Key == ConsoleKey.UpArrow && selectedOption > 1)
            {
                return MenuItems(menuItemsOptions, log, --selectedOption);
            }

            if (pressedKey.Key == ConsoleKey.Backspace)
            {
                MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
                return null;
            }

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                return menuItemsOptions[selectedOption];
            }

            return MenuItems(menuItemsOptions, log, selectedOption);

        }

        public static int? MenuItems(Dictionary<int, (string, int)> menuItemsOptions, StringBuilder log, int selectedOption, string idName)
        {
            //Eksevere display menu funktion med menuOptions som parameter
            Console.Clear();
            Console.WriteLine(log);

            foreach (var item in menuItemsOptions)
            {
                Console.WriteLine($"[{(selectedOption == item.Key ? ">" : " ")}] {item.Value.Item1}, {idName}: {item.Value.Item2}");
            }

            //Opretter et ConsoleKey objekt med navn pressedKey
            ConsoleKeyInfo pressedKey;

            pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (pressedKey.Key == ConsoleKey.DownArrow && selectedOption < menuItemsOptions.Count)
            {
                return MenuItems(menuItemsOptions, log, ++selectedOption, idName);

            }

            if (pressedKey.Key == ConsoleKey.UpArrow && selectedOption > 1)
            {
                return MenuItems(menuItemsOptions, log, --selectedOption, idName);
            }

            if (pressedKey.Key == ConsoleKey.Backspace)
            {
                MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
                return null;
            }

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                return menuItemsOptions[selectedOption].Item2;
            }

            return MenuItems(menuItemsOptions, log, selectedOption, idName);

        }

        public static List<string> MenuMultipleItems(Dictionary<int, string> menuItemsOptions, List<string> list, string title, StringBuilder log, int selectedOption)
        {
            Console.Clear();
            //Eksevere display menu funktion med menuOptions som parameter
            Console.WriteLine(log);
            Console.WriteLine($@"Vælg {title}
Brug piletasterne og Tab for at vælge.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen uden at gemme.");

            foreach (var item in menuItemsOptions)
            {
                Console.WriteLine($"[{(selectedOption == item.Key ? ">" : list.Contains(item.Value) ? "*" : " ")}] {item.Value}");
            }

            //Opretter et ConsoleKey objekt med navn pressedKey
            ConsoleKeyInfo pressedKey;

            pressedKey = Console.ReadKey();

            if (pressedKey.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            if (pressedKey.Key == ConsoleKey.DownArrow && selectedOption < menuItemsOptions.Count)
            {
                return MenuMultipleItems(menuItemsOptions, list, title, log, ++selectedOption);
            }

            if (pressedKey.Key == ConsoleKey.UpArrow && selectedOption > 1)
            {
                return MenuMultipleItems(menuItemsOptions, list, title, log, --selectedOption);
            }

            if (pressedKey.Key == ConsoleKey.Backspace)
            {
                MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
                return null;
            }

            if (pressedKey.Key == ConsoleKey.Enter)
            {
                return list;
            }

            if (pressedKey.Key == ConsoleKey.Tab)
            {
                list.Add(menuItemsOptions[selectedOption]);
                return MenuMultipleItems(menuItemsOptions, list, title, log, selectedOption);
            }

            return MenuMultipleItems(menuItemsOptions, list, title, log, selectedOption);

        }

        //Fandt løsning her https://stackoverflow.com/questions/68504575/c-sharp-is-there-way-to-copy-console-content-and-save-to-file-at-the-end-of-co
        public static StringBuilder Log(string msg, StringBuilder log, bool toggleLog = true)
        {
            if (toggleLog)
                Console.WriteLine(msg);
            return log.AppendLine(msg);
        }

        public static string MenuTitle(string title)
        {
            return $@"---Genspil---
{title}





            ";
        }

        public static string MenuTitleWithControls(string title)
        {
            return $@"---Genspil---
{title}

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ";
        }

        public static string MenuTitleWithControlsAndArrows(string title)
        {
            return $@"---Genspil---
{title}
Brug piletasterne og Enter til at vælge et menupunkt.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ";
        }

    }
}