using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace LethalShotgun
{
    [HarmonyPatch]
    [BepInPlugin("com.github.weldar.lethalshotgun", "LethalShotgun", "1.0.0")]
    [BepInProcess("Lethal Company.exe")]
    public class LethalShotgun : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin com.github.weldar.lethalshotgun is loaded!");
            var harmony = new Harmony("com.github.weldar.lethalshotgun");
            harmony.PatchAll();
        }


        [HarmonyPatch(typeof(Item), "ScriptableObject")]
        [HarmonyPostfix]

        public static void Postfix(Item __instance)
        {
            if (__instance.itemName == "Shotgun")
            {
                __instance.isScrap = false;
            }
        }
    }
}