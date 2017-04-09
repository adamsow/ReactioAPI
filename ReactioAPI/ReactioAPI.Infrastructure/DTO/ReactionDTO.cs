﻿using Reactio.Core.Domain;
using System.Collections.Generic;

namespace Reactio.Infrastructure.DTO
{
    public class ReactionDTO
    {
        public int ID { get; set; }

        public IEnumerable<SubstrateDTO> Substrates { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
