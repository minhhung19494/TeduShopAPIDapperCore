using System;
using System.Collections.Generic;

using System.Text;

namespace TeduShopData.Models.DynamicAttribute
{
    public class Attributes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string BackendType { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<AttributeOptions> AttributeOptions { get; set; }
        public virtual ICollection<AttributeValueInts> AttributeValueInts { get; set; }
        public virtual ICollection<AttributeValueVarchars> AttributeValueVarchars { get; set; }
        public virtual ICollection<AttributeValueDecimals> AttributeValueDecimals { get; set; }
        public virtual ICollection<AttributeValueDateTimes> AttributeValueDateTimes { get; set; }
        public virtual ICollection<AttributeValueText> AttributeValueText { get; set; }
    }
}
