using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using PalutenMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using PalutenMod.Upgrades.BottomPath;
using PalutenMod.Upgrades.TopPath;

namespace PalutenMod.Upgrades.MiddlePath
{
    public class Middle_3 : ModUpgrade<PalutenTower>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 6500;

        public override string DisplayName => "Evil Paluten Portal?!";

        public override string Description =>
            "Adds a Portal attack to this Tower thats eat every Bloon and convert it into Money.Also he collect thinks in his Area like Drop Boxes / Bananas / Traps (This Attack was created from Palutens Son Evil Paluten).";



        public override void ApplyUpgrade(TowerModel tower)
        {
            
            tower.AddBehavior(new CollectCashZoneModel("CollectCashZoneModel_", 45, 19, 3, "", true, true, true, true));
            foreach (var projectile in tower.GetWeapons().Select(weaponModel => weaponModel.projectile))
            {
                
                projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                    1, 3, false, false));
                projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified",
                    1, 3, false, false));
                projectile.ApplyDisplay<BasisPumpin_PT_Display>();
            }
            var attackModel = tower.GetAttackModel();
            var trap = Game.instance.model.GetTowerFromId("EngineerMonkey-024").behaviors.First(a => a.name.Contains("BloonTrap")).Cast<AttackModel>().Duplicate();
            trap.range = 40;
            tower.range = 40;
            tower.towerSelectionMenuThemeId = "SelectPointInput";
            trap.weapons[0].projectile.pierce = 400;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCapacity = 20000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().rbeCashMultiplier = 3.5f;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.pierce = 1900;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().minimum = 1000;
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.GetBehavior<CashModel>().maximum = 21000;
            trap.weapons[0].projectile.ApplyDisplay<P_Trap>();
            if (tower.appliedUpgrades.Contains(UpgradeID<Botton_1>()))
            {
                trap.weapons[0].projectile.GetDescendants<FilterInvisibleModel>().ForEach((model) => model.isActive = false);
            }
            trap.weapons[0].projectile.GetBehavior<EatBloonModel>().projectile.ApplyDisplay<P_Trap2>();
            trap.weapons[0].Rate = 300;
            if (tower.appliedUpgrades.Contains(UpgradeID<DoubleShoot>()))
            {
                trap.weapons[0].Rate = 200f;
            }
                tower.AddBehavior(trap);
        }
    }
}