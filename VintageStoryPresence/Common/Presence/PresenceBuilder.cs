using DiscordRPC;
using VintageStoryPresence.Common.Config;

namespace VintageStoryPresence.Common.Presence;

public static class PresenceBuilder
{
    public static RichPresence Build(PresenceContext context)
    {
        return new RichPresence
        {
            Details = PresenceResolver.Resolve(ConfigManager.Config.Details, context) ?? ConfigManager.Config.Details,
            State = PresenceResolver.Resolve(ConfigManager.Config.State, context) ?? ConfigManager.Config.State,

            Assets = new Assets
            {
                LargeImageText = PresenceResolver.Resolve(ConfigManager.Config.LargeImageText, context) ?? ConfigManager.Config.LargeImageText,
                SmallImageText = PresenceResolver.Resolve(ConfigManager.Config.SmallImageText, context) ?? ConfigManager.Config.SmallImageText,

                LargeImageKey = ConfigManager.Config.LargeImageKey,
                SmallImageKey = ConfigManager.Config.SmallImageKey
            }
        };
    }
}