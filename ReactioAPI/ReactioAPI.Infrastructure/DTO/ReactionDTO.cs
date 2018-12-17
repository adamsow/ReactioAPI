using ReactioAPI.Core.Domain;
using System.Collections.Generic;

namespace ReactioAPI.Infrastructure.DTO
{
    public class ReactionDTO
    {
        public int ID { get; set; }

        public IEnumerable<SubstrateDTO> Substrates { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }

        public ReactionType Type { get; set; }

        public string Name { get; set; }

        public string NamePL { get; set; }

        public IEnumerable<Factor> Factors { get; set; }

        public bool IsEndothermic { get; set; }

        public bool IsRedox { get; set; }

        public bool IsBothWays { get; set; }
    }
}
