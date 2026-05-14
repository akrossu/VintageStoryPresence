using System;
using DiscordRPC;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryPresence.Common.Config;
using VintageStoryPresence.Common.Presence;
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

    private static void UpdatePresence(float deltaTime)
    {
        try
        {
            PresenceContext ctx = BuildContext(deltaTime);

            RichPresence presence = PresenceBuilder.Build(ctx);
            presence.Timestamps = new Timestamps(_startTime);
            
            DiscordRpcService.SetPresence(presence);
        }
        catch (Exception e)
        {
            PresenceCore.Log.Error("Failed to set presence: " + e);
        }
    }

    private static PresenceContext BuildContext(float delta)
    {
        ICoreAPI? api = PresenceCore.Api;
        ICoreClientAPI? capi = PresenceCore.Capi;
        IWorldAccessor? world = api?.World;
        
        int onlinePlayers = world?.AllOnlinePlayers?.Length ?? 0;
        bool isSinglePlayer = capi?.IsSinglePlayer ?? false;
        
        return new PresenceContext
        {
            DeltaTime = delta,
            
            PlayerName = "Player Name",
            
            PlayerCount = (onlinePlayers == 1) ? "1 Player Online" : $"{onlinePlayers} Players Online",

            ServerName = "Server Name",
            WorldName = "World Name",
            
            GameMode = isSinglePlayer ? "Singleplayer" : "Multiplayer"
        };
    }
    
    public static void Dispose()
    {
        PresenceCore.Api.Event.UnregisterGameTickListener(_listenerId);
        PresenceCore.Log.Debug("Game Tick Listener Disposed");
    }
}