using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen:ICitizen
    {
        private string name;
        private int age;
        private string id;



        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            ID = id;
        }

        public string Name { get {return this.name; } 
            private set { this.name = value; } }

        public int Age { get { return this.age; } 
            private set { this.age = value; } }

        public string ID { get { return this.id; } 
            private set { this.id = value; } }
    }
}
