using System.Text.RegularExpressions;

namespace VintageStoryPresence.Common.Presence;

public static partial class PresenceResolver
{
    private static readonly Regex PlaceholderRegex = MyRegex();
    
    public static string? Resolve(string command, PresenceContext context)
    {
        if (string.IsNullOrWhiteSpace(command)) return string.Empty;
        
        command = command
            .Replace("{{", "{")
            .Replace("}}", "}");
        
        return PlaceholderRegex.Replace(command, match =>
        {
            string key = match.Groups[1].Value;

            if (PresenceFunctionRegistry.TryResolve(key, context, out string? value))
                return value ?? string.Empty;

            /*
             * raw text fallback
             * preserves unkown placeholders as literals
             * that way downstream string.Format doesn't
             * attempt to parse them
             */
            return "{{" + key + "}}";
        });
    }

    [GeneratedRegex(@"(?<!\{)\{(.*?)}(?!})", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}