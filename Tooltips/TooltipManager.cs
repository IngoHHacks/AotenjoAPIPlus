using AotenjoAPIPlus.Classes;
using TMPro;

namespace AotenjoAPIPlus.Tooltips;

public class TooltipManager
{
    public static Dictionary<string, StringHolderGroup> LinkTooltips = new();
    
    // This one is necessary because Lambdas can't be implicitly converted to StringHolder,
    // even though they can implicitly convert to Func<string> and Func<string> can implicitly convert to StringHolder.
    public static void RegisterStyleTooltip(string linkId, Func<string> headerFunc, Func<string> contentFunc, Color? color = null, string extraOpeningDefinition = "", string extraClosingDefinition = "")
    {
        RegisterStyleTooltip(linkId, (StringHolder) headerFunc, (StringHolder) contentFunc, color, extraOpeningDefinition, extraClosingDefinition);
    }
    
    public static void RegisterStyleTooltip(string linkId, StringHolder header, StringHolder content, Color? color = null, string extraOpeningDefinition = "", string extraClosingDefinition = "")
    {
        LinkTooltips[linkId] = (header, content);
        var colorHex = "FFFF00";
        if (color.HasValue)
        {
            colorHex = ColorUtility.ToHtmlStringRGB(color.Value);
        }
        var style = new TMP_Style(linkId, $"<color=#{colorHex}><link=\"{linkId}\">{extraOpeningDefinition}", $"{extraClosingDefinition}</link></color>");
        TMP_Settings.defaultStyleSheet.styles.Add(style);
        TMP_Settings.defaultStyleSheet.RefreshStyles();
    }
}