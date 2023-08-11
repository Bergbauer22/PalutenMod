using MelonLoader;
using BTD_Mod_Helper;
using PalutenMod;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using PalutenMod.Displays.Projectiles;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Simulation.Towers;
using HarmonyLib;

[assembly: MelonInfo(typeof(PalutenModMOD), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace PalutenMod
{

    public class PalutenModMOD : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            ModHelper.Msg<PalutenModMOD>("PalutenMod loaded!");
        }
    }
}