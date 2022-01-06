namespace ShopFolio.Api.Models
{
    public class FieldToValue
    {
        public virtual Product Product { get; set; }
        public CustomField CustomField { get; set; }
        public string Value { get; set; }
    }
    public class CustomField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
    }
    public class FieldType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CustomField> CustomFields { get; set; }
    }
}