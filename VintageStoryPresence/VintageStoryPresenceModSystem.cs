using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryPresence.Common;
using VintageStoryPresence.Common.Config;
using VintageStoryPresence.Common.Patches;
using VintageStoryPresence.Common.Presence;
using VintageStoryPresence.Common.Runtime;
using VintageStoryPresence.Common.Services;

namespace VintageStoryPresence;

public class VintageStoryPresenceModSystem : ModSystem
{
    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        
        PresenceCore.Initialize(api, Mod);
        ConfigLibPatch.Initialize(api);
    }

    public override void StartClientSide(ICoreClientAPI capi)
    {
        base.StartClientSide(capi);

        PresenceCore.InitializeClient(capi);
        PresenceCommands.RegisterDefaults();
        DiscordRpcService.InitializeDiscordRpc(ConfigManager.Config.AppId);
        
        PresenceUpdater.Start();
    }

    public override void Dispose()
    {
        DiscordRpcService.Dispose();
        PresenceUpdater.Dispose();
        
        base.Dispose();
    }
}