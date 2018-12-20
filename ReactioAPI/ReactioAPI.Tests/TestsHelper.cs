﻿using ReactioAPI.Core.Domain;
using ReactioAPI.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactioAPI.Tests
{
    public class TestsHelper
    {
        public static Reaction GetReaction(IEnumerable<Substrate> m_substrateList, IEnumerable<Product> m_productList)
        {
            return new Reaction("Methane synthesis", m_substrateList, m_productList,
                                      new List<Factor>() { Factor.Light, Factor.Temperature },
                                      ReactionType.Synthesis,
                                      true, true, false, "synteza metanu");
        }

        public static List<Product> SetupProducts()
        {
            return new List<Product>()
            {
                new Product(1, 1, false, true, 1)
            };
        }

        public static ReactionDTO SetupReactionDTO()
        {
            return new ReactionDTO
            {
                Factors = new List<Factor>() { Factor.Light, Factor.Temperature },
                Name = "Methane synthesis",
                IsEndothermic = true,
                Products = new List<ProductDTO>() { new ProductDTO() { ReactionID = 1, Name = "Methane", Pattern = "CH4" } },
                Substrates = new List<SubstrateDTO>() { new SubstrateDTO() { ReactionID = 1, Name = "Coal", Pattern = "C" },
                                                        new SubstrateDTO(){ReactionID = 1, Name = "Hydrogen", Pattern = "H"} },
                Type = ReactionType.Synthesis
            };
        }

        public static List<Substrate> SetupSubstartes()
        {
            return new List<Substrate>()
            {
                new Substrate(1, 1, 1),
                new Substrate(1, 1, 1)
            };
        }
    }
}
