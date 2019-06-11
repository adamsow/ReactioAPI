namespace ReactioAPI.Core.Domain
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int reactionID, 
            int quantity, 
            bool isSediment,
            bool isGas,
            int reagentID)
        {
            ReactionID = reactionID;
            ReagentID = reagentID;
            Quantity = quantity;
            IsSediment = isSediment;
            IsGas = isGas;
        }

        public int ID { get; protected set; }

        public int Quantity { get; protected set; }

        public int ReactionID { get; protected set; }

        public int ReagentID { get; protected set; }

        public virtual Reaction Reaction { get; protected set; }

        public virtual Reagent Reagent { get; protected set; }

        public bool IsSediment { get; protected set; }

        public bool IsGas { get; protected set; }
    }
}