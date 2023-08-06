using Newtonsoft.Json;

namespace GoNotifyMe.Classes
{
    public class ProductAttribute
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "presentation")]
        public string? DisplayName { get; set; }
        [JsonProperty(PropertyName = "option_type_name")]
        public string? OptionType { get; set; }
        [JsonProperty(PropertyName = "option_type_id")]
        public int OptionTypeId { get; set; }
        [JsonProperty(PropertyName = "option_type_presentation")]
        public string? OptionTypeDisplay { get; set; }
    }
    public class ProductImage
    {
        [JsonProperty(PropertyName = "remote_url")]
        string? URL { get; set; }
    }

    public class ApiProducts
    {
        [JsonProperty(PropertyName = "products")]
        public List<ApiIndividualProduct>? Products { get; set; }
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        [JsonProperty(PropertyName = "total_count")]
        public int TotalAmount { get; set; }
        [JsonProperty(PropertyName = "current_page")]
        public int? CurrentPage { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int ProductsPerPage { get; set; }
        [JsonProperty(PropertyName = "pages")]
        public int Pages { get; set; }
    }
    public class ApiIndividualProduct
    {
        [JsonProperty(PropertyName = "id")]
        public required int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public required string Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
        [JsonProperty(PropertyName = "brand_name")]
        public string? Brand { get; set; }
        [JsonProperty(PropertyName = "sku")]
        public required string SKU { get; set; }
        [JsonProperty(PropertyName = "primary_taxon_id")]
        public required int MainCategoryId { get; set; }
        [JsonProperty(PropertyName = "taxon_ids")]
        public int[]? CategoryIds { get; set; }
        [JsonProperty(PropertyName = "price")]
        public required float Price { get; set; }
        [JsonProperty(PropertyName = "display_price")]
        public required string DisplayPrice { get; set; }
        [JsonProperty(PropertyName = "product_properties_attributes")]
        public List<ProductAttribute>? Attributes { get; set; }
        [JsonProperty(PropertyName = "cost_price")]
        public float ListPrice { get; set; }
        [JsonProperty(PropertyName = "gd_size_reference")]
        public string? DeliverySizeReference { get; set; }
        [JsonProperty(PropertyName = "track_inventory")]
        public bool TrackInventory { get; set; }
        [JsonProperty(PropertyName = "fixed_stock")]
        public float CurrentStock { get; set; }
        [JsonProperty(PropertyName = "available_on")]
        public DateTime? AvailabilityDate { get; set; }
        [JsonProperty(PropertyName = "short_description")]
        public string? ShortDescription { get; set; }
        [JsonProperty(PropertyName = "images")]
        public List<ProductImage>? Images { get; set; }
        [JsonProperty(PropertyName = "tax_category_id")]
        public int TaxCategory { get; set; }
        [JsonProperty(PropertyName = "option_types")]
        public dynamic[]? Variants { get; set; }
    }

    public class ApiProductVariant
    {
        [JsonProperty(PropertyName = "product_id")]
        public int VariantID { get; set; }
        [JsonProperty(PropertyName = "options")]
        public dynamic? Options { get; set; }
        [JsonProperty(PropertyName = "sku")]
        public string? SKU { get; set; }
        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }
        [JsonProperty(PropertyName = "cost_price")]
        public float DisplayPrice { get; set; }
        [JsonProperty(PropertyName = "gd_size_reference")]
        public string? SizeReference { get; set; }
        [JsonProperty(PropertyName = "track_inventory")]
        public bool TrackInventory { get; set; }
        [JsonProperty(PropertyName = "fixed_stock")]
        public float CurrentStock { get; set; }
        [JsonProperty(PropertyName = "images")]
        public List<ProductImage>? Images { get; set; }
        [JsonProperty(PropertyName = "tax_category_id")]
        public int TaxCategory { get; set; }
    }
}
