namespace Heroes.Models.Weapons
{
    using global::Heroes.Models.Contracts;
    using System;
    using System.Reflection.Metadata;

    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        // private int damage;
        public Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
            //Damage = damage;
        }
        public string Name
        {
            get => this.name;
            protected set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Weapon type cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Durability
        {
            get => this.durability;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Durability cannot be below 0.");
                }
                durability = value;
            }
        }
        public abstract int DoDamage();
    }
}
