using ConfigLib;
using Vintagestory.API.Common;
using VintageStoryPresence.Common.Config;

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
        };

        system.ConfigsLoaded += () =>
        {
            system.GetConfig(PresenceCore.ModId)?.AssignSettingsValues(ConfigManager.Config);
        };
    }
}