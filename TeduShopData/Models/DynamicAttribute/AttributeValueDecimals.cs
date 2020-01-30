using System;

namespace TeduShopData.Models.DynamicAttribute
{
    public class AttributeValueDecimals
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public Decimal Value { get; set; }
        public int ProductId { get; set; }
        public virtual Attributes Attributes { get; set; }
        public virtual Products Products { get; set; }
    }
}