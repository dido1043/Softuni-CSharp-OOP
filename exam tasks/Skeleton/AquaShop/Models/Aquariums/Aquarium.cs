   using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
 

    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fishes = new List<IFish> ();

        }
        public string Name
        {
            get => name;
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidAquariumName));
                }
                name = value;
            }
        }

        public int Capacity 
        { 
            get => capacity;
            private set { capacity = value; }
        }

        public int Comfort => decorations.Select(x => x.Comfort).Sum();

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishes.Count == this.capacity)
                throw new ArgumentException(String.Format(ExceptionMessages.NotEnoughCapacity));
            this.fishes.Add(fish);
        }

        public void Feed()
        {
            this.fishes.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            var fish = fishes.Any() ? String.Join(", ", fishes.Select(x => x.Name)): "none";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            sb.AppendLine($"Fish: {fish}");
            sb.AppendLine($"Decorations: {decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fishes.Remove(fish);
        }
    }
}
