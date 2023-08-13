using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using PalutenMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using UnityEngine.InputSystem.Utilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using PalutenMod.Upgrades.BottomPath;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2Cpp;
using BTD_Mod_Helper.Api;

namespace PalutenMod.Upgrades
{
    public class Bador : ModTower
    {
        public override string Get2DTexture(int[] tiers)
        {
            return "bador";
        }
        public override bool Use2DModel => true;
        protected override int Order => 1;
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => "TackShooter-205";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "Bador";
        public override string Portrait => "bador";
        public override string Icon => "bador";
        public override bool DontAddToShop => true;
        public override string Description => "bador";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("DartMonkey-010").portrait;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 3000;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate());
            attackModel.weapons[0].projectile.hasDamageModifiers = true;
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ddt", "Ddt",
                1, 499999999, false, false));
            attackModel.range *= 2;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 200;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 10f;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 250.0f;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            attackModel.weapons[0].rate *= 1.2f;
            towerModel.range *= 1.55f;
            attackModel.weapons[0].projectile.pierce += 12;
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 2, false, false));
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 3, false, false));
            attackModel.weapons[0].projectile.ApplyDisplay<SterneDisplay>();
            var Buff2 = new RateSupportModel("BadorBuff", 0.5f, true, "Rate:Support", false, 1, null, "BadorBuff", "bador", false);
            Buff2.ApplyBuffIcon<Bador_Buff_DP>();
            towerModel.AddBehavior(Buff2);
            towerModel.range = attackModel.range;
            attackModel.range *= 1.5f;
            towerModel.RemoveBehavior<CreateSoundOnTowerPlaceModel>();
            towerModel.RemoveBehavior<CreateSoundOnUpgradeModel>();
            AttackModel[] Avatarspawner2 = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner2[0].weapons[0].rate = 222375;
            Avatarspawner2[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner2[0].name = "ZOMBEY";
            Avatarspawner2[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<Maudado_1>(), 0, false, false, false, false, false));
            towerModel.AddBehavior(Avatarspawner2[0]);
            AttackModel[] Avatarspawner3 = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner3[0].weapons[0].rate = 32275;
            Avatarspawner3[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner3[0].name = "Maudado";
            Avatarspawner3[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<Zombey_1>(), 0, false, false, false, false, false));
            towerModel.AddBehavior(Avatarspawner3[0]);
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ddt", "Ddt",
                1, 499999999, false, false));
            towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new WindModel("WindModel_", 0, 200, 100, true, null, 0, null, 1));
            towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));
        }

    }
    public class Paragon : ModParagonUpgrade<PalutenTower>
    {
        public override int Cost => 850000;
        public override string Description => "Paluten tranform into the ALMIGHTY POWER MACHINE";
        public override string DisplayName => "ALMIGHTY POWER MACHINE";
        
        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].weapons[0].rate = 750;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].name = "GLP";
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<GLP_1>(), 0, false, false, false, false, false));
            tower.AddBehavior(Avatarspawner[0]);
            var Money = Game.instance.model.GetTowerFromId("Benjamin").GetDescendant<PerRoundCashBonusTowerModel>().Duplicate();
            Money.distributeCash = false;
            Money.cashPerRound = 5000;
            tower.ApplyDisplay<PM_Tower>();
            AttackModel[] Avatarspawner1 = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner1[0].weapons[0].rate = 1500;
            Avatarspawner1[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner1[0].name = "Bador";
            Avatarspawner1[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<Bador>(), 0, false, false, false, false, false));
            tower.AddBehavior(Avatarspawner1[0]);
            tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
            tower.GetAttackModel().range += 4;
            tower.range += 4;
            var camosupport = Game.instance.model.GetTower(TowerType.EtienneUAV).GetDescendant<VisibilitySupportModel>().Duplicate();
            camosupport.isGlobal = true;
            camosupport.appliesToOwningTower = true;
            tower.AddBehavior(camosupport);
            var MIB = Game.instance.model.GetTowerFromId("MonkeyVillage-030").GetBehavior<DamageTypeSupportModel>();
            MIB.appliesToOwningTower = true;
            tower.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ddt", "Ddt",
               1, 499999999, false, false));
            tower.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            tower.AddBehavior(MIB);
            var druid = Game.instance.model.GetTower(TowerType.Druid, 2);
            var lightning = druid.GetAttackModel().weapons.First(w => w.name == "WeaponModel_Lightning").Duplicate();
            lightning.animation = 1;
            lightning.projectile.pierce = 9999999;
            lightning.rate = 0.005f;
            lightning.projectile.GetDamageModel().damage += 20;
            lightning.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 130, false, false));
            lightning.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified", 1, 15, false, false));
            tower.GetAttackModel().AddWeapon(lightning);
            var Portal = Game.instance.model.GetTowerFromId("SuperMonkey-005").GetAbility().Duplicate();
            Portal.cooldown = 250;
            tower.range = attackModel.range;
            tower.AddBehavior(Portal);
            //Am Start
            attackModel.range *= 2;
            GetAudioClip<PalutenModMOD>("HelloFriends2").Play();
            
        }
    }
    
}