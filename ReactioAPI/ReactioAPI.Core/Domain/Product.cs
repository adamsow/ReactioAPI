namespace Reactio.Core.Domain
{
    public class Product
    {
        public int ID { get; protected set; }

        public int ReactionID { get; protected set; }

        public string Pattern { get; protected set; }
    }
}