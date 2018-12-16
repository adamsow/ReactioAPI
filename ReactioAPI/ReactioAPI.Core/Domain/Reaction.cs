using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ReactioAPI.Core.Domain
{
    public class Reaction
    {
        public Reaction()
        {
        }

        public Reaction(string name, 
                        IEnumerable<Substrate> substrates, 
                        IEnumerable<Product> products, 
                        IEnumerable<Factor> factors, 
                        ReactionType type,
                        bool isEndothermic,
                        bool isRedox,
                        bool isBothWays)
        {
            Name = name;
            Substrates = substrates.ToList();
            products = products.ToList();
            Factor = JsonConvert.SerializeObject(factors);
            Type = type;
            IsEndothermic = isEndothermic;
            IsRedox = isRedox;
            IsBothWays = isBothWays;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public virtual ICollection<Substrate> Substrates { get; protected set; }

        public virtual ICollection<Product> Products { get; protected set; }

        public bool IsEndothermic { get; protected set; }

        public string Factor { get; protected set; }

        public ReactionType Type { get; protected set; }

        public bool IsRedox { get; protected set; }

        public bool IsBothWays { get; protected set; }
    }
}