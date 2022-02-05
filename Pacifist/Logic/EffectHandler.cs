using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pacifist.Logic {
    public static class EffectHandler {
        public static bool IsReloading { get; private set; }
        public static readonly Dictionary<string, bool> AttackEnabled = new Dictionary<string, bool>();

        public static void ReloadEffects() {
            IsReloading = true;

            foreach (GameObject prefab in ZNetScene.instance.m_prefabs) {
                if (prefab.TryGetComponent(out Character character)) {
                    foreach (EffectList.EffectData effectData in character.m_hitEffects.m_effectPrefabs) {
                        CheckEffect(prefab.name, effectData);
                    }

                    foreach (EffectList.EffectData effectData in character.m_deathEffects.m_effectPrefabs) {
                        CheckEffect(prefab.name, effectData);
                    }
                }

                if (prefab.TryGetComponent(out MonsterAI monsterAI)) {
                    CheckAttackEnabled(prefab.name, monsterAI);
                }
            }

            IsReloading = false;
        }

        private static void CheckEffect(string prefabName, EffectList.EffectData effectData) {
            bool enabled = Plugin.Instance.Config.Bind(prefabName, effectData.m_prefab.name, false).Value;
            effectData.m_enabled = enabled;
        }

        private static void CheckAttackEnabled(string prefabName, MonsterAI monsterAI) {
            bool enabled = Plugin.Instance.Config.Bind(prefabName, $"{prefabName}_attack_players", true).Value;

            monsterAI.m_enableHuntPlayer = monsterAI.m_enableHuntPlayer && enabled;
            monsterAI.m_attackPlayerObjects = monsterAI.m_attackPlayerObjects && enabled;

            if (AttackEnabled.ContainsKey(prefabName)) {
                AttackEnabled[prefabName] = enabled;
            } else {
                AttackEnabled.Add(prefabName, enabled);
            }
        }
    }
}
