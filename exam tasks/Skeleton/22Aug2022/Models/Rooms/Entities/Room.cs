using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms.Entities
{
    public abstract class Room : IRoom
    {
        private int capacity;
        private double pricePerNight = 0;
        protected Room(int bedCapacity)
        {
            BedCapacity = bedCapacity;
        }
        public int BedCapacity
        {
            get => capacity;
            private set
            { 
                capacity = value; 
            }
        }

        public double PricePerNight
        {
            get => pricePerNight;
            private set
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                pricePerNight = value;
            }
        }

        public void SetPrice(double price)
        {
            PricePerNight = price;
        }
    }
}
