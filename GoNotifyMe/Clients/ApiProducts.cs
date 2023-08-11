﻿using Newtonsoft.Json;

namespace GoNotifyMe.Clients
{
    // ////////////////////////////////////////////////////////
    // TODO: Refactor ApiProductImage to be more flexible
    //
    // Amy: Follow the api's structure when possible.
    // ///////////////////////////////////////////////////////
    //
    // Note: Add tasks that need to be completed above me,
    // It makes managing tasks a lot more... ummm, cooler B)
    //
    // ///////////////////////////////////////////////////////

    public class ApiProductList
    {
        [JsonProperty(PropertyName = "products")]
        public List<ApiProductListItem>? Products { get; set; }
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

    public class ApiProductAttribute
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

    public class ApiProductImage
    {
        [JsonProperty(PropertyName = "remote_url")]
        string? URL { get; set; }
    }

    public class ApiProductListItem
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
        [JsonProperty(PropertyName = "price")]
        public Single? Price { get; set; }
        [JsonProperty(PropertyName = "display_price")]
        public string? DisplayPrice { get; set; }
        [JsonProperty(PropertyName = "available_on")]
        public DateTime? AvailableOn { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string? Slug { get; set; }
        [JsonProperty(PropertyName = "meta_description")]
        public string? MetaDescription { get; set; }
        [JsonProperty(PropertyName = "meta_keywords")]
        public string[]? MetaKeywords { get; set; }
        [JsonProperty(PropertyName = "shipping_category_id")]
        public int? ShippingCategory { get; set; }
        [JsonProperty(PropertyName = "taxon_ids")]
        public int[]? TaxonIds { get; set; }
        [JsonProperty(PropertyName = "total_on_hand")]
        public int? TotalOnHand { get; set; }
        [JsonProperty(PropertyName = "avg_rating")]
        public Single? AverageRating { get; set; }
        [JsonProperty(PropertyName = "reviews_count")]
        public int? ReviewsAmmount { get; set; }
        [JsonProperty(PropertyName = "is_visible")]
        public bool? Visibility { get; set; }
        [JsonProperty(PropertyName = "primary_taxon_id")]
        public int? MainTaxonId { get; set; }
        [JsonProperty(PropertyName = "ext_id")]
        public int? ExtId { get; set; }
        [JsonProperty(PropertyName = "master")]
        public ApiProduct? MasterVariant { get; set; }
        [JsonProperty(PropertyName = "variants")]
        public ApiProduct[]? Variants { get; set; }
        [JsonProperty(PropertyName = "option_types")]
        public dynamic? OptionTypes { get; set; }
        [JsonProperty(PropertyName = "product_properties")]
        public dynamic? Properites { get; set; }
        [JsonProperty(PropertyName = "classifications")]
        public dynamic[]? Classifications { get; set; }
        [JsonProperty(PropertyName = "has_variants")]
        public bool? HasVariants { get; set; }
    }

    public class ApiProduct
    {
        [JsonProperty(PropertyName = "id")]
        public required string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public required string Name { get; set; }
        [JsonProperty(PropertyName = "sku")]
        public required string Sku { get; set; }
        [JsonProperty(PropertyName = "price")]
        public Single? Price { get; set; }
        [JsonProperty(PropertyName = "weight")]
        public Single? Weight { get; set; }
        [JsonProperty(PropertyName = "width")]
        public int? Width { get; set; }
        [JsonProperty(PropertyName = "height")]
        public int? Height { get; set; }
        [JsonProperty(PropertyName = "depth")]
        public int? Depth { get; set; }
        [JsonProperty(PropertyName = "is_master")]
        public bool? IsMainProduct { get; set; }
        [JsonProperty(PropertyName = "slug")]
        public string? Slug { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string? Description { get; set; }
        [JsonProperty(PropertyName = "track_inventory")]
        public bool? ShouldTrackInventory { get; set; }
        [JsonProperty(PropertyName = "product_id")]
        public int? ProductId { get; set; }
        [JsonProperty(PropertyName = "vendor_id")]
        public int? Vendor { get; set; }
        [JsonProperty(PropertyName = "ext_int")]
        public int? ExtInt { get; set; }
        [JsonProperty(PropertyName = "option_values")]
        public dynamic[]? OptionValues { get; set; }
        // TODO: Change dynamic to ApiImage Class (Assignee: @amycatgirl)
        [JsonProperty(PropertyName = "images")]
        public dynamic[]? Images { get; set; }
        [JsonProperty(PropertyName = "display_price")]
        public string? DisplayPrice { get; set; }
        [JsonProperty(PropertyName = "options_text")]
        public string? OptionsText { get; set; }
        [JsonProperty(PropertyName = "in_stock")]
        public bool? InStock { get; set; }
        [JsonProperty(PropertyName = "is_backorderable")]
        public bool? AllowOrdersWithoutStock { get; set; }
        [JsonProperty(PropertyName = "is_orderable")]
        public bool? AllowOrders { get; set; }
        [JsonProperty(PropertyName = "total_on_hand")]
        public int? TotalOnHand { get; set; }
        [JsonProperty(PropertyName = "is_destroyed")]
        public bool? IsDestroyed { get; set; }

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
        public List<ApiProductImage>? Images { get; set; }
        [JsonProperty(PropertyName = "tax_category_id")]
        public int TaxCategory { get; set; }
    }
}
