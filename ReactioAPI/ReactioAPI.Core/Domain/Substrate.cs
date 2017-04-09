namespace Reactio.Core.Domain
{
    public class Substrate
    {
        public int ID { get; protected set; }

        public int ReactionID { get; protected set; }

        public string Pattern { get; protected set; }
    }
}