using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms.Entities;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {

        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childsCount;
        private int bookingNum;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childsCount, int bookingNum)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childsCount;
            BookingNumber = bookingNum;

        }

        public IRoom Room
        {
            get => room;
            private set
            {
                room = value;
            }
        }

        public int ResidenceDuration
        {
            get => residenceDuration;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childsCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childsCount = value;
            }
        }

        public int BookingNumber
        {
            get => bookingNum;
            set
            {
                bookingNum = value;
            }
        }

        public string BookingSummary()
        {
            return $"Booking number: {BookingNumber}" + Environment.NewLine +
                   $"Room type: {Room.GetType().Name}" + Environment.NewLine +
                   $"Adults: {AdultsCount}" + Environment.NewLine +
                   $"Children: {ChildrenCount}" + Environment.NewLine +
                   $"Total amount paid: {TotalPaid():F2}";
        }

        private double TotalPaid()
        {
            double result = Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            return result;
        }
    }
}
