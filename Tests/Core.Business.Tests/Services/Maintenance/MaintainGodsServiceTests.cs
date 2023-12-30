using Moq;
using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Application.Core.Business.Services.Maintenance;
using Smitenight.AutoMoqData.Common.Attributes;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Core.Business.Tests.Mainenance;

public class MaintainGodsServiceTests
{
    [Theory, AutoMoqData]
    internal async Task WhenMaintainingGods_AndSameChecksumFound_ShouldReturnNull(GodDto god, string checksum,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, god)).Returns(false);

        // Act
        int? result = await sut.MaintainGodAsync(god, checksum);

        // Assert
        result.Should().BeNull();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainingGods_AndNewChecksumFound_ShouldReturnNewGodId(GodDto god, CreateGodDto createGod, string checksum,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int createdGodId = 1;

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, It.IsAny<GodDto>())).Returns(true);
        mapperServiceMock.Setup(x => x.Map<GodDto, CreateGodDto>(god)).Returns(createGod);
        maintainGodsRepositoryMock.Setup(x => x.CreateGodAsync(createGod, default)).ReturnsAsync(createdGodId);

        // Act
        int? result = await sut.MaintainGodAsync(god, checksum);

        // Assert
        result.Should().NotBeNull()
            .And.Be(createdGodId);
    }
}
