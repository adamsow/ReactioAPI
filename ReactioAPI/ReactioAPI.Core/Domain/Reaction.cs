using ReactioAPI.Core.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Reactio.Core.Domain
{
    public class Reaction
    {
        public Reaction()
        {
        }

        public Reaction(string name, 
                        IEnumerable<Substrate> substrates, 
                        IEnumerable<Product> products, 
                        Factor? factor, 
                        ReactionType type,
                        bool isEndothermic)
        {
            Name = name;
            Substrates = substrates.ToList();
            products = products.ToList();
            Factor = factor?.ToString();
            Type = type.ToString();
            IsEndothermic = isEndothermic;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public virtual ICollection<Substrate> Substrates { get; protected set; }

        public virtual ICollection<Product> Products { get; protected set; }

        [NotMapped]
        public Factor? FactorType { get; protected set; }

        [NotMapped]
        public ReactionType ReactionType { get; protected set; }

        public bool IsEndothermic { get; protected set; }

        public string Factor { get; protected set; }

        public string Type { get; protected set; }
    }
}