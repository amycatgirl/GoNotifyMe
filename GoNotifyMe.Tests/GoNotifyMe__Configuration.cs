using GoNotifyMe;

namespace GoNotifyMe.Tests;

[TestClass]
public class GoNotifyMe__Configuration
{
    [TestMethod]
    public void Configuration__ParseSampleConfiguration()
    {
        var config = new Configuration($@"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}TestConfig/config.toml");

        config.ParseConfiguration();

        Assert.IsNotNull(config.Options, "Configuration wasn't parsed");
        Assert.IsNotNull(config.Options.Mail, "Mail options aren't present");
        Assert.IsNotNull(config.Options.TargetEmail, "TargetEmail isn't present");
        Assert.IsNotNull(config.Options.FetchInterval, "FetchInterval isn't present");
    }
}