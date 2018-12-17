namespace ReactioAPI.Core.Domain
{
    public class Substrate
    {
        public Substrate()
        {
        }

        public Substrate(string name, 
            int reactionID, 
            string pattern, 
            int quantity,
            string namePL)
        {
            Name = name;
            ReactionID = reactionID;
            Pattern = pattern;
            Quantity = quantity;
            NamePL = namePL;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public string NamePL { get; protected set; }

        public int Quantity { get; set; }

        public int ReactionID { get; protected set; }

        public string Pattern { get; protected set; }

        public virtual Reaction Reaction { get; protected set; }
    }
}