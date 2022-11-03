using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        private string name;
        private int age;
        private string id;
        private string birthDay;
        public Citizen(string name, int age,string id, string birthDay)
        {
            Name = name; 
            Age = age;
            Id = id;
            Birthdate = birthDay;
        }
        public string Id
        {
            get { return this.id; }
            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidID));
                }
                this.id = value;
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidName));
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age;}
            set 
            {
                if (value < 0 || value > 100 )
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidAge));
                }
                this.age = value;
            }
        }



        public string Birthdate{ get;set; }
    }
}
