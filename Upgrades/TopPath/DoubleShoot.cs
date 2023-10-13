using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace PalutenMod.Upgrades.TopPath
{
    public class DoubleShoot : ModUpgrade<PalutenTower>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 2000;

        public override string DisplayName => "Clone-Bomb?";
        public override string Description => "Throws two Pumkins at a time also + (10%) Attack speed";

        //public override string Portrait => "PalutenTower-Portrait";

        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 15, null, false,false);
            tower.GetWeapon().rate *= 0.9f;
        }
    }
}