using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;
        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var weapon = weapons.Find(x => x.GetType().Name == name);
            return weapon;
        }

        public bool RemoveItem(string name)
        {
            var weapon = weapons.FirstOrDefault(x => x.GetType().Name == name);
            return weapons.Remove(weapon);
        }
    }
}
