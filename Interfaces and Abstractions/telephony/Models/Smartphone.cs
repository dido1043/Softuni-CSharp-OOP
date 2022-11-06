using System;
using System.Linq;
using telephony.Models.Interfaces;

namespace telephony.Models
{
    public class Smartphone : ISmartPhone
    {
        public Smartphone()
        {

        }
        public string Call(string phone)
        {
            if (!phone.All(ch => Char.IsDigit(ch)))
            {
                throw new Exception();
            }
            return $"Calling... {phone}";
        }

        public string Browsing(string url)
        {
            
            if (url.Any(ch => Char.IsDigit(ch)))
            {
                throw new Exception();
            }
            return $"Browsing: {url}!";
        }
    }
}
