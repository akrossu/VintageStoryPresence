using System.Text.RegularExpressions;

namespace VintageStoryPresence.Common.Presence;

public static class PresenceResolver
{
    private static readonly Regex PlaceholderRegex = new Regex(@"\{(.*?)\}", RegexOptions.Compiled);
    
    public static string? Resolve(string command, PresenceContext context)
    {
        if (string.IsNullOrWhiteSpace(command)) return string.Empty;
        
        return PlaceholderRegex.Replace(command, match =>
        {
            string key = match.Groups[1].Value;

            if (PresenceFunctionRegistry.TryResolve(key, context, out string? value))
                return value ?? string.Empty;

            // raw text fallback
            return match.Value;
        });
    }
}