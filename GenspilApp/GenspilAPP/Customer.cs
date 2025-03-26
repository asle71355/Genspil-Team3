using System;
using System.Collections.Generic;

namespace GenspilApp
{
    class Customer
    {
        private string name;
        private int telephoneNum;
        private string address;
        private List<string> reservations = new List<string>();

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int GetTelephoneNum()
        {
            return telephoneNum;
        }

        public void SetTelephoneNum(int telephoneNum)
        {
            this.telephoneNum = telephoneNum;
        }

        public string GetAddress()
        {
            return address;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public void AddReservations()
        {
            reservations.Add("reservation 1");
            reservations.Add("reservation 2");
            reservations.Add("reservation 3");
        }
        public void RemoveReservation()
        {
            reservations.Remove("reservation 2");
        }

        public void GetReservations()
        {
            foreach (string reservation in reservations)
            {       
            Console.WriteLine(reservation);
            }
        }
    }
}