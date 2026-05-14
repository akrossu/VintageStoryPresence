using System;
using DiscordRPC;

namespace VintageStoryPresence.Common.Services;

public static class DiscordRpcService
{
    private static DiscordRpcClient? _discordRpcClient;
    private static bool IsReady => _discordRpcClient?.IsInitialized == true;
    
    public static void InitializeDiscordRpc(string appId)
    {
        try
        {
            _discordRpcClient = new DiscordRpcClient(appId);
            _discordRpcClient.Initialize();
        }
        catch (Exception e)
        {
            PresenceCore.Log.Error("Failed to initialize DiscordRpc: " + e);
        }
    }
    
    public static void SetPresence(RichPresence presence)
    {
        if (!IsReady)
        {
            PresenceCore.Log.Warning("Discord RPC not ready");
            return;
        }

        _discordRpcClient!.SetPresence(presence);
    }

    public static void Dispose()
    {
        _discordRpcClient?.Dispose();
        _discordRpcClient = null;
        PresenceCore.Log.Debug("DiscordRpc Client Disposed");
    }
}