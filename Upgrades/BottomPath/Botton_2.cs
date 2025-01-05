using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Utils;
using PalutenMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using PalutenMod.Upgrades.MiddlePath;

namespace PalutenMod.Upgrades.BottomPath
{
    public class Botton_2 : ModUpgrade<PalutenTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 3750;

        public override string DisplayName => "Sticky Pumkin";
        public override string Description => "He can attack now using sticky pumpkins";

        

        /// <summary>
        /// Default priority is 0, so this lower priority makes this Upgrade always apply last so that it will catch
        /// every single FilterInvisibleModel that might've been added.
        /// </summary>
        public override int Priority => -1;

        public override void ApplyUpgrade(TowerModel tower)
        {
            var attackModel = tower.GetAttackModel();
            var projectile = attackModel.weapons[0].projectile;
            var fire = Game.instance.model.GetTower(TowerType.GlueGunner,3,2,0).GetWeapon().projectile.Duplicate();
            fire.ApplyDisplay<GluePumpin_PT_Display>();
            fire.pierce = 50;
            fire.radius = 50;
            fire.GetDescendants<Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel>().ForEach(model => model.isActive = false);
            projectile.GetBehavior<TravelStraitModel>().Lifespan = 10.01f;
            if (!tower.appliedUpgrades.Contains(UpgradeID<Botton_5>()) && !tower.appliedUpgrades.Contains(UpgradeID<Middle_5>()))
            {
                projectile.AddBehavior(fire);
            }
                
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 15, null, false, false);
        }
    }
}