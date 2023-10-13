using Il2CppAssets.Scripts.Simulation.SMath;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;

namespace PalutenMod.Displays.Projectiles
{
    public class BasisPumpin_PT_Display : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "BasicPumkin"); }          
    }
    public class KlumpiDP : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "Klumpi"); }
    }
    public class GLP_Buff_DP : ModBuffIcon
    {
        public override string Icon => "GLP_Buff";
        public override int MaxStackSize => 0;
    }
    public class MAUDADO_Buff_DP : ModBuffIcon
    {
        public override string Icon => "maudado_Buff";
        public override int MaxStackSize => 0;
    }
    //PowerMachine
    public class PM_Tower : ModTowerDisplay<PalutenTower>
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override bool UseForTower(int[] paratier) => IsParagon(paratier);

        public override void ModifyDisplayNode(UnityDisplayNode node)

        { Set2DTexture(node, "TowerAMPM"); }
    }
    public class Zombey_Buff_DP : ModBuffIcon
    {
        public override string Icon => "Zombey_Buff";
        public override int MaxStackSize => 0;
    }
    public class Bador_Buff_DP : ModBuffIcon
    {
        public override string Icon => "bador";
        public override int MaxStackSize => 0;
    }
    public class Zombey_Shot_DP : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "ZombeyShot"); }
    }
    public class Maudado_Shot_DP : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "MaudadoSchuss"); }
    }
    
    public class Invisible_Display : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "Leer"); }
    }
    public class BigPumpin_PT_Display : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "BasicPumkinBig"); }
    }
    public class GluePumpin_PT_Display : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "GluePumkin"); }
    }
    public class IronP_Display : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "IronP"); }
    }
    public class P_Trap: ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override float Scale => 0.65f;
        public override Vector3 PositionOffset => new(0, 0.1f, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "PumTrap"); }
    }
    public class P_Trap2 : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;
        public override float Scale => 0.67f;
        public override Vector3 PositionOffset => new(0, 0.2f, 0);
        public override void ModifyDisplayNode(UnityDisplayNode node)
        { Set2DTexture(node, "PumTrap_2"); }
    }
    public class Middle_4AbilityDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 2f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Meteor");
        }
    }
    public class Middle_4_2AbilityDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 2f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Meteor2");
        }
    }
    public class Middle_4_3AbilityDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 2.5f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Meteor3");
        }
    }
    public class Middle_4_4AbilityDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 2.5f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Meteor4");
        }
    }
    public class SterneDisplay : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 1f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "Meteor4");
        }
    }
    public class CamoCl : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale => 2f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "CamoClear");
        }
    }
    public class Feather : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override float Scale =>2f;

        public override Vector3 PositionOffset => new(0, 5f, 0);

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "feather");
        }
    }
}