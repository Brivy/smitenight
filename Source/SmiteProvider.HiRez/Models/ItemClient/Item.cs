using Smitenight.Providers.SmiteProvider.HiRez.Models.Common;
using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.ItemClient
{
    public record class Item
    {
        [JsonPropertyName("ActiveFlag")] public string? ActiveFlag { get; set; }
        [JsonPropertyName("ChildItemId")] public int ChildItemId { get; set; }
        [JsonPropertyName("DeviceName")] public string? DeviceName { get; set; }
        [JsonPropertyName("Glyph")] public string? Glyph { get; set; }
        [JsonPropertyName("IconId")] public int IconId { get; set; }
        [JsonPropertyName("ItemDescription")] public ItemDescription ItemDescription { get; set; } = null!;
        [JsonPropertyName("ItemId")] public int ItemId { get; set; }
        [JsonPropertyName("ItemTier")] public int ItemTier { get; set; }
        [JsonPropertyName("Price")] public int Price { get; set; }
        [JsonPropertyName("RestrictedRoles")] public string? RestrictedRoles { get; set; }
        [JsonPropertyName("RootItemId")] public int RootItemId { get; set; }
        [JsonPropertyName("ShortDesc")] public string? ShortDesc { get; set; }
        [JsonPropertyName("StartingItem")] public bool StartingItem { get; set; }
        [JsonPropertyName("Type")] public string? Type { get; set; }
        [JsonPropertyName("itemIcon_URL")] public string? ItemIconUrl { get; set; }
        [JsonPropertyName("ret_msg")] public string? RetMsg { get; set; }
    }

    public record class ItemDescription
    {
        [JsonPropertyName("Description")] public string? Description { get; set; }
        [JsonPropertyName("Menuitems")] public CommonItem[] ItemSubDescriptions { get; set; } = null!;
        [JsonPropertyName("SecondaryDescription")] public string? SecondaryDescription { get; set; }
    }
}
