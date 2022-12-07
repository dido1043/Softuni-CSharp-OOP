using System.Collections.Generic;

namespace PlanetWars.Repositories
{
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Repositories.Contracts;
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;
        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => militaryUnits.AsReadOnly();
        public void AddItem(IMilitaryUnit model)
        {
            if (model != null)
            {
                militaryUnits.Add(model);
            }
        }
        public IMilitaryUnit FindByName(string name)
        {
            var unitToFind = militaryUnits.Find(x => x.GetType().Name == name);
            return unitToFind;
        }
        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = militaryUnits.Find(x => x.GetType().Name == name);
            return militaryUnits.Remove(unit);
        }
    }
}
