using Vintagestory.API.Common;
using VintageStoryPresence.Common.Config;

namespace VintageStoryPresence.Common;

public static class PresenceCore
{
    public static ICoreAPI Api { get; private set; } = null!;
    public static ILogger Log { get; private set; } = null!;
    public static string ModId { get; private set; } = null!;

    public static PresenceConfig Config { get; private set; } = null!;

    public static void Initialize(ICoreAPI api, Mod mod)
    {
        Api = api;
        Log = mod.Logger;
        ModId = mod.Info.ModID;
        
        Config = new PresenceConfig();
        
        Log.Debug("Initialized PresenceCore");
    }
}