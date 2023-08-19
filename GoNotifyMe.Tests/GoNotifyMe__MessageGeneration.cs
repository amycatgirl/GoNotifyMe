namespace GoNotifyMe.Tests;

using GoMarket;
using GoNotifyMe.Template;

[TestClass]
public class GoNotifyMe__MessageGeneration
{
    [TestMethod]
    public void MessageGeneration__ProvideList()
    {
        var templateGenerator = new Generator();

        var SampleProductList = new List<ApiProductListItem>
        {
            new ApiProductListItem() { Name = "Test Item", Id = 1, TotalOnHand = 35 },
            new ApiProductListItem() { Name = "Test Item", Id = 2, TotalOnHand = 45 },
            new ApiProductListItem() { Name = "Test Item", Id = 1, TotalOnHand = 12 }
        };

        var Template = templateGenerator.GenerateHtmlList(SampleProductList);

        Console.WriteLine(Template);

        Assert.IsInstanceOfType(Template, typeof(string), "Template is not a string");
        Assert.IsTrue(Template.SequenceEqual("<ul><li>Test Item: 35 in Stock</li><li>Test Item: 45 in Stock</li><li>Test Item: 12 in Stock</li></ul>"));
    }
}