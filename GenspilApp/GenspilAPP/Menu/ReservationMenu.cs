using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            int? customerTelNum = MenuClass.MenuItems(AddReservationMenuOptions, log, 1, "Tlf nr.");
            MenuClass.Log(log, customerTelNum.ToString(), false);

            Console.Clear();
            Console.WriteLine(log);

            List<string> reservedBoardgames = MenuClass.MenuMultipleItems(Storage.Storage.boardgamesDict, new List<string>(), "Brætspil", log, 1);

            MenuClass.Log(log, "Indtast kommentar: ");
            string comment = Console.ReadLine();
            MenuClass.Log(log, comment, false);

            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetTelephoneNum() == customerTelNum);

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

            int? customerTelNum = MenuClass.MenuItems(SeeReservationMenuOptions, log, 1, "Tlf nr.");
            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetTelephoneNum() == customerTelNum);

            if (foundCustomer.GetReservations().Count != 0)
            {
                int counter = 1;

                foreach (Reservation reservation in foundCustomer.GetReservations())
                {
                    Console.WriteLine(@$"-------------
Reservation {counter}
Kommentar: {reservation.GetComment()};");
                    foreach(Boardgame boardgame in reservation.GetBoardgames())
                    {
                        Console.WriteLine(boardgame.Name);
                    }
                    counter++;
                }
            }

            else
            {
                Console.WriteLine("Listen er tom.");
            }

        }

        public static void RemoveReservation()
        {

            
            Console.Clear();

            StringBuilder log = new();

            MenuClass.Log(log, $@"---Genspil---
Slet reservation

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            Dictionary<int, (string, int)> chooseCustomerMenuOptions = Storage.Storage.customersDict;

            int? customerTelNum = MenuClass.MenuItems(chooseCustomerMenuOptions, log, 1, "Tlf nr.");
            Customer foundCustomer = Storage.Storage.customers.FirstOrDefault(c => c.GetTelephoneNum() == customerTelNum);
            int counter = 1;

            Dictionary<int, (string, int)> removeReservationMenuOptions = new();

            foreach (Reservation reservation in foundCustomer.GetReservations())
            {
                removeReservationMenuOptions.Add(counter, 
                    (string.Join(" | ", reservation.GetBoardgames().Select(b => b.Name)), reservation.GetId()));
                counter++;
            }

            int? reservationId = MenuClass.MenuItems(removeReservationMenuOptions, log, 1, "Id");

            Reservation reservertionToBeRemoved = foundCustomer.GetReservations().Find(r => r.GetId() == reservationId);

            foundCustomer.RemoveReservation(reservertionToBeRemoved);

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }

    }
}
