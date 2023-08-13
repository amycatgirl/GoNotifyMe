using Newtonsoft.Json;

namespace GoMarket
{
    public class ApiCategory
    {
        [JsonProperty(PropertyName = "id")]
        public required int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
        [JsonProperty(PropertyName = "parent_id")]
        public int? Parent { get; set; }
        [JsonProperty(PropertyName = "lft")]
        public int? Lft { get; set; }
        [JsonProperty(PropertyName = "rgt")]
        public int? Rgt { get; set; }
        [JsonProperty(PropertyName = "depth")]
        public int? ItemDepth { get; set; }
        [JsonProperty(PropertyName = "taxonomy_id")]
        public int? TaxonomyId { get; set; }
        [JsonProperty(PropertyName = "pretty_name")]
        public string? DisplayName { get; set; }
        [JsonProperty(PropertyName = "required_properties")]
        public string[]? Properties { get; set; }
    }
}
