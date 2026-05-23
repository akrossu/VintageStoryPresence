namespace VintageStoryPresence.Common.Config;

/// <summary>
/// Default Config Values
/// This is set when configlib is not installed
/// </summary>
public class PresenceConfig
{
    public string DefaultAppId { get; private set; } = "1441987315235946546";
    public string AppId { get; set; } = "1441987315235946546";
    public bool AppIdToggle { get; set; } = false;
    public string Details { get; set; } = "In {{GameMode}} Mode";
    public string DetailsUrl { get; set; } = "";
    public string State { get; set; } = "Playing {{PlayerMode}}";
    public string StateUrl { get; set; } = "";
    public string LargeImageKey { get; set; } = "game_icon"; 
    public string LargeImageText { get; set; } = "Vintage Story";
    public string LargeImageUrl { get; set; } = "https://www.vintagestory.at/";
    public string SmallImageKey { get; set; } = "temp_gear_icon";
    public string SmallImageText { get; set; } = "Vintage Story Presence";
    public string SmallImageUrl { get; set; } = "https://mods.vintagestory.at/vintagestorypresence";
}