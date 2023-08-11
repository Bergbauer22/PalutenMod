using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2Cpp;
using Il2CppSystem.IO;
using PalutenMod.Upgrades.TopPath;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Simulation.SMath;
using static Il2CppNinjaKiwi.LiNK.Endpoints.Payment_SteamGetIAPs;

namespace PalutenMod.Upgrades.BottomPath
{
    public class Botton_3 : ModUpgrade<PalutenTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 9050;

        public override string Description => "Summons a Edga-Paper-Kite that's grant him Global Range!";
        public override string DisplayName => "First Help";

        public class SmallEdgarDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override Vector3 PositionOffset => new(0, 15f, 0);
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "Edgar"); }
        }

        public class SmallADisplay : ModDisplay
        {
            public override PrefabReference BaseDisplayReference => new PrefabReference("01dfdf7fe33be28409a9c2e1db9bbec0");
            public override float Scale => 0.005f;
        }
        public override void ApplyUpgrade(TowerModel tower)
        {
            if (!tower.appliedUpgrades.Contains(UpgradeID<Top_4>()) && !tower.appliedUpgrades.Contains(UpgradeID<Top_5>()))
            {
                //Add Behaviors
                tower.AddBehavior(Game.instance.model.GetTower(TowerType.Etienne).GetBehavior<DroneSupportModel>().Duplicate());
                //Definitions
                var airModel = tower.GetBehavior<DroneSupportModel>();
                int[] collPass = { -1, 0 };
                var fire = Game.instance.model.GetTower(TowerType.DartlingGunner, 3, 2, 0).GetWeapon().projectile.Duplicate();
                //fire
                fire.pierce += 6;
                //AirModel
                airModel.droneModel.GetBehavior<AirUnitModel>().display = ModContent.CreatePrefabReference<SmallEdgarDisplay>();
                airModel.droneModel.GetAttackModel().weapons[0].Rate = 0.15f;
                airModel.droneModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<SmallADisplay>();
                airModel.droneModel.range = tower.range * 2+100;
                airModel.droneModel.GetAttackModel().range = tower.range * 2+100;
                airModel.droneModel.GetAttackModel().GetBehavior<PursuitSettingCustomModel>().mustBeInRangeOfParent = false;
                airModel.droneModel.GetAttackModel().weapons[0].projectile.pierce += 6;
                airModel.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 2;
                airModel.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);             
                airModel.droneModel.GetAttackModel().weapons[0].projectile.collisionPasses = new Il2CppStructArray<int>(collPass);
                airModel.droneModel.GetDescendants<FilterInvisibleModel>().ForEach((model) => model.isActive = false);
                airModel.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            }
            //Tower
            tower.GetAttackModel().range += 250;
        }
    }
}