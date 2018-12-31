using BattleTech;
using BattleTech.UI;
using Harmony;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace NotPlayingWithTheRealMechCommanders
{
    [HarmonyPatch(typeof(MainMenu), "Init")]
    public static class MainMenu_Init_Patch
    {
        private static void Prefix(MainMenu __instance)
        {
            try
            {
                FieldInfo field = __instance.GetType().GetField("topLevelMenu", BindingFlags.NonPublic | BindingFlags.Instance);
                HBSRadioSet topLevelMenu = (HBSRadioSet)field.GetValue(__instance);
                topLevelMenu.RadioButtons.Find((HBSButton x) => x.GetText() == "Career").gameObject.SetActive(false);
                HBS.Logging.Logger.HandleUnityLog("NotPlayingWithTheRealMechCommanders - Remove Career button for offline Roguetech play", string.Empty, LogType.Log);
            }
            catch(Exception e)
            {
                HBS.Logging.Logger.HandleUnityLog("NotPlayingWithTheRealMechCommanders - Exception Removing Career button for offline Roguetech play", e.ToString(), LogType.Exception);
            }
        }
    }
}
