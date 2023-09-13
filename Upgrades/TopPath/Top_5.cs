using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using PalutenMod.Upgrades.BottomPath;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Simulation.SMath;
using BTD_Mod_Helper.Api;
using static PalutenMod.Upgrades.TopPath.Top_4;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using System.Linq;
using PalutenMod.Upgrades.MiddlePath;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace PalutenMod.Upgrades.TopPath
{
    public class Top_5 : ModUpgrade<PalutenTower>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 140000;
        public override int Priority => -2;

        public override string Description => "He's now able to use Lightnings and recieved an End Portal ability that can Terminate Everythink (BIG Cooldown)";
        public override string DisplayName => "Hacked Minecraft";


        public class PalutenDisplay : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;
            public override Vector3 PositionOffset => new(0, 15f, 0);
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "Mega_Paluten"); }
        }
        public class EdgarPalutenDisplay : ModDisplay
        {

            public override string BaseDisplay => Generic2dDisplay;
            public override Vector3 PositionOffset => new(0, 15f, 0);
            public override void ModifyDisplayNode(UnityDisplayNode node)
            { Set2DTexture(node, "EdgarPalutenOp"); }
        }
        public override void ApplyUpgrade(TowerModel tower)
        {
            var Portal = Game.instance.model.GetTowerFromId("SuperMonkey-005").GetAbility().Duplicate();
            
            tower.AddBehavior(Portal);
            tower.range += 10;
            tower.GetAttackModel().range += 10;
            var airModel2 = tower.GetBehavior<DroneSupportModel>();
            airModel2.droneModel.GetAttackModel().weapons[0].rate *= 0.85f;
            airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<DamageModel>().overrideDistributeBlocker = true;
            airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ddt", "Ddt",
                1, 499999999, false, false));
            var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
            var lightning = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();
            lightning.animation = 1;
            lightning.projectile.pierce = 9999999;
            lightning.rate = 0.005f;
            lightning.projectile.GetDamageModel().damage += 5;
            lightning.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 30, false, false));
            lightning.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified", 1, 5, false, false));
            airModel2.droneModel.GetAttackModel().AddWeapon(lightning);
            airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Bad", "Bad",
                1, 2, false, false));
            if (tower.appliedUpgrades.Contains(UpgradeID<Middle_2>()))
            {
                lightning.rate = 0.004f;
                lightning.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Bad",
                "Bad", 1, 2, false, false));
            }
            if (!tower.appliedUpgrades.Contains(UpgradeID<Botton_3>()))
            {
                var BigKnockback = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 3, 2).GetWeapons()[0].Duplicate();
                BigKnockback.rate = 5.0f;
                BigKnockback.projectile.pierce = 999;
                airModel2.droneModel.GetAttackModel().AddWeapon(BigKnockback);
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<DamageModel>().damage += 5;
                airModel2.droneModel.GetBehavior<AirUnitModel>().display = ModContent.CreatePrefabReference<PalutenDisplay>();
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 3, false, false));
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().chance = 0.25f;
            }
            if (tower.appliedUpgrades.Contains(UpgradeID<Botton_3>()))
            {
                airModel2.droneModel.GetBehavior<AirUnitModel>().display = ModContent.CreatePrefabReference<EdgarPalutenDisplay>();
                airModel2.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Bad",
                "Bad", 1, 22, false, false));
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().chance = 0.75f;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().distanceMax = 9;
            }
            //555
            foreach (var weaponModel in tower.GetWeapons())
            {
                weaponModel.ejectX = 0;
                weaponModel.ejectZ = 300f;

            }
            if (tower.appliedUpgrades.Contains(UpgradeID<Botton_5>()) && tower.appliedUpgrades.Contains(UpgradeID<Middle_5>())){
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().chance = 0.95f;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().distanceMax = 2500;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetBehavior<WindModel>().distanceMin = 1000;
                lightning.projectile.GetDamageModel().damage += 999999999;
                lightning.projectile.pierce = 999999999;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.pierce = 999999999;
                airModel2.droneModel.GetAttackModel().weapons[0].rate *= 0.5f;
                airModel2.droneModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 999999999;
                lightning.emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                airModel2.droneModel.GetAttackModel().weapons[0].emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                Portal.canActivateBetweenRounds = true;
                Portal.cooldown = 30;
                Portal.maxActivationsPerRound = 99999;

                airModel2.droneModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Bad",
                "Bad", 1, 2222222, false, false));
                //tower.GetAttackModel().weapons[0].projectile.RemoveBehavior(Game.instance.model.GetTower(TowerType.GlueGunner, 3, 2, 0).GetWeapon().projectile.Duplicate());
            }
        

        }
    }
}