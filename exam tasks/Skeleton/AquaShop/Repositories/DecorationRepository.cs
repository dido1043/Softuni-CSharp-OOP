
namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> decorations;
        public DecorationRepository()
        {
            decorations = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => decorations;

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var decoration = this.decorations.Find(x => x.GetType().Name == type);
            return decoration;
        }

        public bool Remove(IDecoration model)
        {
            return this.decorations.Remove(model);
        }
    }
}
