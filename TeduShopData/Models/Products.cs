using System;
using System.Collections.Generic;
using TeduShopData.Models.DynamicAttribute;

namespace TeduShopData.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
            ProductImages = new HashSet<ProductImages>();
            ProductQuantities = new HashSet<ProductQuantities>();
            ProductTags = new HashSet<ProductTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public int CategoryId { get; set; }
        public string ThumbnailImage { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? PromotionPrice { get; set; }
        public bool IncludedVat { get; set; }
        public int? Warranty { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }

        public virtual ProductCategories Category { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductQuantities> ProductQuantities { get; set; }
        public virtual ICollection<ProductTags> ProductTags { get; set; }

        public virtual ICollection<AttributeValueInts> AttributeValueInts { get; set; }
        public virtual ICollection<AttributeValueVarchars> AttributeValueVarchars { get; set; }
        public virtual ICollection<AttributeValueDecimals> AttributeValueDecimals { get; set; }
        public virtual ICollection<AttributeValueDateTimes> AttributeValueDateTimes { get; set; }
        public virtual ICollection<AttributeValueText> AttributeValueText { get; set; }

    }
}
