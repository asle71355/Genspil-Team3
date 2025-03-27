using GenspilApp.Menu;
using System;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MenuClass.Menu(MainMenu.menuOptions, MainMenu.DisplayMenu);

            Console.WriteLine("Hello, World!");

            //Reservation
            Reservation.MakeReservation();

            //Customer
            Customer customer = new Customer();
            customer.AddReservations();
            customer.RemoveReservation();
            customer.GetReservations();
     
            Console.ReadLine();
        }
    }
}
