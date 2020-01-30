namespace TeduShopData.Models.DynamicAttribute
{
    public class AttributeOptionValues
    {
        public int Id { get; set; }
        public int OptionId { get; set; }
        public string Value { get; set; }
        public virtual AttributeOptions AttributeOptions { get; set; }
    }
}