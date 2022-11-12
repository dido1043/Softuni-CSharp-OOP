using System;
using System.Collections.Generic;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            this.animals = new HashSet<IAnimal>();
        }

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;

            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                IAnimal currAnimal = null;
                try
                {
                    string[] animalArr = command.Split();
                    currAnimal = this.animalFactory.Animal(animalArr);
                    string[] foodArr = this.reader.ReadLine().Split(' ');
                    IFood currentFood = this.foodFactory.Food(foodArr[0], int.Parse(foodArr[1]));

                    this.writer.WriteLine(currAnimal.HungrinessSound());
                    currAnimal.Eat(currentFood);

                    
                }
                catch (Exception error)
                {

                    this.writer.WriteLine(error.ToString());
                }
                this.animals.Add(currAnimal);
            }

            foreach (IAnimal animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
