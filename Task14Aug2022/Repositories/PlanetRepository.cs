using System.Collections.Generic;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
namespace PlanetWars.Repositories
{

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public PlanetRepository()
        {
            planets = new List<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planets.AsReadOnly();

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var planet = planets.Find(x => x.Name == name);
            return planet;
        }

        public bool RemoveItem(string name)
        {
            var planet = planets.Find(x => x.Name == name);
            return planets.Remove(planet);
        }
    }
}
