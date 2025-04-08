using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Storage.Storage.LoadBoardgameFile();
            Storage.Storage.CreateBoardgamesDictionary();
            Storage.Storage.LoadCustomerFile();
            Storage.Storage.CreateCustomersDictionary();
            Storage.Storage.CreateEnumDictionary<Genre>(Storage.Storage.GenreDict);
            Storage.Storage.CreateEnumDictionary<Status>(Storage.Storage.StatusDict);
            Storage.Storage.CreateEnumDictionary<State>(Storage.Storage.StateDict);
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);


            Console.ReadLine();
        }
    }
}
