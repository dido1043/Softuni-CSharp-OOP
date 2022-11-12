using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public Animal Animal(string[] arr)
        {
            string type = arr[0];
            string name = arr[1];
            double weight = Convert.ToDouble(arr[2]);
            var nextValue = arr[3];
            Animal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(nextValue));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(nextValue));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, nextValue);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, nextValue);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, nextValue, arr[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, nextValue, arr[4]);
            }
            else
            {
                throw new Exception(string.Format(ErrorMessages.InvalidAnimal));
            }
            return animal;
        }
    }
}
