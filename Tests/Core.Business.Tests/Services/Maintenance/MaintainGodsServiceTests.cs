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
    internal async Task WhenMaintainingGods_AndNewChecksumFound_ShouldReturnNewGodId(GodDto god, CreateGodDto createGod,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int createdGodId = 1;
        const string checksum = "checksum";

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, It.IsAny<GodDto>())).Returns(true).Verifiable();
        mapperServiceMock.Setup(x => x.Map<GodDto, CreateGodDto>(god)).Returns(createGod).Verifiable();
        maintainGodsRepositoryMock.Setup(x => x.CreateGodAsync(createGod, default)).ReturnsAsync(createdGodId).Verifiable();

        // Act
        int? result = await sut.MaintainGodAsync(god, checksum);

        // Assert
        result.Should().NotBeNull()
            .And.Be(createdGodId);

        checksumServiceMock.Verify();
        mapperServiceMock.Verify();
        maintainGodsRepositoryMock.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainingGods_AndSameChecksumFound_ShouldReturnNull(GodDto god,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const string checksum = "checksum";

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, It.IsAny<GodDto>())).Returns(false).Verifiable();

        // Act
        int? result = await sut.MaintainGodAsync(god, checksum);

        // Assert
        result.Should().BeNull();

        checksumServiceMock.Verify();
    }

    [Theory]
    [InlineAutoMoqData(false)]
    [InlineAutoMoqData(true)]
    internal async Task WhenMaintainAbilities_AndNewChecksumFound_ShouldCreateAbility(bool godUpdated, AbilityDetailsDto abilityDetails, CreateAbilityDto createAbility,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const string checksum = "checksum";
        Dictionary<string, AbilityDetailsDto> abilityChecksums = new() { { checksum, abilityDetails } };

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, abilityDetails)).Returns(true);
        mapperServiceMock.Setup(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(abilityDetails)).Returns(createAbility);
        maintainGodsRepositoryMock.Setup(x => x.CreateAbilityAsync(godId, createAbility, default));

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(checksum, abilityDetails), Times.Once);
        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(abilityDetails), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(godId, createAbility, default), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(It.IsAny<int>(), abilityDetails.Id, default), Times.Never);
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainAbilities_AndNoNewChecksumFoundButGodUpdated_ShouldUpdateAbilityRelation(AbilityDetailsDto abilityDetails,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;
        const string checksum = "checksum";
        Dictionary<string, AbilityDetailsDto> abilityChecksums = new() { { checksum, abilityDetails } };

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, abilityDetails)).Returns(false);
        maintainGodsRepositoryMock.Setup(x => x.UpdateAbilityRelationAsync(godId, abilityDetails.Id, default));

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(checksum, abilityDetails), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(godId, abilityDetails.Id, default), Times.Once);

        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(abilityDetails), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(It.IsAny<int>(), It.IsAny<CreateAbilityDto>(), default), Times.Never);
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainAbilities_AndNoNewChecksumFoundAndGodsFound_ShouldDoNothing(AbilityDetailsDto abilityDetails,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = false;
        const string checksum = "checksum";
        Dictionary<string, AbilityDetailsDto> abilityChecksums = new() { { checksum, abilityDetails } };

        checksumServiceMock.Setup(x => x.IsChecksumDifferent(checksum, abilityDetails)).Returns(false);

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(checksum, abilityDetails), Times.Once);

        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(abilityDetails), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(It.IsAny<int>(), It.IsAny<CreateAbilityDto>(), default), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(It.IsAny<int>(), abilityDetails.Id, default), Times.Never);
    }

    [Theory]
    [InlineAutoMoqDataList(2, false)]
    [InlineAutoMoqDataList(2, true)]
    internal async Task WhenMaintainAbilities_AndMultipleNewChecksumsFound_ShouldCreateAbilities(bool godUpdated, Dictionary<string, AbilityDetailsDto> abilityChecksums, CreateAbilityDto createAbility,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;

        checksumServiceMock.SetupSequence(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>())).Returns(true).Returns(true);
        mapperServiceMock.SetupSequence(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(It.IsAny<AbilityDetailsDto>())).Returns(createAbility).Returns(createAbility);
        maintainGodsRepositoryMock.Setup(x => x.CreateAbilityAsync(godId, createAbility, default));

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>()), Times.Exactly(2));
        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(It.IsAny<AbilityDetailsDto>()), Times.Exactly(2));
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(godId, createAbility, default), Times.Exactly(2));
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainAbilities_AndNoNewChecksumsButGodUpdated_ShouldUpdateAbilityRelation(Dictionary<string, AbilityDetailsDto> abilityChecksums,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;

        checksumServiceMock.SetupSequence(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>())).Returns(false).Returns(false);
        maintainGodsRepositoryMock.Setup(x => x.UpdateAbilityRelationAsync(godId, It.IsAny<int>(), default));

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>()), Times.Exactly(2));
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(godId, It.IsAny<int>(), default), Times.Exactly(2));

        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(It.IsAny<AbilityDetailsDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(It.IsAny<int>(), It.IsAny<CreateAbilityDto>(), default), Times.Never);
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainAbilities_AndNoNewChecksumsAndNoGodUpdated_ShouldDoNothing(Dictionary<string, AbilityDetailsDto> abilityChecksums,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = false;

        checksumServiceMock.SetupSequence(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>())).Returns(false).Returns(false);

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>()), Times.Exactly(2));

        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(It.IsAny<AbilityDetailsDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(It.IsAny<int>(), It.IsAny<CreateAbilityDto>(), default), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(It.IsAny<int>(), It.IsAny<int>(), default), Times.Never);
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainAbilities_AndNewChecksumAndAlsoGodUpdated_ShouldCreateAbilityAndRelinkOther(Dictionary<string, AbilityDetailsDto> abilityChecksums, CreateAbilityDto createAbility,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;

        AbilityDetailsDto firstAbilityChecksum = abilityChecksums.Values.First();
        AbilityDetailsDto secondAbilityChecksum = abilityChecksums.Values.Last();

        checksumServiceMock.SetupSequence(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>())).Returns(true).Returns(false);
        mapperServiceMock.Setup(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(firstAbilityChecksum)).Returns(createAbility);
        maintainGodsRepositoryMock.Setup(x => x.CreateAbilityAsync(godId, createAbility, default));
        maintainGodsRepositoryMock.Setup(x => x.UpdateAbilityRelationAsync(godId, secondAbilityChecksum.Id, default));

        // Act
        await sut.MaintainAbilitiesAsync(godId, godUpdated, abilityChecksums);

        // Assert
        checksumServiceMock.Verify(x => x.IsChecksumDifferent(It.IsAny<string>(), It.IsAny<AbilityDetailsDto>()), Times.Exactly(2));

        mapperServiceMock.Verify(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(firstAbilityChecksum), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.CreateAbilityAsync(godId, createAbility, default), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.UpdateAbilityRelationAsync(godId, secondAbilityChecksum.Id, default), Times.Once);
    }

    [Theory]
    [InlineAutoMoqData(false)]
    [InlineAutoMoqData(true)]
    internal async Task WhenMaintainGodSkins_AndNewChecksumFound_ShouldCreateGodSkin(bool godUpdated, GodSkinDto godSkin, CreateGodSkinDto createGodSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const string checksum = "checksum";
        const string otherChecksum = "otherChecksum";
        IEnumerable<GodSkinDto> godSkins = new List<GodSkinDto> { godSkin };
        IEnumerable<string> checksums = new List<string> { checksum };

        checksumServiceMock.Setup(x => x.CalculateChecksum(godSkin)).Returns(otherChecksum);
        mapperServiceMock.Setup(x => x.Map<GodSkinDto, CreateGodSkinDto>(godSkin)).Returns(createGodSkin);
        maintainGodsRepositoryMock.Setup(x => x.CreateGodSkinAsync(godId, createGodSkin, default));

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(godSkin), Times.Once);
        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(godSkin), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(godId, createGodSkin, default), Times.Once);

        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), default), Times.Never);
    }


    [Theory, AutoMoqData]
    internal async Task WhenMaintainGodSkins_AndNoNewChecksumFoundButGodUpdated_ShouldUpdateSkinRelation(GodSkinDto godSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;
        const string checksum = "checksum";
        IEnumerable<GodSkinDto> godSkins = new List<GodSkinDto> { godSkin };
        IEnumerable<string> checksums = new List<string> { checksum };

        checksumServiceMock.Setup(x => x.CalculateChecksum(godSkin)).Returns(checksum);

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(godSkin), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(godId, godSkin.SkinId1, godSkin.SkinId2, default), Times.Once);

        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(It.IsAny<int>(), It.IsAny<CreateGodSkinDto>(), default), Times.Never);
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainGodSkins_AndNoNewChecksumFoundAndGodsFound_ShouldDoNothing(GodSkinDto godSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = false;
        const string checksum = "checksum";
        IEnumerable<GodSkinDto> godSkins = new List<GodSkinDto> { godSkin };
        IEnumerable<string> checksums = new List<string> { checksum };

        checksumServiceMock.Setup(x => x.CalculateChecksum(godSkin)).Returns(checksum);

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(godSkin), Times.Once);

        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(It.IsAny<int>(), It.IsAny<CreateGodSkinDto>(), default), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), default), Times.Never);
    }

    [Theory]
    [InlineAutoMoqDataList(2, false)]
    [InlineAutoMoqDataList(2, true)]
    internal async Task WhenMaintainGodSkins_AndMultipleNewChecksumsFound_ShouldCreateGodSkins(bool godUpdated, IEnumerable<GodSkinDto> godSkins, CreateGodSkinDto createGodSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const string checksum = "checksum";
        const string otherChecksum = "otherChecksum";
        IEnumerable<string> checksums = new List<string> { checksum, checksum };

        checksumServiceMock.SetupSequence(x => x.CalculateChecksum(It.IsAny<GodSkinDto>())).Returns(otherChecksum).Returns(otherChecksum);
        mapperServiceMock.SetupSequence(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>())).Returns(createGodSkin).Returns(createGodSkin);
        maintainGodsRepositoryMock.Setup(x => x.CreateGodSkinAsync(godId, createGodSkin, default));

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(It.IsAny<GodSkinDto>()), Times.Exactly(2));
        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>()), Times.Exactly(2));
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(godId, createGodSkin, default), Times.Exactly(2));

        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), default), Times.Never);
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainGodSkins_AndNoNewChecksumsButGodUpdated_ShouldUpdateSkinRelation(IEnumerable<GodSkinDto> godSkins,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;
        const string checksum = "checksum";
        IEnumerable<string> checksums = new List<string> { checksum, checksum };

        checksumServiceMock.SetupSequence(x => x.CalculateChecksum(It.IsAny<GodSkinDto>())).Returns(checksum).Returns(checksum);
        maintainGodsRepositoryMock.Setup(x => x.UpdateGodSkinRelationAsync(godId, It.IsAny<int>(), It.IsAny<int>(), default));

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(It.IsAny<GodSkinDto>()), Times.Exactly(2));
        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(godId, It.IsAny<int>(), It.IsAny<int>(), default), Times.Exactly(2));

        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(It.IsAny<int>(), It.IsAny<CreateGodSkinDto>(), default), Times.Never);
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainGodSkins_AndNewChecksumAndAlsoGodUpdated_ShouldCreateAbilityAndRelinkOther(IEnumerable<GodSkinDto> godSkins, CreateGodSkinDto createGodSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = true;
        const string checksum = "checksum";
        const string otherChecksum = "otherChecksum";
        IEnumerable<string> checksums = new List<string> { checksum, checksum };

        GodSkinDto firstGodSkin = godSkins.First();
        GodSkinDto secondGodSkin = godSkins.Last();

        checksumServiceMock.SetupSequence(x => x.CalculateChecksum(It.IsAny<GodSkinDto>())).Returns(otherChecksum).Returns(checksum);
        mapperServiceMock.Setup(x => x.Map<GodSkinDto, CreateGodSkinDto>(firstGodSkin)).Returns(createGodSkin);
        maintainGodsRepositoryMock.Setup(x => x.CreateGodSkinAsync(godId, createGodSkin, default));
        maintainGodsRepositoryMock.Setup(x => x.UpdateGodSkinRelationAsync(godId, secondGodSkin.SkinId1, secondGodSkin.SkinId2, default));

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(It.IsAny<GodSkinDto>()), Times.Exactly(2));
        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(firstGodSkin), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(godId, createGodSkin, default), Times.Once);
        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(godId, secondGodSkin.SkinId1, secondGodSkin.SkinId2, default), Times.Once);
    }

    [Theory, AutoMoqDataList(2)]
    internal async Task WhenMaintainGodSkins_AndNoNewChecksumsAndNoGodUpdated_ShouldDoNothing(IEnumerable<GodSkinDto> godSkins,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IChecksumService> checksumServiceMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;
        const bool godUpdated = false;
        const string checksum = "checksum";
        IEnumerable<string> checksums = new List<string> { checksum, checksum };

        checksumServiceMock.SetupSequence(x => x.CalculateChecksum(It.IsAny<GodSkinDto>())).Returns(checksum).Returns(checksum);

        // Act
        await sut.MaintainGodSkinsAsync(godId, godUpdated, godSkins, checksums);

        // Assert
        checksumServiceMock.Verify(x => x.CalculateChecksum(It.IsAny<GodSkinDto>()), Times.Exactly(2));

        mapperServiceMock.Verify(x => x.Map<GodSkinDto, CreateGodSkinDto>(It.IsAny<GodSkinDto>()), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.CreateGodSkinAsync(It.IsAny<int>(), It.IsAny<CreateGodSkinDto>(), default), Times.Never);
        maintainGodsRepositoryMock.Verify(x => x.UpdateGodSkinRelationAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), default), Times.Never);
    }

    [Theory, AutoMoqData]
    internal async Task WhenGetGodChecksums_ShouldReturnGodChecksums(IEnumerable<GodChecksumsDto> godChecksums,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        MaintainGodsService sut)
    {
        // Arrange
        maintainGodsRepositoryMock.Setup(x => x.GetGodChecksumsAsync(default)).ReturnsAsync(godChecksums).Verifiable();

        // Act
        IEnumerable<GodChecksumsDto> result = await sut.GetGodChecksumsAsync();

        // Assert
        result.Should().BeEquivalentTo(godChecksums);

        maintainGodsRepositoryMock.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateGod_ShouldReturnGodId(GodDto god, CreateGodDto createGod,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int createdGodId = 1;

        mapperServiceMock.Setup(x => x.Map<GodDto, CreateGodDto>(god)).Returns(createGod).Verifiable();
        maintainGodsRepositoryMock.Setup(x => x.CreateGodAsync(createGod, default)).ReturnsAsync(createdGodId).Verifiable();

        // Act
        int result = await sut.CreateGodAsync(god);

        // Assert
        result.Should().Be(createdGodId);

        mapperServiceMock.Verify();
        maintainGodsRepositoryMock.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateAbility_ShouldReturnAbilityId(AbilityDetailsDto abilityDetails, CreateAbilityDto createAbility,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;

        mapperServiceMock.Setup(x => x.Map<AbilityDetailsDto, CreateAbilityDto>(abilityDetails)).Returns(createAbility).Verifiable();
        maintainGodsRepositoryMock.Setup(x => x.CreateAbilityAsync(godId, createAbility, default)).Verifiable();

        // Act
        await sut.CreateAbilityAsync(godId, abilityDetails);

        // Assert
        mapperServiceMock.Verify();
        maintainGodsRepositoryMock.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateGodSkin_ShouldReturnGodSkinId(GodSkinDto godSkin, CreateGodSkinDto createGodSkin,
        [Frozen] Mock<IMaintainGodsRepository> maintainGodsRepositoryMock,
        [Frozen] Mock<IMapperService> mapperServiceMock,
        MaintainGodsService sut)
    {
        // Arrange
        const int godId = 1;

        mapperServiceMock.Setup(x => x.Map<GodSkinDto, CreateGodSkinDto>(godSkin)).Returns(createGodSkin).Verifiable();
        maintainGodsRepositoryMock.Setup(x => x.CreateGodSkinAsync(godId, createGodSkin, default)).Verifiable();

        // Act
        await sut.CreateGodSkinAsync(godId, godSkin);

        // Assert
        mapperServiceMock.Verify();
        maintainGodsRepositoryMock.Verify();
    }
}
