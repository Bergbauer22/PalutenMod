using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using PalutenMod.Displays.Projectiles;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Unity.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;

namespace PalutenMod.Upgrades.TopPath
{
    public class Top_3 : ModUpgrade<PalutenTower>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 7500;

        public override string DisplayName => "Joining Minecraft...";
        public override string Description => "Throws now an big Iron Pickage that can randomly Push Bloons back (+5DM)";



        public override void ApplyUpgrade(TowerModel tower)
        {
            
            //Normal
            foreach (var weaponModel in tower.GetWeapons())
            {
                tower.range += 5;
                tower.GetAttackModel().range += 5;
                tower.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 3;
                foreach (var projectile in tower.GetWeapons())
                {
                    var attackModel = tower.GetAttackModel();
                    
                    projectile.projectile.AddBehavior(new WindModel("WindModel_", 0, 20, 10, false, null, 0, null, 1));
                    projectile.projectile.pierce += 40;
                    projectile.GetDescendants<Il2CppAssets.Scripts.Models.Towers.Filters.FilterInvisibleModel>().ForEach(model => model.isActive = false);
                    projectile.projectile.hasDamageModifiers = true;
                    var jumptobloons = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 5, 0, 2).GetWeapon().projectile.Duplicate();
                    jumptobloons.pierce += 70;
                    projectile.projectile.AddBehavior(jumptobloons);
                    foreach (var damageModifierForTagModel in projectile.GetBehaviors<DamageModifierForTagModel>())
                    {
                        damageModifierForTagModel.damageAddative += 13;
                    }

                    projectile.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                        1, 5, false, false));
                    
                    projectile.projectile.ApplyDisplay<IronP_Display>();
                }
               

            }
        }
    }
}