namespace ReactioAPI.Core.Domain
{
    public class Substrate
    {
        public Substrate()
        {
        }

        public Substrate(int reactionID, 
            int quantity,
            int reagentID)
        {
            ReactionID = reactionID;
            Quantity = quantity;
            ReagentID = reagentID;
        }

        public int ID { get; protected set; }

        public int Quantity { get; set; }

        public int ReactionID { get; protected set; }

        public int ReagentID { get; protected set; }

        public virtual Reaction Reaction { get; protected set; }

        public virtual Reagent Reagent { get; protected set; }
    }
}