namespace VintageStoryPresence.Common.Presence;

public static class PresenceCommands
{
    public static void RegisterDefaults()
    {
        PresenceFunctionRegistry.Register("PlayerName",
            ctx => ctx.PlayerName);

        PresenceFunctionRegistry.Register("PlayerCount",
            ctx => ctx.PlayerCount);

        PresenceFunctionRegistry.Register("ServerName",
            ctx => ctx.ServerName);

        PresenceFunctionRegistry.Register("WorldName",
            ctx => ctx.WorldName);

        PresenceFunctionRegistry.Register("GameMode",
            ctx => ctx.GameMode);
    }
}