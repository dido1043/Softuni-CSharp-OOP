using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public override int Age
        {
            get { return base.Age; }
            set 
            {
                if (value <= 15) base.Age = value;
                else base.Age = 15;
            }
        }

        public Child(string name, int age) : base(name, age)
        {

        }
    }
}
