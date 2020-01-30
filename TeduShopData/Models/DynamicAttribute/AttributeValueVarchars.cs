namespace TeduShopData.Models.DynamicAttribute
{
    public class AttributeValueVarchars
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public virtual Attributes Attributes { get; set; }
        public virtual Products Products { get; set; }
    }
}