namespace ReactioAPI.Core.Domain
{
    public class Product
    {
        public Product(string name, int reactionID, string pattern)
        {
            Name = name;
            ReactionID = reactionID;
            Pattern = pattern;
        }

        public int ID { get; protected set; }

        public string Name { get; protected set; }

        public int ReactionID { get; protected set; }

        public string Pattern { get; protected set; }

        public virtual Reaction Reaction { get; protected set; }
    }
}