using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using PalutenMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;

using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using PalutenMod.Upgrades.BottomPath;

namespace PalutenMod.Upgrades.MiddlePath
{
    public class Middle_2 : ModUpgrade<PalutenTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 3000;

        public override string Description => "His explosions can now damage Black Bloons, his pumpkins explode multiple times, and he gains a 10% attack speed increaseeed";
        public override string DisplayName => "Better Bombs";
        

        public override void ApplyUpgrade(TowerModel tower)
        {
            
            foreach (var weaponModel in tower.GetWeapons())
            {
                
                //weaponModel.projectile.ApplyDisplay<BigPumpin_PT_Display>();
                var attackModel = tower.GetAttackModel();
                var projectile22 = attackModel.weapons[0].projectile;
                projectile22.GetDamageModel().damage += 1;
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                tower.GetWeapon().emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-302").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 1.0f;
                attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 5.0f;
                weaponModel.projectile.pierce += 4;
                projectile22.GetBehavior<TravelStraitModel>().Lifespan = 0.75f;
                
                projectile22.ApplyDisplay<BigPumpin_PT_Display>();
                weaponModel.Rate *= 0.95f;
            }
        }
    }
}