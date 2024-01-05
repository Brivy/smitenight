using AutoFixture.Xunit2;

namespace Smitenight.AutoMoqData.Common.Attributes;

public class InlineAutoMoqDataListAttribute(int repeatCount, params object[] objects) : InlineAutoDataAttribute(new AutoMoqDataListAttribute(repeatCount), objects)
{
}
