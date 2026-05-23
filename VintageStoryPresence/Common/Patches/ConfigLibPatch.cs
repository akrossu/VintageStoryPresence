using ConfigLib;
using Vintagestory.API.Common;
using VintageStoryPresence.Common.Config;
using VintageStoryPresence.Common.Services;

namespace VintageStoryPresence.Common.Patches;

public static class ConfigLibPatch
{
    public static void Initialize(ICoreAPI api)
    {
        if (!api.ModLoader.IsModEnabled("configlib"))
        {
            PresenceCore.Log.Warning("ConfigLib not found (optional)");
            
            // set default values when ConfigLib is enabled, then disabled on next world load
            ConfigManager.Config = new PresenceConfig();
            return;
        }
        
        Subscribe(api);
    }

    private static void Subscribe(ICoreAPI api)
    {
        ConfigLibModSystem system = api.ModLoader.GetModSystem<ConfigLibModSystem>();

        system.SettingChanged += (domain, _, setting) =>
        {
            if (domain != PresenceCore.ModId) return;

            setting.AssignSettingValue(ConfigManager.Config);

            switch (setting.YamlCode)
            {
                // if the app id changes, the user should not have to reload the world
                // Only applies if the AppIdToggle is set to true
                // it disposes the old application with the old id
                // and creates a new application with the new id
                case nameof(PresenceConfig.AppId):
                    if (ConfigManager.Config.AppIdToggle) SetCustomAppId();
                    break;
                
                // Acts as a fallback for when a custom AppId does not want to be used
                // without having to restore defaults every time
                case nameof(PresenceConfig.AppIdToggle):
                    if (ConfigManager.Config.AppIdToggle) SetCustomAppId();
                    else
                    {
                        DiscordRpcService.Dispose();
                        
                        // provides the game's official discord application id
                        DiscordRpcService.InitializeDiscordRpc(ConfigManager.Config.DefaultAppId);                       
                    }
                    break;
            }
        };

        system.ConfigsLoaded += () =>
        {
            system.GetConfig(PresenceCore.ModId)?.AssignSettingsValues(ConfigManager.Config);
        };
    }

    private static void SetCustomAppId()
    {
        DiscordRpcService.Dispose();
        DiscordRpcService.InitializeDiscordRpc(ConfigManager.Config.AppId);
        PresenceCore.Log.Warning("Set to new AppId: " + ConfigManager.Config.AppId);
    }
}