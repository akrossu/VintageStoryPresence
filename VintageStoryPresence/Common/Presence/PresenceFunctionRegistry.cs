using System;
using System.Collections.Generic;

namespace VintageStoryPresence.Common.Presence;

public static class PresenceFunctionRegistry
{
    private static readonly Dictionary<string, Func<PresenceContext, string>> Map = new();

    public static void Register(string key, Func<PresenceContext, string> func)
    {
        Map[key] = func;
        PresenceCore.Log.Notification("Registered " + key);
    }

    public static bool TryResolve(string key, PresenceContext context, out string? value)
    {
        if (Map.TryGetValue(key, out var func))
        {
            value = func(context);
            return true;
        }

        value = null;
        PresenceCore.Log.Notification("Presence not found: " + key);
        return false;
    }
}