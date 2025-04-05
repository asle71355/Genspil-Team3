using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenspilApp.Menu
{
    public class CustomerMenu
    {
        public static Dictionary<int, (Action, string)> menuOptions = new()
            {
                {1, (CustomerSortedByName, "Se kunder")},
                {2, (AddCustomer, "Opret ny kunde")},
                { 3, (RemoveCustomer, "Slet kunde") },
            };

        public static void AddCustomer()
        {

            StringBuilder log = new();
            Console.Clear();
            MenuClass.Log(log, @"---Genspil----
Opret ny kunde
Kundens navn: ");
            string name = Console.ReadLine();
            MenuClass.Log(log, name, false);

            MenuClass.Log(log, "Kundens telefon nummer: ");
            int telNum = Convert.ToInt32(Console.ReadLine());
            MenuClass.Log(log, telNum.ToString(), false);

            MenuClass.Log(log, "Kundens adresse: ");
            string adress = Console.ReadLine();
            MenuClass.Log(log, adress, false);

            Customer.AddCustomerToFile(new Customer(name, telNum, adress));
            Storage.Storage.LoadCustomerFile();
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }

        public static void CustomerSortedByName()
        {
            Console.Clear();

            Console.WriteLine($@"---Genspil---
Kunder sorteret efter navn

Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.


            ");

            var sortedCustomer = Storage.Storage.customers.OrderBy(b => b.GetName());

            foreach (Customer customer in sortedCustomer)
            {
                Console.WriteLine($"Navn: {customer.GetName()}; Telefonnr.: {customer.GetTelephoneNum()}; Adresse:{customer.GetAddress()}");
            }
        }

        public static void RemoveCustomer()
        {
            StringBuilder log = new();
            Dictionary<int, (string, int)> removeCustomerMenuOptions = Storage.Storage.customersDict;
            int counter = 1;

            Console.Clear();
            MenuClass.Log(log, $@"---Genspil---
Slet kunde
Brug piletasterne og Enter til at vælge et menupunkt.
Brug Esc til at lukke programmet.
Brug Backspace til at gå tilbage til hovedmenuen.

Vælg en kunde der skal slettes.
");

            string name = MenuClass.MenuItems(removeCustomerMenuOptions, log, 1);

            Customer customerToBeRemoved = Storage.Storage.customers.Find(b => b.GetName() == name);

            Storage.Storage.RemoveCustomer(customerToBeRemoved);

            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
