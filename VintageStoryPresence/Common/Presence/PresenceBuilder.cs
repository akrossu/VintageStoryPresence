using DiscordRPC;
using VintageStoryPresence.Common.Config;

namespace VintageStoryPresence.Common.Presence;

public static class PresenceBuilder
{
    public static RichPresence Build(PresenceContext ctx)
    {
        return new RichPresence
        {
            Details = PresenceResolver.Resolve(ConfigManager.Config.Details, ctx) ?? ConfigManager.Config.Details,
            State = PresenceResolver.Resolve(ConfigManager.Config.State, ctx) ?? ConfigManager.Config.State,

            Assets = new Assets
            {
                LargeImageText = PresenceResolver.Resolve(ConfigManager.Config.LargeImageText, ctx) ?? ConfigManager.Config.LargeImageText,
                SmallImageText = PresenceResolver.Resolve(ConfigManager.Config.SmallImageText, ctx) ?? ConfigManager.Config.SmallImageText,

                LargeImageKey = ConfigManager.Config.LargeImageKey,
                SmallImageKey = ConfigManager.Config.SmallImageKey
            }
        };
    }
}