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
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api;

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
        public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
        {
            if (tower.model.name.Contains("Paluten") && tower.towerModel.isSubTower == false)
            {
                
                SoundTowerPlace();
            }
            
        }
        public override void OnTowerUpgraded(Tower tower, string upgradeName, TowerModel newBaseTowerModel)
        {
            ModHelper.Msg<PalutenModMOD>(upgradeName);
            if (upgradeName == "PalutenMod-PalutenTower Paragon")
            {
                PalutenParaUpgrade();
            }
        }
        

        public static void SoundTowerPlace()
        {
            ModContent.GetAudioClip<PalutenModMOD>("PlacePale").Play();

        }
        public static void PalutenParaUpgrade()
        {
            ModContent.GetAudioClip<PalutenModMOD>("AmpmVideo").Play();
        }

    }
}