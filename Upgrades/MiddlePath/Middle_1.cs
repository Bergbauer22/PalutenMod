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
using Il2CppAssets.Scripts.Models;
using System;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using PalutenMod.Upgrades.BottomPath;
using BTD_Mod_Helper;

namespace PalutenMod.Upgrades.MiddlePath
{
    public class Middle_1 : ModUpgrade<PalutenTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 1250;

        public override string DisplayName => "Bigger Bombs";
        public override string Description => "Better explosions now deal more damage";

        

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                    var attackModel = tower.GetAttackModel();
                    var projectile = attackModel.weapons[0].projectile;
                    projectile.GetDamageModel().damage += 1;
                    projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                    1, 50, false, false));
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());               
                    tower.GetWeapon().emission = new InstantDamageEmissionModel("InstantDamageEmissionModel_", null);
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                    attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetAttackModel().weapons[0].projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                    attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage += 1.0f;
                    attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce = 5.0f;
                    weaponModel.projectile.pierce = 1;
                    projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.01f;                 
                
            }
            
        }

       
    }
}