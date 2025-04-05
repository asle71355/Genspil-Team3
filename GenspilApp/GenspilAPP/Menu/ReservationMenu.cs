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
                {1, (SeeReservation, "Se reservationer") },
                {2, (AddReservation, "Opret ny reservationer") },
                { 3, (RemoveReservation, "Slet reservationer") },
            };

        public static void AddReservation()
        {

            StringBuilder log = new();
            Console.Clear();
            MenuClass.Log(log, @"---Genspil----
Opret en ny reservation
Vælg kunde: ");

            Dictionary<int, (string, int)> AddReservationMenuOptions = Storage.Storage.customersDict;

            string customerName = MenuClass.MenuItems(AddReservationMenuOptions, log, 1);
            MenuClass.Log(log, customerName, false);

            Console.Clear();
            Console.WriteLine(log);

            List<string> reservedBoardgames = MenuClass.MenuMultipleItems(Storage.Storage.boardgamesDict, new List<string>(), "Brætspil", log, 1);

            MenuClass.Log(log, "Indtast kommentar: ");
            string comment = Console.ReadLine();
            MenuClass.Log(log, comment, false);

            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetName() == customerName);

            List<Boardgame> foundGames = new();

            foreach(Boardgame boardgame in Storage.Storage.boardgames)
            {
                if (reservedBoardgames.Contains(boardgame.Name))
                {
                    foundGames.Add(boardgame);
                }
            }

            foundCustomer.AddReservation(new Reservation(comment, foundGames));

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
        }

        public static void SeeReservation()
        {
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(log, $@"---Genspil---
Se alle reservationer for en kunde

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            Dictionary<int, (string, int)> SeeReservationMenuOptions = Storage.Storage.customersDict;

            string customerName = MenuClass.MenuItems(SeeReservationMenuOptions, log, 1);
            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetName() == customerName);

            foundCustomer.GetReservations();

        }

        public static void RemoveReservation()
        {
            /*
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(log, $@"---Genspil---
Slet reservation

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            Dictionary<int, (string, int)> chooseCustomerMenuOptions = Storage.Storage.customersDict;

            string customerName = MenuClass.MenuItems(chooseCustomerMenuOptions, log, 1);
            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetName() == customerName);
            int counter = 1;

            Dictionary<int, string> removeReservationMenuOptions = new();

            foreach (Reservation reservation in foundCustomer.GetReservations())
            {
                removeReservationMenuOptions.Add(counter, reservation.GetBoardgames());
                counter++;
            }

            string name = MenuClass.MenuItems(removeBoardgameVariantMenuOptions, log, 1);

            BoardgameVariant boardgameVariantToBeRemoved = foundGame.BoardgameVariant.Find(b => b.Name == name);

            foundGame.RemoveBoardgameVariants(boardgameVariantToBeRemoved);

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);
            */
        }

    }
}
