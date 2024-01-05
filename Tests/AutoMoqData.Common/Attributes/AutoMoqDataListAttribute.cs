using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Smitenight.AutoMoqData.Common.Attributes;

public class AutoMoqDataListAttribute(int repeatCount) : AutoDataAttribute(() =>
    {
        Fixture fixture = new() { RepeatCount = repeatCount };
        fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        return fixture;
    })
{
}
