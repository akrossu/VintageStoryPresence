using System;
using DiscordRPC;
using VintageStoryPresence.Common.Config;
using VintageStoryPresence.Common.Services;

namespace VintageStoryPresence.Common.Runtime;

public static class PresenceUpdater
{
    private static long _listenerId;
    private static DateTime _startTime;
    
    public static void Start()
    {
        _startTime = DateTime.UtcNow;
        _listenerId = PresenceCore.Api.Event.RegisterGameTickListener(UpdatePresence, 5000);
    }

    private static void UpdatePresence(float obj)
    {
        try
        {
            RichPresence presence = new RichPresence
            {
                Details = ConfigManager.Config.Details,
                State = ConfigManager.Config.State,
                Assets = new Assets
                {
                    LargeImageKey = ConfigManager.Config.LargeImageKey,
                    LargeImageText = ConfigManager.Config.LargeImageText,
                    SmallImageKey = ConfigManager.Config.SmallImageKey,
                    SmallImageText = ConfigManager.Config.SmallImageText
                },
                Timestamps = new Timestamps(_startTime)
            };
            
            DiscordRpcService.SetPresence(presence);
        }
        catch (Exception e)
        {
            PresenceCore.Log.Error("Failed to set presence: " + e);
        }
    }

    public static void Dispose()
    {
        PresenceCore.Api.Event.UnregisterGameTickListener(_listenerId);
        PresenceCore.Log.Debug("Game Tick Listener Disposed");
    }
}