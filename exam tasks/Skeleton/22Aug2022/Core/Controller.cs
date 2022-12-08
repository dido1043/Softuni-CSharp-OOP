using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms.Entities;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            var hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotels.Select(hotelName);
            if (hotels.All().Any(x => x.Rooms.GetType().Name == roomTypeName))
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            if (roomTypeName != nameof(DoubleBed) &&
                roomTypeName != nameof(Studio) &&
                roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            hotel.Rooms.AddNew(room);
            return String.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != nameof(DoubleBed) &&
                roomTypeName != nameof(Studio) &&
                roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            IHotel hotel = hotels.Select(hotelName);
            if (!hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return OutputMessages.RoomTypeNotCreated;
            }
            if (hotel.Rooms.All().Any(x => x.PricePerNight > 0))
            {
                throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            room.SetPrice(price);
            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().Any(x => x.Category == category) == default)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            var orderedHotels = hotels.All().Where(n => n.Category == category).OrderBy(x => x.Turnover).ThenBy(y => y.FullName);
            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int newBookingNum = hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, newBookingNum);
                    hotel.Bookings.AddNew(booking);
                    return String.Format(OutputMessages.BookingSuccessful, newBookingNum, hotel.FullName);
                }
            }
            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            StringBuilder sb = new StringBuilder();
            IHotel hotel = hotels.Select(hotelName);
            if (hotel == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine($"none");
            }
            else
            {
                foreach (var book in hotel.Bookings.All())
                {
                    sb.AppendLine(book.BookingSummary());
                    sb.AppendLine();
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
