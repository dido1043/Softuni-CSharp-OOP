
namespace AquaShop.Models.Decorations
{
    using AquaShop.Models.Decorations.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        public Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }

        public int Comfort
        {
            get => this.comfort;
            private set
            {
                //Potential error!
                this.comfort = value;
            }
        }
        public decimal Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }
        }
    }
}
