using AotenjoAPIPlus.Localization;
using UnityEngine.Localization.Pseudo;
using UnityEngine.Localization.Tables;

namespace AotenjoAPIPlus.Patches;

[HarmonyPatch]
internal class LocalizationPatches
{
    [HarmonyPatch(typeof(StringTableEntry), nameof(StringTableEntry.GetLocalizedString), typeof(IFormatProvider), typeof(IList<object>), typeof(PseudoLocale))]
    [HarmonyPostfix]
    public static void StringTableEntry_GetLocalizedString_Postfix(ref string __result)
    {
        __result = LocalizationManager.PostProcessLocalizedString(__result);
    }
}