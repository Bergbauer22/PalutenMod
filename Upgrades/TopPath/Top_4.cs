using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Utils;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using PalutenMod.Upgrades.BottomPath;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Models.Powers;

namespace PalutenMod.Upgrades.TopPath
{
    public class Top_4 : ModUpgrade<PalutenTower>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 12000;
        public override int Priority => -1;
        public override string DisplayName => "Joining Minecraft";
        public override string Description => "He summons a flying Minecraft Paluten, and if you upgrade xx3 with UCP, Edga and Paluten are combined into one";

        public class SmallPickDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override Vector3 PositionOffset => new(0, 15f, 0);
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "Mini_Paluten"); }
        }
        public class SmallEdgarPalutenDisplay : ModDisplay
        {
            
            public override string BaseDisplay => Generic2dDisplay;
            public override Vector3 PositionOffset => new(0, 15f, 0);
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "EdgarPaluten"); }
        }
        public class BlueLDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "LaserBlue"); }
        }
        public class Leer : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "Leer"); }
        }
        public class SmallAttackDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "diamond"); }
        }
        public override void ApplyUpgrade(TowerModel tower)
        {   //Tower General

            tower.GetWeapon().projectile.GetDamageModel().damage += 1;
            if (!tower.appliedUpgrades.Contains(UpgradeID<Botton_3>()))
            {
                //AddBehavior
                tower.AddBehavior(Game.instance.model.GetTower(TowerType.Etienne).GetBehavior<DroneSupportModel>().Duplicate());
                //Definitions
                var fire2 = Game.instance.model.GetTower(TowerType.NinjaMonkey, 3, 0, 2).GetWeapon().projectile.Duplicate();
                var airModel2 = tower.GetBehavior<DroneSupportModel>();
                int[] collPass = { -1, 0 };
                //Fire
                fire2.ApplyDisplay<SmallAttackDisplay>();;
                fire2.pierce += 5;
                fire2.GetDamageModel().damage = 1;
                //AirModel
                airModel2.droneModel.GetBehavior<AirUnitModel>().display = ModContent.CreatePrefabReference<SmallPickDisplay>();
                airModel2.droneModel.GetAttackModel().weapons[0].Rate = 0.075f;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<Leer>();
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 0, 2, 0.03f, true, null, 0, null, 1));
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.pierce += 3;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 2;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire2);
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.collisionPasses = new Il2CppStructArray<int>(collPass);
                //OtherUpgrades
                if (tower.appliedUpgrades.Contains(UpgradeID<Botton_1>()))
                {
                    tower.GetAttackModel().range += 20;
                    airModel2.droneModel.GetAttackModel().GetBehavior<PursuitSettingCustomModel>().mustBeInRangeOfParent = false;
                    airModel2.droneModel.GetDescendants<FilterInvisibleModel>().ForEach((model) => model.isActive = false);
                }
                if (!tower.appliedUpgrades.Contains(UpgradeID<Botton_1>()))
                {
                    airModel2.droneModel.GetAttackModel().GetBehavior<PursuitSettingCustomModel>().mustBeInRangeOfParent = true;
                }

            }
            if (tower.appliedUpgrades.Contains(UpgradeID<Botton_3>()))
            {
                //AddBehavior
                tower.AddBehavior(Game.instance.model.GetTower(TowerType.Etienne).GetBehavior<DroneSupportModel>().Duplicate());
                //Definitionen
                var fire2 = Game.instance.model.GetTower(TowerType.NinjaMonkey, 3, 0, 2).GetWeapon().projectile.Duplicate();
                var airModel2 = tower.GetBehavior<DroneSupportModel>();
                int[] collPass = { -1, 0 };
                var fire = Game.instance.model.GetTower(TowerType.DartlingGunner, 3, 2, 0).GetWeapon().projectile.Duplicate();
                //Fire
                fire.pierce += 40;
                fire.GetDamageModel().damage += 22;
                fire2.pierce += 20;
                fire2.ApplyDisplay<Leer>();
                fire.ApplyDisplay<BlueLDisplay>();
                //AitModell
                airModel2.droneModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 0, 15, 15, true, null, 0, null, 1));
                airModel2.droneModel.GetBehavior<AirUnitModel>().display = ModContent.CreatePrefabReference<SmallEdgarPalutenDisplay>();
                airModel2.droneModel.GetAttackModel().weapons[0].Rate = 0.04f;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<SmallAttackDisplay>();
                airModel2.droneModel.GetAttackModel().GetBehavior<PursuitSettingCustomModel>().mustBeInRangeOfParent = true;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.pierce += 5;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 4;       
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire2);              
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.collisionPasses = new Il2CppStructArray<int>(collPass);
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<Leer>();
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(fire);
                airModel2.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                airModel2.droneModel.GetAttackModel().GetBehavior<PursuitSettingCustomModel>().mustBeInRangeOfParent = false;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                //Tower
                tower.GetAttackModel().range += 250;
            }
        }
    }
}