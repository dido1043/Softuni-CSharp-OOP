
using System.Collections.Generic;

namespace NavalVessels.Repositories
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Repositories.Contracts;
    public class Repository : IRepository<IVessel>
    {
        private List<IVessel> vessels;
        public Repository()
        {
            vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => vessels.AsReadOnly();

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            var vessel = vessels.Find(y => y.Name == name);
            return vessel;
        }

        public bool Remove(IVessel model) => vessels.Remove(model);
    }
}
