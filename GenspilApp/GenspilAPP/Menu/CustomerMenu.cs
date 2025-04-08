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

            MenuClass.Log(MenuClass.MenuTitle("Opret ny kunde"), log);

            MenuClass.Log("Kundens navn:", log);

            string name = Console.ReadLine();
            MenuClass.Log(name, log, false);

            MenuClass.Log("Kundens telefon nummer: ", log);
            int telNum = Convert.ToInt32(Console.ReadLine());
            MenuClass.Log(telNum.ToString(), log, false);

            MenuClass.Log("Kundens adresse: ", log);
            string adress = Console.ReadLine();
            MenuClass.Log(adress, log, false);

            Customer.AddCustomerToFile(new Customer(name, telNum, adress));
            Storage.Storage.LoadCustomerFile();

            log.Length = 0;
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }

        public static void CustomerSortedByName()
        {
            Console.Clear();

            Console.WriteLine(MenuClass.MenuTitleWithControls("Kunder sorteret efter navn"));

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

            MenuClass.Log(MenuClass.MenuTitleWithControlsAndArrows("Slet kunde"), log);
            MenuClass.Log("Vælg en kunde der skal slettes.", log);

            int? customerTelNum = MenuClass.MenuItems(removeCustomerMenuOptions, log, 1, "Tlf nr.");

            Customer customerToBeRemoved = Storage.Storage.customers.Find(c => c.GetTelephoneNum() == customerTelNum);

            Storage.Storage.RemoveCustomer(customerToBeRemoved);

            if (File.Exists($"{customerTelNum}.txt"))
                File.Delete($"{customerTelNum}.txt");

            log.Length = 0;
            MenuClass.Menu(MainMenu.menuOptions, "Menu", 1);

        }
    }
}
