using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Xml.Linq;

namespace GenspilApp
{
    public class Customer
    {
        private string name;
        private int telephoneNum;
        private string address;
        private List<Reservation> reservations = new List<Reservation>();

        public Customer(string name, int telephoneNum, string address)
        {
            this.name = name;
            this.telephoneNum = telephoneNum;
            this.address = address;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            while (true)
            {
                //Tjekker om name er ingenting eller kun mellemrum
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Ugyldigt navn. Indtast navn: ");
                    name = Console.ReadLine(); //Få nyt name fra user
                    continue;
                }

                //Tjekker at alle characters kun er bogstaver og mellemrum
                if (name.Any(c => !char.IsLetter(c) && c != ' '))
                {
                    Console.WriteLine("Ugyldigt navn. Indtast navn: ");
                    name = Console.ReadLine();
                    continue;
                }
                this.name = name;
                break;
            }
        }

        public int GetTelephoneNum()
        {
            return telephoneNum;
        }
        public void SetTelephoneNum(int telephoneNum)
        {
            while (true)
            {
                if (telephoneNum.ToString().Length != 8)
                {
                    Console.WriteLine("Ugyldigt telefonnummer. Prøv igen: ");
                    telephoneNum = Convert.ToInt32(Console.ReadLine()); //Få nyt nr. fra user
                    continue;
                }
                this.telephoneNum = telephoneNum;
                break;
            }
        }

        public string GetAddress()
        {
            return address;
        }
        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
            File.AppendAllText($"{telephoneNum}.txt", string.Join(";", reservations.Select(r => $"{r.GetComment()};{string.Join(",", r.GetBoardgames().Select(b => b.Name))}")) + "\n");
        }
        public void RemoveReservation(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        public List<Reservation> GetReservations()
        {
            return reservations;
        }
        public static void AddCustomerToFile(Customer customer)
        {
            if (!File.Exists("Customer.txt"))
            {
                File.WriteAllText("Customer.txt", "");
            }

            File.AppendAllText("Customer.txt", customer.name + ";" + customer.telephoneNum + ";" + customer.address + "\n");
        }
    }
}