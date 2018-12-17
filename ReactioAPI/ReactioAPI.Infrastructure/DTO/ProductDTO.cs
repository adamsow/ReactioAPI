namespace ReactioAPI.Infrastructure.DTO
{
    public class ProductDTO
    {
        public int ID { get; set; }

        public int ReactionID { get; set; }

        public string Pattern { get; set; }

        public string Name { get; set; }

        public string NamePL { get; set; }

        public int Quantity { get; set; }

        public bool IsSediment { get; set; }

        public bool IsGas { get; set; }
    }
}
