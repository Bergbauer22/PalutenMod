using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using PalutenMod.Displays.Projectiles;
using PalutenMod.Upgrades.MiddlePath;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;

namespace PalutenMod.Upgrades.BottomPath
{
    public class Zombey_1 : ModTower
    {
        public override string Get2DTexture(int[] tiers)
        {
            return "Zombey";
        }
        public override bool Use2DModel => true;
        protected override int Order => 0;
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => "TackShooter-003";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "Zombey";
        public override string Portrait => "Zombey";
        public override string Icon => "Zombey";
        public override bool DontAddToShop => true;
        public override string Description => "Zylinder Fanboy Nr.2";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("DartMonkey-010").portrait;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 750;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate());
            attackModel.weapons[0].projectile.hasDamageModifiers = true;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 40f;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 250.0f;
            attackModel.weapons[0].rate *= 0.55f;
            towerModel.range *= 0.55f;
            attackModel.weapons[0].projectile.pierce += 3;
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 2, false, false));
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 3, false, false));
            attackModel.weapons[0].projectile.ApplyDisplay<Zombey_Shot_DP>();
            var Buff2 = new PierceSupportModel("PierceSupport", true, 3f,"Pierce:Support",null,false,"PierceBuff", "Zombey_Buff");
            Buff2.ApplyBuffIcon<Zombey_Buff_DP>();
            towerModel.AddBehavior(Buff2);
            towerModel.range = 27;
            towerModel.RemoveBehavior<CreateSoundOnTowerPlaceModel>();
            towerModel.RemoveBehavior<CreateSoundOnUpgradeModel>();
            towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));
            towerModel.radius = 10;
        }

    }
    public class Maudado_1 : ModTower
    {
        
        public override string Get2DTexture(int[] tiers)
        {
            return "maudadoS";
        }

        public override bool Use2DModel => true;

        protected override int Order => 0;
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => "DartMonkey-032";
        public override int Cost => 0;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;

        public override string Name => "maudado";
        public override string Portrait => "Zombey";
        public override string Icon => "Zombey";
        public override bool DontAddToShop => true;
        public override string Description => "Just be more nice and polite..";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.isSubTower = true;
            towerModel.icon = towerModel.portrait = Game.instance.model.GetTowerFromId("DartMonkey-010").portrait;
            towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Marine").GetBehavior<TowerExpireModel>().Duplicate());
            towerModel.GetBehavior<TowerExpireModel>().lifespan = 750;
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("dmgMod", "Moabs", 2f, 40f, false, false));
            attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate());
            attackModel.weapons[0].projectile.hasDamageModifiers = true;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 18;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Speed = 20f;
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 250.0f;
            attackModel.weapons[0].rate *= 8f;
            towerModel.range *= 1.6f;
            attackModel.weapons[0].projectile.pierce += 30;
            attackModel.weapons[0].projectile.ApplyDisplay<Maudado_Shot_DP>();
            var Buff3 = new RateSupportModel("MaudadoBuff", 0.8f, true, "Rate:Support", false,1,null,"MaudadoBuff", "maudado_Buff",false);
            Buff3.ApplyBuffIcon<MAUDADO_Buff_DP>();
            towerModel.AddBehavior(Buff3);
            towerModel.range = 45;
            towerModel.RemoveBehavior<CreateSoundOnTowerPlaceModel>();
            towerModel.RemoveBehavior<CreateSoundOnUpgradeModel>();
            towerModel.AddBehavior(new CreditPopsToParentTowerModel("DamageForMainTower"));
            towerModel.radius = 10;
        }

    }
    public class Botton_5 : ModUpgrade<PalutenTower>
    {


        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 45000;

        public override string DisplayName => "The hole squad";
        public override string Description => "Paluten summons his two other friends, Zombey (providing pierce buffs to nearby monkeys) and Maudado (granting a 20% attack speed buff to nearby monkeys)";


        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackmodel = tower.GetAttackModel();
            AttackModel[] Avatarspawner2 = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner2[0].weapons[0].rate = 750;
            Avatarspawner2[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner2[0].name = "ZOMBEY";
            Avatarspawner2[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<Maudado_1>(), 0, false, false, false, false, false));
            tower.AddBehavior(Avatarspawner2[0]);

            
            AttackModel[] Avatarspawner3 = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels().First(a => a.name == "AttackModel_Spawner_").Duplicate() };
            Avatarspawner3[0].weapons[0].rate = 750;
            Avatarspawner3[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            Avatarspawner3[0].name = "ZOMBEY";
            Avatarspawner3[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTower", GetTowerModel<Zombey_1>(), 0, false, false, false, false, false));
            tower.AddBehavior(Avatarspawner3[0]);
        }
    }
}