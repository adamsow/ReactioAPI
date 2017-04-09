using System.Collections.Generic;

namespace Reactio.Core.Domain
{
    public class Reaction
    {
        public int ID { get; protected set; }

        public IEnumerable<Substrate> Substrates { get; protected set; }

        public IEnumerable<Product> Products { get; protected set; }
    }
}