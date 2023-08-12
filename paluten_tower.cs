using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using PalutenMod.Displays.Projectiles;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using PalutenMod.Upgrades.BottomPath;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace PalutenMod
{
    public class PalutenTower : ModTower
    {

        protected override int Order => 2;
        public override string Get2DTexture(int[] tiers)
        {
            
            if (tiers[2] == 5)
            {
                return "B5";
            }
            else if (tiers[1] == 5)
            {
                return "M5";
            }
            else if (tiers[0] == 5)
            {
                return "T5";
            }
            else if (tiers[2] == 4)
            {
                return "B4";
            }
            else if (tiers[1] == 4)
            {
                return "M4";
            }
            else if (tiers[0] == 4)
            {
                return "T4";
            }
            else if (tiers[2] == 3)
            {
                return "B3";
            }
            else if (tiers[1] == 3)
            {
                return "M3";
            }
            else if (tiers[0] == 3)
            {
                return "T3";
            }
            else if (tiers[2] == 2)
            {
                return "B2";
            }
            else if (tiers[1] == 2)
            {
                return "M2";
            }
            else if (tiers[0] == 2)
            {
                return "T2";
            }
            else if (tiers[2] == 1)
            {
                return "B1";
            }
            else if (tiers[1] == 1)
            {
                return "M1";
            }
            else if (tiers[0] == 1)
            {
                return "T1";
            }




            else
            {
                return "UnskilledAussehen";
            }
            
        }
        
        public override bool Use2DModel => true;
        public override string Portrait => "PalutenMod-Portrait";
        public override string Icon => "PalutenMod-Portrait";

        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 1500;

        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Mit Kürbis/Freunden/Mini Paluten an die Macht";
        public override ParagonMode ParagonMode => ParagonMode.Base000;


        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.range += 16;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 16;
            
            var projectile = attackModel.weapons[0].projectile;
            //projectile.name = "BasicPumkin";
            projectile.ApplyDisplay<BasisPumpin_PT_Display>(); 
            projectile.pierce += 22;
            
            //projectile.hasDamageModifiers = true;
            var bomb = Game.instance.model.GetTower(TowerType.BombShooter,0,3,1).GetWeapon().projectile.Duplicate();
            
            bomb.ApplyDisplay<BasisPumpin_PT_Display>();
            bomb.radius += 4;
            bomb.pierce += 1;
            bomb.maxPierce = 999999;
            
            towerModel.GetWeapon().Rate += 0.6f;
            projectile.AddBehavior(bomb);

        }
        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.BoomerangMonkey).towerIndex + 1;
        }      
        public override bool IsValidCrosspath(int[] tiers) =>
            ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
    }
}