using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using PalutenMod.Displays.Projectiles;
using Il2Cpp;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using PalutenMod.Upgrades.BottomPath;

namespace PalutenMod.Upgrades.MiddlePath
{
    public class Middle_4 : ModUpgrade<PalutenTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 14000;

        public override string DisplayName => "Following Meteor!";
        
        public override string Description =>
            "Abilitys: Choose one from 3 strong meteors! Moab-Glue-Termineteor[90s] | Ice-Meteor[30s] | Anti-Bloon-Meteor[60s]";


        
        public override void ApplyUpgrade(TowerModel tower)
        {
            
            //Generell
            var attackModelPV = tower.GetAttackModel();
            var projectilePV = attackModelPV.weapons[0].projectile;
            tower.GetWeapon().Rate *= 0.6f;
            projectilePV.GetDamageModel().damage += 3;
            projectilePV.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 9, false, false));
            projectilePV.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 10, false, false));
            projectilePV.pierce += 20;
            //Abilitys

            //1
            var abilityModel = new AbilityModel("AbilityModel_Middle_4", "Following Meteor Small",
                "s", 1, 0,
                GetSpriteReference("Middle_4-Icon"), 60f, null, false, false, null,
                0, 0, 9999999, false, false);
            tower.AddBehavior(abilityModel);

            //2
            var abilityModel2 = new AbilityModel("AbilityModel_Middle_4_2", "Following Meteor Small2",
                "s", 1, 0,
                GetSpriteReference("Ability2"), 90f, null, false, false, null,
                0, 0, 9999999, false, false);
            tower.AddBehavior(abilityModel2);

            //3
            var abilityModel3 = new AbilityModel("AbilityModel_Middle_4_3", "Following Meteor Small3",
                "s", 1, 0,
                GetSpriteReference("Ability3"), 30f, null, false, false, null,
                0, 0, 9999999, false, false);
            tower.AddBehavior(abilityModel3);



            //1
            var activateAttackModel = new ActivateAttackModel("ActivateAttackModel_Following Meteor Small", 0, true,
                new Il2CppReferenceArray<AttackModel>(1), true, false, false, false, false);
            abilityModel.AddBehavior(activateAttackModel);
            //2
            var activateAttackModel2 = new ActivateAttackModel("ActivateAttackModel_Following Meteor Small2", 0, true,
                            new Il2CppReferenceArray<AttackModel>(1), true, false, false, false, false);
            abilityModel2.AddBehavior(activateAttackModel2);
            //3
            var activateAttackModel3 = new ActivateAttackModel("ActivateAttackModel_Following Meteor Small3", 0, true,
                            new Il2CppReferenceArray<AttackModel>(1), true, false, false, false, false);
            abilityModel3.AddBehavior(activateAttackModel3);



            //1
            var attackModel1 = activateAttackModel.attacks[0] =
                Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetAttackModel().Duplicate();
            activateAttackModel.AddChildDependant(attackModel1);
            //2
            var attackModel2 = activateAttackModel2.attacks[0] =
                Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetAttackModel().Duplicate();
            activateAttackModel2.AddChildDependant(attackModel2);
            //3
            var attackModel3 = activateAttackModel3.attacks[0] =
                Game.instance.model.GetTower(TowerType.BoomerangMonkey, 4).GetAttackModel().Duplicate();
            activateAttackModel3.AddChildDependant(attackModel3);



            //1
            attackModel1.behaviors = attackModel1.behaviors
                .RemoveItemOfType<Model, RotateToTargetModel>()
                .RemoveItemOfType<Model, TargetStrongModel>()
                .RemoveItemOfType<Model, TargetLastModel>()
                .RemoveItemOfType<Model, TargetCloseModel>();
            var targetFirstModel = attackModel1.GetBehavior<TargetFirstModel>();
            targetFirstModel.isSelectable = false;
            attackModel1.targetProvider = targetFirstModel;
            attackModel1.range = 2000;
            attackModel1.attackThroughWalls = true;
            //2
            attackModel2.behaviors = attackModel2.behaviors
                .RemoveItemOfType<Model, RotateToTargetModel>()
                .RemoveItemOfType<Model, TargetFirstModel>()
                .RemoveItemOfType<Model, TargetLastModel>()
                .RemoveItemOfType<Model, TargetCloseModel>();
            var targetFirstModel2 = attackModel2.GetBehavior<TargetStrongModel>();
            targetFirstModel2.isSelectable = false;
            attackModel2.targetProvider = targetFirstModel2;
            attackModel2.range = 2000;
            attackModel2.attackThroughWalls = true;
            //3
            attackModel3.behaviors = attackModel3.behaviors
                .RemoveItemOfType<Model, RotateToTargetModel>()
                .RemoveItemOfType<Model, TargetStrongModel>()
                .RemoveItemOfType<Model, TargetLastModel>()
                .RemoveItemOfType<Model, TargetCloseModel>();
            var targetFirstModel3 = attackModel3.GetBehavior<TargetFirstModel>();
            targetFirstModel3.isSelectable = false;
            attackModel3.targetProvider = targetFirstModel3;
            attackModel3.range = 2000;
            attackModel3.attackThroughWalls = true;



            //1
            var weapon = attackModel1.weapons[0];
            weapon.emission.AddBehavior(
                new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, false));
            var projectileModel = weapon.projectile;
            projectileModel.ApplyDisplay<Middle_4AbilityDisplay>();
            projectileModel.pierce = 2000;
            projectileModel.RemoveBehavior<RotateModel>();
            projectileModel.GetBehavior<RetargetOnContactModel>().distance = 2000;
            projectileModel.GetDamageModel().damage = 120;
            projectileModel.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 9930, false, false));
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 2230, false, false));
            projectileModel.GetBehavior<TravelStraitModel>().Speed = 250f;
            projectileModel.GetBehavior<TravelStraitModel>().Lifespan = 25.0f;
            foreach (var damageModifierForTagModel in projectileModel.GetBehaviors<DamageModifierForTagModel>())
            {
                damageModifierForTagModel.damageAddative = 2750;
            }
            projectileModel.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 2750, false, false));
            //2
            var weapon2 = attackModel2.weapons[0];
            var fire = Game.instance.model.GetTower(TowerType.GlueGunner, 0, 2, 5).GetWeapon().projectile.Duplicate();
            fire.pierce = 99999;
            fire.radius = 5;
            fire.GetBehavior<TravelStraitModel>().Speed = 350f;
            fire.GetBehavior<TravelStraitModel>().Lifespan = 105.0f;
            weapon2.emission.AddBehavior(
                new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, false));
            var projectileModel2 = weapon2.projectile;
            projectileModel2.AddBehavior(fire);
            projectileModel2.ApplyDisplay<Middle_4_2AbilityDisplay>();
            projectileModel2.pierce = 1266;
            projectileModel2.AddBehavior(new InstantDamageEmissionModel("InstendDamage", null));
            projectileModel2.RemoveBehavior<RotateModel>();
            projectileModel2.GetBehavior<RetargetOnContactModel>().distance = 2000;
            projectileModel2.GetDamageModel().damage = 5;
            projectileModel2.GetBehavior<DamageModel>().overrideDistributeBlocker = true;
            projectileModel2.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectileModel2.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 10, false, false));
            projectileModel2.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 6, false, false));
            projectileModel2.GetBehavior<TravelStraitModel>().Speed = 150f;
            projectileModel2.GetBehavior<TravelStraitModel>().Lifespan = 35.0f;
            foreach (var damageModifierForTagModel in projectileModel2.GetBehaviors<DamageModifierForTagModel>())
            {
                damageModifierForTagModel.damageAddative = 7750;
            }
            projectileModel2.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 6750, false, false));
            //3
            var weapon3 = attackModel3.weapons[0];
            var fire2 = Game.instance.model.GetTower(TowerType.IceMonkey, 0, 2, 5).GetWeapon().projectile.Duplicate();
            fire2.pierce = 99999;
            fire2.radius = 12;
            fire2.GetBehavior<TravelStraitModel>().Speed = 350f;
            fire2.GetBehavior<TravelStraitModel>().Lifespan = 105.0f;
            weapon3.emission.AddBehavior(
                new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, false));
            var projectileModel3 = weapon3.projectile;
            projectileModel3.AddBehavior(fire2);
            projectileModel3.ApplyDisplay<Middle_4_3AbilityDisplay>();
            projectileModel3.pierce = 25266;
            projectileModel3.RemoveBehavior<RotateModel>();
            projectileModel3.GetBehavior<RetargetOnContactModel>().distance = 2000;
            projectileModel3.GetDamageModel().damage = 5;
            projectileModel3.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            projectileModel3.AddBehavior(new WindModel("WindModel_", 300, 400, 100, true, null, 0, null, 1));
            projectileModel3.GetBehavior<WindModel>().affectMoab = true;
            projectileModel3.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 10, false, false));
            projectileModel3.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 26, false, false));
            projectileModel3.GetBehavior<TravelStraitModel>().Speed = 350f;
            projectileModel3.GetBehavior<TravelStraitModel>().Lifespan = 105.0f;
            foreach (var damageModifierForTagModel in projectileModel3.GetBehaviors<DamageModifierForTagModel>())
            {
                damageModifierForTagModel.damageAddative = 50;
            }
            projectileModel3.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 750, false, false));
            if (tower.GetBehavior<DroneSupportModel>() != null && tower.appliedUpgrades.Contains(UpgradeID<Botton_1>()))
            {
                var dsm = (tower.GetBehavior<DroneSupportModel>());
                dsm.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            }
        } 
    }
}