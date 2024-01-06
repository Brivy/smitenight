using AutoFixture.Xunit2;

namespace Smitenight.AutoMoqData.Common.Attributes;

public class InlineAutoMoqDataAttribute(params object[] objects) : InlineAutoDataAttribute(new AutoMoqDataAttribute(), objects)
{
}
