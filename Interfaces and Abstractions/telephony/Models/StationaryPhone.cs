using System;
using System.Linq;
using telephony.Models.Interfaces;

namespace telephony.Models
{
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }
        public string Call(string phone)
        {
            if (!phone.All(ch => Char.IsDigit(ch)))
            {
                throw new Exception("Invalid number!");
            }
            return $"Dialing... {phone}";
        }
    }
}
