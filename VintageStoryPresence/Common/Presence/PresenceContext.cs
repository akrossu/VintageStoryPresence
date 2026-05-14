namespace VintageStoryPresence.Common.Presence;

public class PresenceContext
{
    public float DeltaTime { get; set; }

    public string PlayerName { get; set; }
    public string PlayerCount { get; set; }

    public string ServerName { get; set; }
    public string WorldName { get; set; }

    public string GameMode { get; set; }

}