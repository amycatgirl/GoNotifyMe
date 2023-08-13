using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoMarket;

namespace GoMarket.Tests
{
    [TestClass]
    public class GoMarket_ClientProducts
    {
        private readonly ApiClient _client;

        public GoMarket_ClientProducts()
        {
            _client = new ApiClient(Environment.GetEnvironmentVariable("TOKEN") ?? "None", "GoNotifyMe Client (UnitTestMode)");
        }

        [TestMethod]
        public void ClientProducts_GetDeserializedProducts()
        {
            ApiProductList result = _client.GetProductList();

            Assert.IsNotNull(result, "Result should not be empty");
            Assert.IsInstanceOfType(result.Count, typeof(int), "Count should be a integer");
            Assert.IsInstanceOfType(result.CurrentPage, typeof(int), "CurrentPage should be a integer");
            Assert.IsInstanceOfType(result.Pages, typeof(int), "Pages should be a integer");
            Assert.IsInstanceOfType(result.TotalAmount, typeof(int), "TotalAmount should be a integer");
            Assert.IsInstanceOfType(result.ProductsPerPage, typeof(int), "ProductsPerPage should be a integer");
            Assert.IsInstanceOfType(result.Products, typeof(List<ApiProductListItem>), "Products should be inside of a list");
        }

        [TestMethod]
        public void ClientProducts_GetDeserializedVariants()
        {
            ApiVariantList result = _client.GetVariantList();

            Assert.IsNotNull(result, "Result should not be empty");
            Assert.IsInstanceOfType(result.Count, typeof(int), "Count should be a integer");
            Assert.IsInstanceOfType(result.CurrentPage, typeof(int), "CurrentPage should be a integer");
            Assert.IsInstanceOfType(result.Pages, typeof(int), "Pages should be a integer");
            Assert.IsInstanceOfType(result.TotalAmount, typeof(int), "TotalAmount should be a integer");
            Assert.IsInstanceOfType(result.ProductsPerPage, typeof(int), "ProductsPerPage should be a integer");
            Assert.IsInstanceOfType(result.Variants, typeof(List<ApiVariantListItem>), "Variants should be inside of a list");
        }

        [TestMethod]
        [DataRow(630226)]
        [DataRow(632003)]
        [DataRow(631407)]
        public void ClientProducts_GetDeserializedProduct(int Id)
        {
            var result = _client.GetProduct(Id);

            Assert.IsInstanceOfType(result, typeof(ApiProduct), "Result should be a valid product.");
        }
    }
}
