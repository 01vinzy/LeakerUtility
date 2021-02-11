using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LeakerUtility.Models
{
    public class FortniteAPIResponse<T>
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }
    }

    public class Calendar
    {
        [JsonProperty("channels")]
        public Dictionary<string, Channel> Channels { get; set; }
    }

    public class Channel
    {
        [JsonProperty("states")]
        public List<ChannelState> States { get; set; }

        [JsonProperty("cacheExpire")]
        public DateTime CacheExpire { get; set; }
    }

    public class ChannelState
    {
        [JsonProperty("validFrom")]
        public DateTime ValidFrom { get; set; }

        [JsonProperty("activeEvents")]
        public List<ActiveEvent> ActiveEvents { get; set; }

        [JsonProperty("state")]
        public dynamic State { get; set; }
    }

    public class ActiveEvent
    {
        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("activeUntil")]
        public DateTime ActiveUntil { get; set; }

        [JsonProperty("activeSince")]
        public DateTime ActiveSince { get; set; }
    }

    public class NewsData
    {
        [JsonProperty("br")]
        public News BattleRoyaleNews { get; set; }

        [JsonProperty("stw")]
        public News SaveTheWorldNews { get; set; }

        [JsonProperty("creative")]
        public News CreativeNews { get; set; }
    }

    public class News
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("motds")]
        public List<NewsMOTD> NewsMOTDs { get; set; }

        [JsonProperty("messages")]
        public List<NewsMessage> NewsMessages { get; set; }
    }

    public class NewsMessage
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("adspace")]
        public string Adspace { get; set; }
    }

    public class NewsMOTD
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("tabTitle")]
        public string TabTitle { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("tileImage")]
        public string TileImage { get; set; }

        [JsonProperty("sortingPriority")]
        public int SortingPriority { get; set; }

        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }

    public class NewCosmetics
    {
        [JsonProperty("build")]
        public string Build { get; set; }

        [JsonProperty("previousBuild")]
        public string PreviousBuild { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("lastAddition")]
        public DateTime LastAddition { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public Info Type { get; set; }

        [JsonProperty("rarity")]
        public Info Rarity { get; set; }

        [JsonProperty("series")]
        public Info Series { get; set; }

        [JsonProperty("set")]
        public Info Set { get; set; }

        [JsonProperty("introduction")]
        public Introduction Introduction { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; set; }

        [JsonProperty("gameplayTags")]
        public List<string> GameplayTags { get; set; }

        [JsonProperty("showcaseVideo")]
        public string ShowcaseVideo { get; set; }

        [JsonProperty("displayAssetPath")]
        public string DisplayAssetPath { get; set; }

        [JsonProperty("definitionPath")]
        public string DefinitionPath { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("added")]
        public DateTime Added { get; set; }

        [JsonProperty("shopHistory")]
        public List<DateTime> ShopHistory { get; set; }
    }

    public class Variant
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("options")]
        public List<VariantOptions> Options { get; set; }
    }

    public class VariantOptions
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }

    public class Info
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("backendValue")]
        public string BackendValue { get; set; }
    }

    public class Introduction
    {
        [JsonProperty("chapter")]
        public string Chapter { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("backendValue")]
        public int BackendValue { get; set; }
    }

    public class Images
    {
        [JsonProperty("smallIcon")]
        public string SmallIcon { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("featured")]
        public string Featured { get; set; }

        [JsonProperty("other")]
        public string Other { get; set; }
    }

    public class Map
    {
        [JsonProperty("images")]
        public MapImages Images { get; set; }

        [JsonProperty("pois")]
        public List<POI> POIs { get; set; }
    }

    public class MapImages
    {
        [JsonProperty("blank")]
        public string Blank { get; set; }

        [JsonProperty("pois")]
        public string POIs { get; set; }
    }

    public class POI
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("x")]
        public float X { get; set; }

        [JsonProperty("y")]
        public float Y { get; set; }

        [JsonProperty("z")]
        public float Z { get; set; }
    }

    public class AES
    {
        [JsonProperty("build")]
        public string Build { get; set; }

        [JsonProperty("mainKey")]
        public string MainKey { get; set; }

        [JsonProperty("dynamicKeys")]
        public List<DynamicKey> DynamicKeys { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }
    }

    public class DynamicKey
    {
        [JsonProperty("pakFilename")]
        public string PakFilename { get; set; }

        [JsonProperty("pakGuid")]
        public string PakGuid { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
