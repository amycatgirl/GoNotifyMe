using GoMarket;

namespace GoNotifyMe.Template
{
    public class Generator
    {
        /// <summary>
        /// Creates a new Generator
        /// </summary>
        public Generator() { }

        /// <summary>
        /// Generates a HTML unordered list from a list of products.
        /// </summary>
        /// <param name="apiProducts">Product List</param>
        /// <returns>Generated HTML List</returns>
        public string GenerateHtmlList(List<ApiProduct> apiProducts)
        {
            string ListItems = string.Join("", apiProducts.ToArray().Select(product => $"<li>{product.Name}: {product.TotalOnHand} in Stock</li>"));

            string HtmlList = $"<ul>{ListItems}</ul>";

            return HtmlList;
        }
    }
}