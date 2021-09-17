using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Jotunn.Utils;
using Jotunn.Managers;
using Pacifist.Logic;

namespace Pacifist {
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    public class Plugin : BaseUnityPlugin {
        public const string ModName = "Pacifist";
        public const string ModGuid = "com.maxsch.valheim.pacifist";
        public const string ModVersion = "0.1.0";

        public static Plugin Instance { get; private set; }
        private Harmony harmony;

        private void Awake() {
            Instance = this;

            harmony = new Harmony(ModGuid);
            harmony.PatchAll();
            Config.SettingChanged += OnConfigOnSettingChanged;

            // load embedded localisation
            string englishJson = AssetUtils.LoadTextFromResources("Localization.English.json", Assembly.GetExecutingAssembly());
            LocalizationManager.Instance.AddJson("English", englishJson);
        }

        private static void OnConfigOnSettingChanged(object sender, SettingChangedEventArgs args) {
            if (!EffectHandler.IsReloading) {
                EffectHandler.ReloadEffects();
            }
        }

        private void OnDestroy() {
            harmony?.UnpatchAll(ModGuid);
            Config.SettingChanged -= OnConfigOnSettingChanged;
        }
    }
}
