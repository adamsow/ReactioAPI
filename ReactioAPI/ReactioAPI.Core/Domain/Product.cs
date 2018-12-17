﻿namespace ReactioAPI.Core.Domain
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, 
            int reactionID, 
            string pattern, 
            int quantity, 
            bool isSediment,
            bool isGas,
            string namePL)
        {
            Name = name;
            NamePL = namePL;
            ReactionID = reactionID;
            Pattern = pattern;
            Quantity = quantity;
            IsSediment = isSediment;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public string NamePL { get; protected set; }

        public int Quantity { get; protected set; }

        public int ReactionID { get; protected set; }

        public string Pattern { get; protected set; }

        public virtual Reaction Reaction { get; protected set; }

        public bool IsSediment { get; protected set; }

        public bool IsGas { get; protected set; }
    }
}