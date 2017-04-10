using ReactioAPI.Core.Domain;
using System.Collections.Generic;

namespace Reactio.Core.Domain
{
    public class Reaction
    {
        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public virtual ICollection<Substrate> Substrates { get; protected set; }

        public virtual ICollection<Product> Products { get; protected set; }

        public Factor? Factor { get; protected set; }

        public ReactionType? Type { get;  protected set; }

        public bool IsEndothermic { get; protected set; }
    }
}