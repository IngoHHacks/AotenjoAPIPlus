using AotenjoAPIPlus.Classes;
using System.Text.RegularExpressions;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace AotenjoAPIPlus.Localization;

public static class LocalizationManager
{
    private static readonly Regex LocaleKeyPattern = new("^[a-zA-Z]{2}((-|_)[a-zA-Z]+)?$");
    private static readonly Regex LocaleKeyPatternExact = new("^[a-z]{2}(-[a-zA-Z]+)?$");

    internal static readonly Dictionary<string, StringHolder> Substitutions = new();
    
    public static string Loc(string key)
    {
        return GameLocalizationManager.GetLocalizedText(key);
    }

    public static void LoadLocalizationFromCsvFile(string file)
    {
        var lines = File.ReadAllLines(file);
        var header = ParseQuotedCSV(lines[0]);
        var keyColumnIndex = Array.IndexOf(header, "key");
        if (keyColumnIndex == -1)
        {
            throw new Exception("CSV file must contain a 'key' column.");
        }
        var localeColumns = new List<int>();
        for (int i = 0; i < header.Length; i++)
        {
            if (i == keyColumnIndex) continue;
            var locale = header[i];
            if (LocaleKeyPattern.IsMatch(locale))
            {
                if (!LocaleKeyPatternExact.IsMatch(locale))
                {
                    header[i] = (locale.Substring(0, 2).ToLower() + locale.Substring(2)).Replace('_', '-');
                    if (!LocaleKeyPatternExact.IsMatch(header[i]))
                    {
                        Logger.LogWarning($"Skipping invalid locale '{locale}' in column {i + 1} of {file}.");
                        continue;
                    }
                }
                if (LocalizationSettings.AvailableLocales.Locales.All(l => l.Identifier.Code != header[i]))
                {
                    continue;
                }
                var localeObj = ModLocalizationLoader.GetOrCreateLocale(locale);
                if (LocalizationSettings.StringDatabase.GetTable("GameTable", localeObj) == null)
                {
                    // Adding new tables doesn't work at the moment, so we'll skip any locales without existing tables
                    continue;
                }
                localeColumns.Add(i);
            }
        }
        var locTables = new List<StringTable[]>();
        foreach (var localeColumnIndex in localeColumns)
        {
            var langCode = header[localeColumnIndex];
            Locale locale = ModLocalizationLoader.GetOrCreateLocale(langCode);
            StringTable gameTable = ModLocalizationLoader.GetOrCreateStringTable("GameTable", locale);
            StringTable yakuInfo = ModLocalizationLoader.GetOrCreateStringTable("YakuInfo", locale);
            locTables.Add([gameTable, yakuInfo]);
        }

        for (int i = 1; i < lines.Length; i++)
        {
            var columns = ParseQuotedCSV(lines[i]);
            if (columns.Length != header.Length)
            {
                Logger.LogWarning($"Skipping malformed line {i + 1} in {file}: column count does not match header.");
                continue;
            }
            var key = columns[keyColumnIndex];
            for (int index = 0; index < localeColumns.Count; index++)
            {
                var localeColumnIndex = localeColumns[index];
                var value = columns[localeColumnIndex];
                var stringTables = locTables[index];
                foreach (var stringTable in stringTables)
                {
                    var entry = stringTable.GetEntry(key);
                    if (entry == null)
                    {
                        stringTable.AddEntry(key, value);
                    }
                    else
                    {
                        entry.Value = value;
                    }
                }
            }
        }
    }
    
    public static void RegisterSubstitution(string key, StringHolder substitution)
    {
        if (key.StartsWith("{"))
        {
            key = key.Substring(1);
        }
        if (key.EndsWith("}"))
        {
            key = key.Substring(0, key.Length - 1);
        }
        Substitutions[key] = substitution;
    }

    internal static readonly Regex SubstitutionPattern = new(@"\{(\D.*?)\}");
    
    public static string PostProcessLocalizedString(string s, int depth = 0)
    {
        bool modified = false;
        if (!SubstitutionPattern.IsMatch(s))
        {
            return s;
        }
        var newString = SubstitutionPattern.Replace(s, match =>
        {
            var key = match.Groups[1].Value;
            if (Substitutions.TryGetValue(key, out var stringHolder))
            {
                modified = true;
                return stringHolder.GetString();
            }
            return match.Value; // No substitution found, return original
        });
        if (modified)
        {
            if (SubstitutionPattern.IsMatch(newString))
            {
                if (depth >= 10)
                {
                    Logger.LogWarning("Maximum recursion depth reached in PostProcessLocalizedString. Possible circular substitution. String: " + newString);
                    return newString;
                }
                return PostProcessLocalizedString(newString, depth + 1); // Recursively process until no more substitutions
            }
        }
        return newString;
    }
    
    private static string[] ParseQuotedCSV(string line)
    {
        var pattern = new Regex(@"
            # Match one value in valid CSV string.
            (?!\s*$)                                      # Don't match empty last value.
            \s*                                           # Strip whitespace before value.
            (?:                                           # Group for value alternatives.
              '([^'\\]*(?:\\.[^'\\]*)*)'                  # Single quoted string.
            | ""([^""\\]*(?:\\.[^""\\]*)*)""              # Double quoted string.
            | ([^,'""]+)                                  # Non-comma, non-quote stuff.
            )                                             # End group of value alternatives.
            \s*                                           # Strip whitespace after value.
            (?:,|$)                                       # Field ends on comma or EOS.
            ", RegexOptions.IgnorePatternWhitespace);
        
        var matches = pattern.Matches(line);
        var values = new List<string>();
        foreach (Match match in matches)
        {
            if (match.Groups[1].Success)
            {
                values.Add(match.Groups[1].Value.Replace("\\'", "'"));
            }
            else if (match.Groups[2].Success)
            {
                values.Add(match.Groups[2].Value.Replace("\\\"", "\""));
            }
            else
            {
                values.Add(match.Groups[3].Value);
            }
        }
        return values.Select(v => v.Trim().Replace("\\n", "\n").Replace("\\r", "\r")).ToArray();
    }
}