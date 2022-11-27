using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        public List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons.AsReadOnly();

        public void Add(IWeapon model)
        {
            //if (model == null)
            //{
            //    throw new ArgumentException("Model cannot be null!");
            //}
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = weapons.Find(n => n.Name == name);
            return weapon;
        }

        public bool Remove(IWeapon model)
        {
            return weapons.Remove(model);
        }
    }
}
