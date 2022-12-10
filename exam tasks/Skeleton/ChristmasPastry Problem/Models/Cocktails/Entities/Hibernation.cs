using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails.Entities
{
    public class Hibernation : Cocktail
    {
        public Hibernation(string name, string size) : base(name, size, 10.50)
        {
        }
    }
}
