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
            LoadReservations();
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
            File.AppendAllText($"{telephoneNum}.txt", $"{reservation.GetComment()};{string.Join(",", reservation.GetBoardgames().Select(b => b.Name))}" + "\n");
        }
        public void RemoveReservation(Reservation reservationToBeRemoved)
        {
            reservations.Remove(reservationToBeRemoved);
            File.WriteAllText($"{telephoneNum}.txt", "");
            foreach (Reservation reservation in reservations)
            {
                File.AppendAllText($"{telephoneNum}.txt", $"{reservation.GetComment()};{string.Join(",", reservation.GetBoardgames().Select(b => b.Name))}" + "\n");
            }
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

        public List<Reservation> LoadReservations()
        {
            try
            {
                if (File.Exists($"{telephoneNum}.txt"))
                {
                    var reservationsFromFile = File.ReadAllLines($"{telephoneNum}.txt");

                    foreach(var line in reservationsFromFile)
                    {
                        var r = line.Split(";");
                        var comment = r[0];
                        var boardgameNames = r[1].Split(",");

                        var foundBoardgames = boardgameNames
                        .Select(name => Storage.Storage.boardgames.FirstOrDefault(bG => bG.Name == name))
                        .ToList();

                        reservations.Add(new Reservation(comment, foundBoardgames));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Filen kunne ikke findes..");
            }
            return null;
        }

    }
}