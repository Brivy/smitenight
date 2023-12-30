using Smitenight.Application.Core.Business.Services.Checksums;
using Smitenight.AutoMoqData.Common.Attributes;

namespace Smitenight.Core.Business.Tests.Checksums;

public class ChecksumServiceTests
{
    [Theory, AutoMoqData]
    internal void WhenCalculatingChecksum_ShouldReturnCorrectChecksum([Frozen] ChecksumService sut)
    {
        // Arrange
        object @object = new { a = "a", b = "b", c = "c" };

        // Act
        string result = sut.CalculateChecksum(@object);

        // Assert
        result.Should().NotBeNullOrEmpty()
            .And.Be("9a760df9891a7bd48186b3a6513172d1");
    }

    [Theory, AutoMoqData]
    internal void WhenCalculatingChecksum_AndInputIsNull_ShouldReturnCorrectChecksum([Frozen] ChecksumService sut)
    {
        // Arrange
        object? @object = null;

        // Act
        string result = sut.CalculateChecksum(@object);

        // Assert
        result.Should().NotBeNullOrEmpty()
            .And.Be("37a6259cc0c1dae299a7866489dff0bd");
    }

    [Theory, AutoMoqData]
    internal void WhenComparingChecksums_AndChecksumIsDifferent_ShouldReturnTrue([Frozen] ChecksumService sut)
    {
        // Arrange
        string checksum = "37a6259cc0c1dae299a7866489dff0bd";
        object @object = new { a = "a", b = "b", c = "c" };

        // Act
        bool result = sut.IsChecksumDifferent(checksum, @object);

        // Assert
        result.Should().BeTrue();
    }

    [Theory, AutoMoqData]
    internal void WhenComparingChecksums_AndChecksumIsNotDifferent_ShouldReturnFalse([Frozen] ChecksumService sut)
    {
        // Arrange
        string checksum = "9a760df9891a7bd48186b3a6513172d1";
        object @object = new { a = "a", b = "b", c = "c" };

        // Act
        bool result = sut.IsChecksumDifferent(checksum, @object);

        // Assert
        result.Should().BeFalse();
    }
}
