using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public BookingRepository()
        {
            bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All() => bookings.AsReadOnly();

        public IBooking Select(string criteria)
        {
            IBooking booking = bookings.FirstOrDefault(x => x.BookingNumber.ToString() == criteria);
            return booking;
        }
    }
}
