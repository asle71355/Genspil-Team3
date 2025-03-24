using System;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Reservation.MakeReservation();
            Customer.CreateCustomer();

            Console.ReadLine();
        }
    }
}
