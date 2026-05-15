using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryPresence.Common.Presence.Context;

public static class PresenceContextBuilder
{
    public static PresenceContext BuildContext(float delta)
    {
        ICoreAPI? api = PresenceCore.Api;
        ICoreClientAPI? capi = PresenceCore.Capi;
        IWorldAccessor? world = api?.World;
        
        int onlinePlayers = world?.AllOnlinePlayers?.Length ?? 0;
        bool isSinglePlayer = capi?.IsSinglePlayer ?? false;
        string currentGameMode = capi?.World.Player.WorldData.CurrentGameMode.ToString() ?? "no game";
        
        string playerModeFormatted;
        if (onlinePlayers > 1)
            playerModeFormatted = onlinePlayers > 2 ? $"with {onlinePlayers-1} others" : $"with {onlinePlayers-1} other";
        else
            playerModeFormatted = "Solo";
        
        return new PresenceContext
        {
            DeltaTime = delta,
            
            PlayerName = "Player Name",
            
            PlayerCount = onlinePlayers.ToString(),
            PlayerCountFormatted = onlinePlayers > 1 ? $"with {onlinePlayers} others" : $"with {onlinePlayers} other",

            ServerName = "Server Name",
            WorldName = "World Name",
            
            PlayerMode = isSinglePlayer ? "Solo" : "Online",
            PlayerModeFormatted = playerModeFormatted,
            
            GameMode = currentGameMode
        };
        
    }
}