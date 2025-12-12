using AotenjoAPIPlus.Localization;

namespace AotenjoAPIPlus
{
    public class Main : HarmonyMod
    {
        public override string ModName => "Aotenjo API+";
        public override string ModAuthor => "IngoH";
        public override string ModVersion => "1.0.0";
        public override string ModGuid => "ingoh.Aotenjo.APIPlus";
        
        public override void Init()
        {
            Logger.Log("Aotenjo API+ initialized.");
            var mods = ModManager.Instance.loadedMods;
            foreach (var mod in mods)
            {
                var path = mod.modDir;
                var locPath = Path.Combine(path, "localization");
                if (!Directory.Exists(locPath)) continue;
                var locs = Directory.GetFiles(locPath, "*.csv", SearchOption.AllDirectories);
                foreach (var loc in locs)
                {
                    try
                    {
                        Logger.Log($"Loading localization file: {loc}");
                        LocalizationManager.LoadLocalizationFromCsvFile(loc);
                    }
                    catch (Exception e)
                    {
                        Logger.LogError($"Failed to load localization file {loc}: {e}");
                    }
                }
            }
        }
    }
}