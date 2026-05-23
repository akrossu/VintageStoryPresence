namespace VintageStoryPresence.Common.Presence.Context;

public class PresenceContext
{
    public string PlayerName { get; set; }
    public string PlayerCount { get; set; }
    public string PlayerCountFormatted { get; set; }

    public string ServerName { get; set; }
    public string WorldName { get; set; }

    public string GameMode { get; set; }
    
    public string PlayerMode { get; set; }
    public string PlayerModeFormatted { get; set; }

}