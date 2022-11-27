
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        public List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public void Add(IHero model)
        {
            //if (model == null)
            //{
            //    throw new ArgumentException("Model cannot be null!");
            //}
            heroes.Add(model);
        }

        public IHero FindByName(string name)
        {
            var nameOfHero = heroes.Find(n => n.Name == name);
            return nameOfHero;
        }

        public bool Remove(IHero model)
        {
            return heroes.Remove(model);
        }
    }
}
