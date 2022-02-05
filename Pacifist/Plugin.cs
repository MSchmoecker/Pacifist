using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using Pacifist.Logic;

namespace Pacifist {
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Plugin : BaseUnityPlugin {
        public const string ModName = "Pacifist";
        public const string ModGuid = "com.maxsch.valheim.pacifist";
        public const string ModVersion = "0.1.1";

        public static Plugin Instance { get; private set; }
        private Harmony harmony;

        private void Awake() {
            Instance = this;

            harmony = new Harmony(ModGuid);
            harmony.PatchAll();
            Config.SettingChanged += OnConfigOnSettingChanged;
        }

        private static void OnConfigOnSettingChanged(object sender, SettingChangedEventArgs args) {
            if (!EffectHandler.IsReloading) {
                EffectHandler.ReloadEffects();
            }
        }
    }
}
