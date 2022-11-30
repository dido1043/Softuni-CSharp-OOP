namespace AquaShop.Core
{
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Repositories;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        //Ready
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAquariumType));
            }
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidDecorationType));
            }
            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType() != typeof(FreshwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fish);
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType() != typeof(SaltwaterAquarium))
                {
                    return OutputMessages.UnsuitableWater;
                }
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                aquarium.AddFish(fish);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidFishType));
            }

            return String.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);

            var sumOfFishes = aquarium.Fish.Select(y => y.Price).Sum();
            var sumOfDecoratins = aquarium.Decorations.Select(z => z.Price).Sum();

            var totalSum = sumOfDecoratins + sumOfFishes;
            return String.Format(OutputMessages.AquariumValue, aquariumName, totalSum);
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            aquarium.Feed();
            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);
            IAquarium aquarium = aquariums.Find(x => x.Name == aquariumName);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            decorations.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            return String.Join(Environment.NewLine, aquariums.Select(x => x.GetInfo()));
        }
    }
}
