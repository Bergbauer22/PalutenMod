using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using System.Linq;

using static PalutenMod.PalutenModMOD;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using PalutenMod.Displays.Projectiles;

namespace PalutenMod.Upgrades.BottomPath
{
    public class GLP_1 : ModTower
    {
        public override string Get2DTexture(int[] tiers)
        {
            return "Glp_1";
        }
        public override bool Use2DModel => true;
        protected override int Order => 0;
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => "DartMonkey-032";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "GLP";
        public override string Portrait => "Glp_1";
        public override string Icon => "Glp_1";
        public override bool DontAddToShop => true;
        public override string Description => "GLP";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("DartMonkey-010").portrait;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 750;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("dmgMod", "Moabs", 2f, 5f, false, false));
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate());
            attackModel.weapons[0].projectile.hasDamageModifiers = true;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 3;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 50f;
            attackModel.weapons[0].rate *= 0.7f;
            towerModel.range *= 1.6f;
            attackModel.weapons[0].projectile.pierce += 20;
            attackModel.weapons[0].projectile.ApplyDisplay<KlumpiDP>();
            towerModel.AddBehavior(new HeroXpScaleSupportModel("HeroXpScaleSupportModel", true, 10, null, null, null));
            var HealthIncrease = Game.instance.model.GetTowerFromId("Benjamin 6").GetDescendant<LifeRegenModel>().Duplicate();
            var Buff = new RangeSupportModel("RangeSupport", true, 0.75f, 0, "Range:Support", null, false, null, null);
            Buff.ApplyBuffIcon<GLP_Buff_DP>();
            towerModel.AddBehavior(Buff);
            towerModel.range = 40;
            towerModel.RemoveBehavior<CreateSoundOnTowerPlaceModel>();
            towerModel.RemoveBehavior<CreateSoundOnUpgradeModel>();
            HealthIncrease.regenAmount = 5;
            HealthIncrease.overRegenAmount = 99999;
            attackModel.AddBehavior(HealthIncrease);
            towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));
        }

    }
    public class Botton_4 : ModUpgrade<PalutenTower>
    {
        protected override int Order => 1;
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 15500;
        public override string Name => "Getting Help";
        public override string Description => "Paluten summons his best friend GermanLetsPlay(He gives you each Round 500$ | 5 Lives and also Range-Buffs Nearby Monkeys";



        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var attackmodel = tower.GetAttackModel();
            AttackModel[] Avatarspawner = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner[0].weapons[0].rate = 750;
            Avatarspawner[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner[0].name = "GLP";
            Avatarspawner[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<GLP_1>(),0, false, false, false, false, false));
            tower.AddBehavior(Avatarspawner[0]);
            var Money = Game.instance.model.GetTowerFromId("Benjamin").GetDescendant<PerRoundCashBonusTowerModel>().Duplicate();
            Money.distributeCash = false;
            Money.cashPerRound = 500;
            attackModel.AddBehavior(Money);

        }
    }

    
}