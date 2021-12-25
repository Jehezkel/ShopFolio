namespace ShopFolio.Api.Models
{
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