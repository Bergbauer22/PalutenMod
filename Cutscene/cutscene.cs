using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Coop;
using BTD_Mod_Helper.Extensions;
using DeathStarMap;
using HarmonyLib;
using Il2CppAssets.Scripts.Data;
using Il2CppAssets.Scripts.Data.MapSets;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppNinjaKiwi.NKMulti;
using MelonLoader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Reflection;
using Il2CppAssets.Scripts.Models;
using UnityEngine;
using UnityEngine.Video;
using static BTD_Mod_Helper.Api.ModContent;

using Object = UnityEngine.Object;
using Il2CppAssets.Scripts.Unity.Map;
using PalutenMod;

namespace DeathStarMap;

[HarmonyPatch]
public partial class cutscene : BloonsTD6Mod
{
    public new static Assembly Assembly => typeof(PalutenModMOD).Assembly;
    private static AssetBundle? SceneC;
    private static AssetBundle? DarthVader;
    public static GameObject? Vader;
    bool firstime = true;
    bool isHost = false;
    public override void OnTitleScreen()
    {
        SceneC ??= GetBundle<PalutenModMOD>("ampmvideo");
        ModHelper.Msg<PalutenModMOD>("Title Screen");
    }

    public int FrameCount;
    public bool BossHasSpawned;

    public override void OnUpdate()
    {

        if (GameObject.Find("VideoPlane(Clone)"))
        {
            var Cutscene = GameObject.Find("VideoPlane(Clone)").GetComponent<VideoPlayer>();
            ModHelper.Msg<PalutenModMOD>("Update");
            if (Cutscene.Exists())
            {
                if (Cutscene.frame == 332)
                {
                    InGame.instance.ResumeClock();
                    Cutscene.Destroy();
                }
            }
        }
    }


    public override void OnRoundStart()
    {
        SceneC ??= GetBundle<PalutenModMOD>("ampmvideo");
        Object.Instantiate(SceneC.LoadAsset("VideoPlane"));
        if (Object.Instantiate(SceneC.LoadAsset("VideoPlane")) != null){
            ModHelper.Msg<PalutenModMOD>("Nicht Null");
        }
        else
        {
            ModHelper.Msg<PalutenModMOD>("Null");
        }
        if (GameObject.Find("Map/Environment/Cutscene(Clone)"))
        {
            if (InGame.instance.currentRoundId == 99)
            {
                if (GameObject.Find("Map/Environment/Cutscene(Clone)"))
                {
                    var Cutscene = GameObject.Find("Map/Environment/Cutscene(Clone)").GetComponent<VideoPlayer>();
                    var Camera = GameObject.Find("Engine/Cameras/SceneCameras/Scene").GetComponent<Camera>();
                    Cutscene.targetCamera = Camera;
                    Cutscene.Play();
                    InGame.instance.StopClock();
                }
            }

            
        }
    }



   

      
     
    private static NKMultiGameInterface? _nkGi;

    [HarmonyPatch(typeof(NKMultiGameInterface), nameof(NKMultiGameInterface.Connect))]
    private static class NKMultiGameInterface_Connect
    {
        [HarmonyPostfix]
        private static void Postfix(NKMultiGameInterface __instance)
        {
            _nkGi = __instance;
        }
    }



    public override void OnMainMenu()
    {
        
    }
}