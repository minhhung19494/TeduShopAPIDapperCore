using System.Collections.Generic;

namespace TeduShopData.Models.DynamicAttribute
{
    public class AttributeOptions
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int SortOrder { get; set; }
        public virtual Attributes Attributes { get; set; }
        public virtual ICollection<AttributeOptionValues> AttributeOptionValues { get; set; }
    }
}