using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoMarket;

namespace GoMarket.Tests
{
    [TestClass]
    public class GoMarket_ClientCategories
    {
        private readonly ApiClient _client;

        public GoMarket_ClientCategories()
        {
            _client = new ApiClient(Environment.GetEnvironmentVariable("TOKEN") ?? "None", "GoNotifyMe Client (UnitTestMode)");
        }

        [TestMethod]
        public void ClientCategories_GetDeserializedCategories()
        {
            var result = _client.GetCategories();

            var item = result.First();

            Assert.IsInstanceOfType(item, typeof(ApiCategory), "Item is not a Category");
            Assert.IsNotNull(item.Id, "This item doesn't have a Id");
            Assert.IsNotNull(item.Name, "This item doesn't have a name");
            Assert.IsNotNull(item.DisplayName, "This item doesn't have a display name");
        }
    }
}
