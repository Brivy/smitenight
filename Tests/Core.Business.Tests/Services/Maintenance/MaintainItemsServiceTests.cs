using Moq;
using Smitenight.Application.Core.Business.Contracts.Services.Checksums;
using Smitenight.Application.Core.Business.Services.Maintenance;
using Smitenight.AutoMoqData.Common.Attributes;
using Smitenight.Persistence.Data.Contracts.Models;
using Smitenight.Persistence.Data.Contracts.Repositories;
using Smitenight.Providers.SmiteProvider.Contracts.Constants;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Utilities.Mapper.Services;

namespace Smitenight.Core.Business.Tests.Mainenance;

public class MaintainItemsServiceTests
{
    [Theory, AutoMoqData]
    internal async Task WhenMaintainItemAsync_AndItemItemChecksumIsDifferent_ShouldReturnsNewItemItemId(ItemDto item, CreateItemDto createItem,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IChecksumService> checksumService,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newItemId = 1;
        const string checksum = "checksum";

        ItemDto itemItem = item with { Type = ItemConstants.ItemType };

        checksumService.Setup(x => x.IsChecksumDifferent(checksum, itemItem)).Returns(true).Verifiable();
        mapperService.Setup(x => x.Map<ItemDto, CreateItemDto>(itemItem)).Returns(createItem).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateItemAsync(createItem, default)).ReturnsAsync(newItemId).Verifiable();

        // Act
        int? result = await sut.MaintainItemAsync(itemItem, checksum);

        // Assert
        result.Should().NotBeNull()
            .And.Be(newItemId);

        checksumService.Verify();
        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainItemAsync_AndActiveItemChecksumIsDifferent_ShouldReturnsNewActiveItemId(ItemDto item, CreateActiveDto createActive,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IChecksumService> checksumService,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newActiveId = 1;
        const string checksum = "checksum";

        ItemDto activeItem = item with { Type = ItemConstants.ActiveItemType };

        checksumService.Setup(x => x.IsChecksumDifferent(checksum, activeItem)).Returns(true).Verifiable();
        mapperService.Setup(x => x.Map<ItemDto, CreateActiveDto>(activeItem)).Returns(createActive).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateActiveAsync(createActive, default)).ReturnsAsync(newActiveId).Verifiable();

        // Act
        int? result = await sut.MaintainItemAsync(activeItem, checksum);

        // Assert
        result.Should().NotBeNull()
            .And.Be(newActiveId);

        checksumService.Verify();
        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainItemAsync_AndConsumableItemChecksumIsDifferent_ShouldReturnsNewConsumableItemId(ItemDto item, CreateConsumableDto createConsumable,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IChecksumService> checksumService,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newConsumableId = 1;
        const string checksum = "checksum";

        ItemDto consumableItem = item with { Type = ItemConstants.ConsumableItemType };

        checksumService.Setup(x => x.IsChecksumDifferent(checksum, consumableItem)).Returns(true).Verifiable();
        mapperService.Setup(x => x.Map<ItemDto, CreateConsumableDto>(consumableItem)).Returns(createConsumable).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateConsumableAsync(createConsumable, default)).ReturnsAsync(newConsumableId).Verifiable();

        // Act
        int? result = await sut.MaintainItemAsync(consumableItem, checksum);

        // Assert
        result.Should().NotBeNull()
            .And.Be(newConsumableId);

