﻿using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace GenspilApp
{
    class Customer
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

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }
        public void RemoveReservation(Reservation reservation)
        {
            reservations.Remove(reservation);
        }

        public void GetReservations()
        {
            foreach (var reservation in reservations)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}