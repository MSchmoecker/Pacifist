using HarmonyLib;
using Pacifist.Logic;

namespace VNEI.Patches {
    [HarmonyPatch]
    public static class DungeonDBPatch {
        [HarmonyPatch(typeof(DungeonDB), nameof(DungeonDB.Start)), HarmonyPostfix]
        public static void Start() {
            EffectHandler.ReloadEffects();
        }
    }
}
