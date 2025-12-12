using AotenjoAPIPlus.Tooltips;

namespace AotenjoAPIPlus.Patches;

[HarmonyPatch]
internal class TooltipPatches
{
    [HarmonyPatch(typeof(LinkedHandlerForTMPText.LinkHandleEvent), MethodType.Constructor, typeof(string))]
    [HarmonyPrefix]
    public static bool LinkedHandlerForTMPText_ctor_Prefix(LinkedHandlerForTMPText.LinkHandleEvent __instance, string linkId)
    {
        if (TooltipManager.LinkTooltips.TryGetValue(linkId, out var tooltipFunc))
        {
            var (header, content) = tooltipFunc;
            __instance.link = linkId;
            __instance.resHeader = header.GetString();
            __instance.resContent = content.GetString();
            return false;
        }
        return true;
    }
}