using System;
using DiscordRPC;

namespace VintageStoryPresence.Common.Services;

public static class DiscordRpcService
{
    private static DiscordRpcClient? _client;
    private static bool IsReady => _client?.IsInitialized == true;
    
    public static void InitializeDiscordRpc(string appId)
    {
        try
        {
            _client = new DiscordRpcClient(appId);
            _client.Initialize();
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

        _client!.SetPresence(presence);
    }

    public static void Dispose()
    {
        _client?.Dispose();
        _client = null;
        PresenceCore.Log.Debug("DiscordRpc Client Disposed");
    }
}