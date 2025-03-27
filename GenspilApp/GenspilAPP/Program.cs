using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);

            Console.ReadLine();
        }
    }
}