        checksumService.Verify();
        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainItemAsync_AndUnknownItemChecksumIsDifferent_ShouldThrowsNotImplementedException(ItemDto item,
        [Frozen] Mock<IChecksumService> checksumService,
        MaintainItemsService sut)
    {
        // Arrange
        const string checksum = "checksum";

        ItemDto unknownItem = item with { Type = string.Empty };

        checksumService.Setup(x => x.IsChecksumDifferent(checksum, unknownItem)).Returns(true).Verifiable();

        // Act
        Func<Task> act = async () => await sut.MaintainItemAsync(unknownItem, checksum);

        // Assert
        await act.Should().ThrowAsync<NotImplementedException>();

        checksumService.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenMaintainItemAsync_AndChecksumIsNotDifferent_ShouldReturnsNull(ItemDto item,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IChecksumService> checksumService,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const string checksum = "checksum";

        ItemDto itemItem = item with { Type = ItemConstants.ItemType };

        checksumService.Setup(x => x.IsChecksumDifferent(checksum, itemItem)).Returns(false).Verifiable();

        // Act
        int? result = await sut.MaintainItemAsync(itemItem, checksum);

        // Assert
        result.Should().BeNull();

        checksumService.Verify();
        mapperService.Verify(x => x.Map<ItemDto, CreateItemDto>(It.IsAny<ItemDto>()), Times.Never);
        maintainItemsRepository.Verify(x => x.CreateItemAsync(It.IsAny<CreateItemDto>(), default), Times.Never);
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateItemAsync_AndItemIsItemType_ShouldReturnsNewItemId(ItemDto item, CreateItemDto createItem,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newItemId = 1;

        ItemDto itemItem = item with { Type = ItemConstants.ItemType };

        mapperService.Setup(x => x.Map<ItemDto, CreateItemDto>(itemItem)).Returns(createItem).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateItemAsync(createItem, default)).ReturnsAsync(newItemId).Verifiable();

        // Act
        int result = await sut.CreateItemAsync(itemItem);

        // Assert
        result.Should().Be(newItemId);

        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateItemAsync_AndItemIsActiveItemType_ShouldReturnsNewActiveItemId(ItemDto item, CreateActiveDto createActive,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newActiveId = 1;

        ItemDto activeItem = item with { Type = ItemConstants.ActiveItemType };

        mapperService.Setup(x => x.Map<ItemDto, CreateActiveDto>(activeItem)).Returns(createActive).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateActiveAsync(createActive, default)).ReturnsAsync(newActiveId).Verifiable();

        // Act
        int result = await sut.CreateItemAsync(activeItem);

        // Assert
        result.Should().Be(newActiveId);

        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateItemAsync_AndItemIsConsumableItemType_ShouldReturnsNewConsumableItemId(ItemDto item, CreateConsumableDto createConsumable,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        [Frozen] Mock<IMapperService> mapperService,
        MaintainItemsService sut)
    {
        // Arrange
        const int newConsumableId = 1;

        ItemDto consumableItem = item with { Type = ItemConstants.ConsumableItemType };

        mapperService.Setup(x => x.Map<ItemDto, CreateConsumableDto>(consumableItem)).Returns(createConsumable).Verifiable();
        maintainItemsRepository.Setup(x => x.CreateConsumableAsync(createConsumable, default)).ReturnsAsync(newConsumableId).Verifiable();

        // Act
        int result = await sut.CreateItemAsync(consumableItem);

        // Assert
        result.Should().Be(newConsumableId);

        mapperService.Verify();
        maintainItemsRepository.Verify();
    }

    [Theory, AutoMoqData]
    internal async Task WhenCreateItemAsync_AndItemIsUnknownItemType_ShouldThrowsNotImplementedException(ItemDto item,
        MaintainItemsService sut)
    {
        // Arrange
        ItemDto unknownItem = item with { Type = string.Empty };

        // Act
        Func<Task> act = async () => await sut.CreateItemAsync(unknownItem);

        // Assert
        await act.Should().ThrowAsync<NotImplementedException>();
    }

    [Theory, AutoMoqData]
    internal async Task WhenLinkItemsAsync_AndNewRootLink_ShouldUpdateItemLink(ItemDto item, ItemLinkDto linkItem,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        MaintainItemsService sut)
    {
        // Arrange
        const int linkItemSmiteId = 1;

        linkItem.SmiteId = linkItemSmiteId;
        linkItem.OldItemId = null;
        linkItem.ChildItemId = null;
        linkItem.RootItemId = null;

        IEnumerable<int> relinkNeededSmiteIds = new[] { linkItemSmiteId };
        IEnumerable<ItemDto> items = new[] { item with { ItemId = linkItemSmiteId, RootItemId = linkItemSmiteId, ChildItemId = null } };

        maintainItemsRepository.Setup(x => x.GetItemForRelinkingAsync(relinkNeededSmiteIds, default)).ReturnsAsync(new[] { linkItem }).Verifiable();

        // Act
        await sut.LinkItemsAsync(items, relinkNeededSmiteIds);

        // Assert
        maintainItemsRepository.Verify(x => x.UpdateItemLinksAsync(It.Is<List<UpdateItemLinkDto>>(x =>
            x.Count() == 1 &&
            x[0].Id == linkItem.NewItemId &&
            x[0].ChildItemId == null &&
            x[0].RootItemId == linkItem.NewItemId), default), Times.Once);
    }

    [Theory, AutoMoqData]
    internal async Task WhenLinkItemsAsync_AndNewTwoItemTier_ShouldUpdateItemLinks(ItemDto itemTierOne, ItemDto itemTierTwo, ItemLinkDto linkItemTierOne, ItemLinkDto linkItemTierTwo,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        MaintainItemsService sut)
    {
        // Arrange
        const int linkItemTierOneSmiteId = 1;
        const int linkItemTierTwoSmiteId = 2;

        linkItemTierOne.SmiteId = linkItemTierOneSmiteId;
        linkItemTierOne.OldItemId = null;
        linkItemTierOne.ChildItemId = null;
        linkItemTierOne.RootItemId = null;

        linkItemTierTwo.SmiteId = linkItemTierTwoSmiteId;
        linkItemTierTwo.OldItemId = null;
        linkItemTierTwo.ChildItemId = null;
        linkItemTierTwo.RootItemId = null;

        IEnumerable<int> relinkNeededSmiteIds = new[] { linkItemTierOneSmiteId, linkItemTierTwoSmiteId };
        IEnumerable<ItemDto> items = new[] {
            itemTierOne with { ItemId = linkItemTierOneSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = null },
            itemTierTwo with { ItemId = linkItemTierTwoSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = linkItemTierOneSmiteId }
        };

        maintainItemsRepository.Setup(x => x.GetItemForRelinkingAsync(relinkNeededSmiteIds, default)).ReturnsAsync(new[] { linkItemTierOne, linkItemTierTwo }).Verifiable();

        // Act
        await sut.LinkItemsAsync(items, relinkNeededSmiteIds);

        // Assert
        maintainItemsRepository.Verify(x => x.UpdateItemLinksAsync(It.Is<List<UpdateItemLinkDto>>(x =>
            x.Count() == 2 &&
            x[0].Id == linkItemTierOne.NewItemId &&
            x[0].ChildItemId == null &&
            x[0].RootItemId == linkItemTierOne.NewItemId &&
            x[1].Id == linkItemTierTwo.NewItemId &&
            x[1].ChildItemId == linkItemTierOne.NewItemId &&
            x[1].RootItemId == linkItemTierOne.NewItemId), default), Times.Once);
    }

    [Theory, AutoMoqData]
    internal async Task WhenLinkItemsAsync_AndNewThreeItemTier_ShouldUpdateItemLinks(ItemDto itemTierOne, ItemDto itemTierTwo, ItemDto itemTierThree, ItemLinkDto linkItemTierOne, ItemLinkDto linkItemTierTwo, ItemLinkDto linkItemTierThree,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        MaintainItemsService sut)
    {
        // Arrange
        const int linkItemTierOneSmiteId = 1;
        const int linkItemTierTwoSmiteId = 2;
        const int linkItemTierThreeSmiteId = 3;

        linkItemTierOne.SmiteId = linkItemTierOneSmiteId;
        linkItemTierOne.OldItemId = null;
        linkItemTierOne.ChildItemId = null;
        linkItemTierOne.RootItemId = null;

        linkItemTierTwo.SmiteId = linkItemTierTwoSmiteId;
        linkItemTierTwo.OldItemId = null;
        linkItemTierTwo.ChildItemId = null;
        linkItemTierTwo.RootItemId = null;

        linkItemTierThree.SmiteId = linkItemTierThreeSmiteId;
        linkItemTierThree.OldItemId = null;
        linkItemTierThree.ChildItemId = null;
        linkItemTierThree.RootItemId = null;

        IEnumerable<int> relinkNeededSmiteIds = new[] { linkItemTierOneSmiteId, linkItemTierTwoSmiteId, linkItemTierThreeSmiteId };
        IEnumerable<ItemDto> items = new[] {
            itemTierOne with { ItemId = linkItemTierOneSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = null },
            itemTierTwo with { ItemId = linkItemTierTwoSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = linkItemTierOneSmiteId },
            itemTierThree with { ItemId = linkItemTierThreeSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = linkItemTierTwoSmiteId }
        };

        maintainItemsRepository.Setup(x => x.GetItemForRelinkingAsync(relinkNeededSmiteIds, default)).ReturnsAsync(new[] { linkItemTierOne, linkItemTierTwo, linkItemTierThree }).Verifiable();

        // Act
        await sut.LinkItemsAsync(items, relinkNeededSmiteIds);

        // Assert
        maintainItemsRepository.Verify();
        maintainItemsRepository.Verify(x => x.UpdateItemLinksAsync(It.Is<List<UpdateItemLinkDto>>(x =>
            x.Count() == 3 &&
            x[0].Id == linkItemTierOne.NewItemId &&
            x[0].ChildItemId == null &&
            x[0].RootItemId == linkItemTierOne.NewItemId &&
            x[1].Id == linkItemTierTwo.NewItemId &&
            x[1].ChildItemId == linkItemTierOne.NewItemId &&
            x[1].RootItemId == linkItemTierOne.NewItemId &&
            x[2].Id == linkItemTierThree.NewItemId &&
            x[2].ChildItemId == linkItemTierTwo.NewItemId &&
            x[2].RootItemId == linkItemTierOne.NewItemId), default), Times.Once);
    }

    [Theory, AutoMoqData]
    internal async Task WhenLinkItemsAsync_AndExistingRootLink_ShouldUpdateItemLink(ItemDto item, ItemLinkDto linkItem,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        MaintainItemsService sut)
    {
        // Arrange
        const int linkItemSmiteId = 1;
        const int oldItemId = 2;

        linkItem.SmiteId = linkItemSmiteId;
        linkItem.OldItemId = oldItemId;
        linkItem.ChildItemId = null;
        linkItem.RootItemId = oldItemId;

        IEnumerable<int> relinkNeededSmiteIds = new[] { linkItemSmiteId };
        IEnumerable<ItemDto> items = new[] { item with { ItemId = linkItemSmiteId, RootItemId = linkItemSmiteId, ChildItemId = null } };

        maintainItemsRepository.Setup(x => x.GetItemForRelinkingAsync(relinkNeededSmiteIds, default)).ReturnsAsync(new[] { linkItem }).Verifiable();

        // Act
        await sut.LinkItemsAsync(items, relinkNeededSmiteIds);

        // Assert
        maintainItemsRepository.Verify(x => x.UpdateItemLinksAsync(It.Is<List<UpdateItemLinkDto>>(x =>
            x.Count() == 1 &&
            x[0].Id == linkItem.NewItemId &&
            x[0].ChildItemId == null &&
            x[0].RootItemId == linkItem.NewItemId), default), Times.Once);
    }

    [Theory, AutoMoqData]
    internal async Task WhenLinkItemsAsync_AndExistingTwoItemTier_ShouldUpdateItemLinks(ItemDto itemTierOne, ItemDto itemTierTwo, ItemLinkDto linkItemTierOne, ItemLinkDto linkItemTierTwo,
        [Frozen] Mock<IMaintainItemsRepository> maintainItemsRepository,
        MaintainItemsService sut)
    {
        // Arrange
        const int linkItemTierOneSmiteId = 1;
        const int oldItemTierOneId = 2;
        const int linkItemTierTwoSmiteId = 3;
        const int oldItemTierTwoId = 4;

        linkItemTierOne.SmiteId = linkItemTierOneSmiteId;
        linkItemTierOne.OldItemId = oldItemTierOneId;
        linkItemTierOne.ChildItemId = null;
        linkItemTierOne.RootItemId = oldItemTierOneId;

        linkItemTierTwo.SmiteId = linkItemTierTwoSmiteId;
        linkItemTierTwo.OldItemId = oldItemTierTwoId;
        linkItemTierTwo.ChildItemId = oldItemTierOneId;
        linkItemTierTwo.RootItemId = oldItemTierOneId;

        IEnumerable<int> relinkNeededSmiteIds = new[] { linkItemTierOneSmiteId, linkItemTierTwoSmiteId };
        IEnumerable<ItemDto> items = new[] {
            itemTierOne with { ItemId = linkItemTierOneSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = null },
            itemTierTwo with { ItemId = linkItemTierTwoSmiteId, RootItemId = linkItemTierOneSmiteId, ChildItemId = linkItemTierOneSmiteId }
        };

        maintainItemsRepository.Setup(x => x.GetItemForRelinkingAsync(relinkNeededSmiteIds, default)).ReturnsAsync(new[] { linkItemTierOne, linkItemTierTwo }).Verifiable();

        // Act
        await sut.LinkItemsAsync(items, relinkNeededSmiteIds);

        // Assert
        maintainItemsRepository.Verify(x => x.UpdateItemLinksAsync(It.Is<List<UpdateItemLinkDto>>(x =>
            x.Count() == 2 &&
            x[0].Id == linkItemTierOne.NewItemId &&
            x[0].ChildItemId == null &&
            x[0].RootItemId == linkItemTierOne.NewItemId &&
            x[1].Id == linkItemTierTwo.NewItemId &&
            x[1].ChildItemId == linkItemTierOne.NewItemId &&
            x[1].RootItemId == linkItemTierOne.NewItemId), default), Times.Once);
    }
}
