namespace VintageStoryPresence.Common.Presence;

public static class PresenceCommands
{
    public static void RegisterDefaults()
    {
        PresenceFunctionRegistry.Register("PlayerName",
            context => context.PlayerName);

        PresenceFunctionRegistry.Register("PlayerCount",
            context => context.PlayerCount);
        
        PresenceFunctionRegistry.Register("PlayerCountFormatted",
            context => context.PlayerCountFormatted);

        PresenceFunctionRegistry.Register("ServerName",
            context => context.ServerName);

        PresenceFunctionRegistry.Register("WorldName",
            context => context.WorldName);

        PresenceFunctionRegistry.Register("PlayerMode",
            context => context.PlayerMode);
        
        PresenceFunctionRegistry.Register("PlayerModeFormatted",
            context => context.PlayerModeFormatted);
        
        PresenceFunctionRegistry.Register("GameMode",
            context => context.GameMode);
    }
}