using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace PalutenMod.Upgrades.TopPath
{
    public class Top_1 : ModUpgrade<PalutenTower>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";

        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 900;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "Throws a bit faster (20%)";
        public override string DisplayName => "Faster Shooting";
        public override void ApplyUpgrade(TowerModel tower)
        {
            tower.GetWeapon().Rate *= 0.8f; 
        }
    }
}