using Newtonsoft.Json;

namespace GoNotifyMe.Classes
{
    public class ProductAttribute
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? presentation { get; set; }
        public string? option_type_name { get; set; }
        public int option_type_id { get; set; }
        public string? option_type_presentation { get; set; }
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
        [JsonProperty(PropertyName = "page")]
        public int Pages { get; set; }
    }
    public class ApiIndividualProduct
    {
        public string? name { get; set; }
        public string? brand_name { get; set; }
        public string? sku { get; set; }
        public int primary_taxon_id { get; set; }
        public int[]? taxon_ids { get; set; }
        public float price { get; set; }
        public List<ProductAttribute>? product_properties_attributes { get; set; }
        public float cost_price { get; set; }
        public string? gd_size_reference { get; set; }
        public bool track_inventory { get; set; }
        public float fixed_stock { get; set; }
        public string? available_on { get; set; }
        public string? description { get; set; }
        public string? short_description { get; set; }
        public List<ProductImage>? images { get; set; }
        public int tax_category_id { get; set; }
        public dynamic[]? option_types { get; set; }
    }

    public class ApiProductVariant
    {
        public int product_id { get; set; }
        public dynamic? options { get; set; }
        public string? sku { get; set; }
        public float price { get; set; }
        public float cost_price { get; set; }
        public string? gd_size_reference { get; set; }
        public bool track_inventory { get; set; }
        public float fixed_stock { get; set; }
        public List<ProductImage>? images { get; set; }
        public int tax_category_id { get; set; }
    }
}
