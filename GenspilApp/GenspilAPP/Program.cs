using GenspilApp.Menu;

namespace GenspilApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

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
