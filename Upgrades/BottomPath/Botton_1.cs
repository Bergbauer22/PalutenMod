using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using PalutenMod.Displays.Projectiles;
using UnityEngine.Playables;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using static PalutenMod.Upgrades.TopPath.Top_4;

namespace PalutenMod.Upgrades.BottomPath
{
    public class Botton_1 : ModUpgrade<PalutenTower>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 2500;

        public override string Description => "Towers within his range can now target any type of Bloon";
        public override string DisplayName => "Helping Content";
        

        public override void ApplyUpgrade(TowerModel tower)
        {
            foreach (var weaponModel in tower.GetWeapons())
            {
                tower.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                tower.GetAttackModel().range += 4;
                tower.range += 4;
                var camosupport = Game.instance.model.GetTower(TowerType.EtienneUAV).GetDescendant<VisibilitySupportModel>().Duplicate();
                camosupport.isGlobal = true;
                camosupport.appliesToOwningTower = true;
                tower.AddBehavior(camosupport);
                var MIB = Game.instance.model.GetTowerFromId("MonkeyVillage-030").GetBehavior<DamageTypeSupportModel>();
                MIB.appliesToOwningTower = true;
                tower.AddBehavior(MIB);
            }
        }
    }
}