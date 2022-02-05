using HarmonyLib;
using Pacifist.Logic;

namespace VNEI.Patches {
    [HarmonyPatch]
    public class MonsterAIPatch {
        [HarmonyPatch(typeof(MonsterAI), nameof(MonsterAI.Awake)), HarmonyPostfix]
        public static void AwakePatch(MonsterAI __instance) {
            __instance.SetHuntPlayer(__instance.m_enableHuntPlayer);
        }

        [HarmonyPatch(typeof(MonsterAI), nameof(MonsterAI.UpdateTarget)), HarmonyPostfix]
        public static void UpdateTargetPatch(MonsterAI __instance) {
            string name = __instance.name.Trim().Replace("(Clone)", "");

            if (!EffectHandler.AttackEnabled.ContainsKey(name) || EffectHandler.AttackEnabled[name]) {
                return;
            }

            __instance.m_targetCreature = null;
            __instance.m_targetStatic = null;
            __instance.m_timeSinceAttacking = 0.0f;
            __instance.m_updateTargetTimer = 5f;
        }
    }
}
