namespace VintageStoryPresence.Common.Config;

/// <summary>
/// Default Config Values
/// This is set when configlib is not installed
/// </summary>
public class PresenceConfig
{
    public string AppId { get; set; } = "1441987315235946546";
    public string Details { get; set; } = "In {GameMode} Mode";
    public string State { get; set; } = "Playing {PlayerModeFormatted}";
    public string LargeImageKey { get; set; } = "game_icon"; 
    public string LargeImageText { get; set; } = "Vintage Story";
    public string SmallImageKey { get; set; } = "";
    public string SmallImageText { get; set; } = "";
}