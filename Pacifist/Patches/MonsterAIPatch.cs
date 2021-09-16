using HarmonyLib;
using Pacifist.Logic;

namespace VNEI.Patches {
    [HarmonyPatch]
    public class MonsterAIPatch {
        [HarmonyPatch(typeof(MonsterAI), nameof(MonsterAI.UpdateTarget)), HarmonyPostfix]
        public static void Start(MonsterAI __instance) {
            string name = __instance.name.Trim().Replace("(Clone)", "");

            if (!EffectHandler.AttackDisabled.ContainsKey(name) || !EffectHandler.AttackDisabled[name]) {
                return;
            }

            __instance.m_targetCreature = null;
            __instance.m_targetStatic = null;
            __instance.m_timeSinceAttacking = 0.0f;
            __instance.m_updateTargetTimer = 5f;
        }
    }
}
