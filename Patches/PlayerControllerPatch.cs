using GameNetcodeStuff;
using HarmonyLib;

namespace ConfigurableSprint.Patches;

[HarmonyPatch(typeof(PlayerControllerB))]
public class PlayerControllerPatch {
    [HarmonyPatch(nameof(PlayerControllerB.Start))]
    [HarmonyPostfix]
    private static void Start(PlayerControllerB __instance) {
        if (Plugin.BoundConfig.sprintTime.Value >= 0)
            __instance.sprintTime = Plugin.BoundConfig.sprintTime.Value;
    }

    [HarmonyPatch(nameof(PlayerControllerB.Update))]
    [HarmonyPostfix]
    private static void Update(PlayerControllerB __instance) {
        if (Plugin.BoundConfig.sprintTime.Value < 0)
            __instance.sprintMeter = 1;
    }
}
