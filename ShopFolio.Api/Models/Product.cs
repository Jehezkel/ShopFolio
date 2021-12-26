namespace ShopFolio.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public ICollection<FieldToValue> CustomFields { get; set; } = new List<FieldToValue>();
    }
}