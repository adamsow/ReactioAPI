namespace ReactioAPI.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }

        public int ReactionID { get; set; }

        public string Pattern { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
    }
}
